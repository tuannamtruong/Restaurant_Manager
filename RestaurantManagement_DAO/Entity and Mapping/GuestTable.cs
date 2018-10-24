using System.Collections.Generic;
using System.Linq;
using Iesi.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using RestaurantManagement_DAO.DAO;

namespace RestaurantManagement_DAO.Entity_and_Mapping
{
    public class GuestTable
    {
        #region Attribute from table
        
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Status { get; set; }

        #endregion

        #region Function

        /// <summary>
        /// Switch Two Table
        /// 4 cases:
        /// 1) When both table are status="Busy" then just swap the Foreign Key Value from the unpaid Bill from these tables
        /// 2,3) When one of the table is "Busy" while the other is "Empty" then change the status of both table after switch for corresponded status
        /// 4) Both table are empty: then no swap is needed
        /// </summary>
        /// <param name="firstTableId"></param>
        /// <param name="secondTableId"></param>
        public static void SwitchTable(int firstTableId, int secondTableId)
        {
            using (var session = DataProvider.SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var firstTable = session.Get<GuestTable>(firstTableId);
                    NHibernateUtil.Initialize(firstTable.BillCollection);

                    var secondTable = session.Get<GuestTable>(secondTableId);
                    NHibernateUtil.Initialize(secondTable.BillCollection);

                    var billFromFirstTable = session
                        .Query<Bill>()
                        .Where(b => b.GuestTable.Id == firstTableId)
                        .FirstOrDefault(b => b.Status == false);

                    var billFromSecondTable = session
                        .Query<Bill>()
                        .Where(b => b.GuestTable.Id == secondTableId)
                        .FirstOrDefault(b => b.Status == false);

                    // If both table is not null, then 
                    // switch billInfo between these 2 tables
                    // and switch status of 2 tables
                    if (firstTable.Status != "Empty" || secondTable.Status != "Empty")
                    {
                        session.Update(firstTable);

                        // If first table is not null         
                        if (billFromFirstTable != null)
                        {
                            // If both table is not null
                            if (billFromSecondTable != null)
                            {
                                // Swap the billInfo by changing value of FK(idTable) from each Bill to the other table
                                GuestTable middleManTable = billFromSecondTable.GuestTable;
                                billFromSecondTable.GuestTable = billFromFirstTable.GuestTable;
                                billFromFirstTable.GuestTable = middleManTable;
                                // Both table are busy so no need to change status of both table  
                                // Update                              
                                session.Update(billFromSecondTable);
                            }
                            // If second table is null
                            else
                            {
                                billFromFirstTable.GuestTable = secondTable;
                                firstTable.Status = "Empty";
                                secondTable.Status = "Busy";
                                session.Update(firstTable);
                                session.Update(firstTable);
                            }

                            session.Update(billFromFirstTable);
                        }
                        else // If first table is empty
                        {
                            if (billFromSecondTable != null)
                            {
                                billFromSecondTable.GuestTable = firstTable;
                                firstTable.Status = "Busy";
                                secondTable.Status = "Empty";
                                session.Update(firstTable);
                                session.Update(firstTable);
                            }
                        }
                        transaction.Commit();
                    }
                }
            }
        }

        // Get all the GuestTable from DB
        public static IList<GuestTable> LoadTable()
        {
            using (var session = DataProvider.SessionFactory.OpenSession())
            {
                var listTable = session.QueryOver<GuestTable>().List();
                return listTable;
            }
        }

        // Add an Bill to this Table
        public virtual void AddBill(Bill bill)
        {
            BillCollection.Add(bill);
            bill.GuestTable = this;
        }
        #endregion

        public GuestTable()
        {
            BillCollection = new HashedSet<Bill>();
        }
        #region Relation
        
        // One to Many Relation with Bill
        public virtual Iesi.Collections.Generic.ISet<Bill> BillCollection { get; set; }    
        #endregion

   
    }
}
