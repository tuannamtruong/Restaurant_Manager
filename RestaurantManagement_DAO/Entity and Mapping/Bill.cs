using System;
using Iesi.Collections.Generic;
using NHibernate.Criterion;
using NHibernate.Util;
using RestaurantManagement_DAO.DAO;
namespace RestaurantManagement_DAO.Entity_and_Mapping
{
    public class Bill
    {
        #region Variable from Table

        public virtual int Id { get; set; }
        public virtual DateTime? DateCheckIn { get; set; }
        public virtual DateTime? DateCheckOut { get; set; }      
        public virtual GuestTable GuestTable { get; set; }
        public virtual bool Status { get; set; }
        public virtual int Discount { get; set; }
        
        #endregion

        #region Relation

        // one to many relation to BillInfo
        public virtual ISet<BillInfo> BillInfoCollection { get; set; }
       
        #endregion

        #region Constructor
        public Bill()
        {
            BillInfoCollection = new HashedSet<BillInfo>();
        }
        #endregion

        #region Function     

        // The bill been paid
        public static void CheckOut(int billId)
        {
            using (var session = DataProvider.SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var bill = session.Get<Bill>(billId);
                    bill.Status = true;
                    bill.DateCheckOut = DateTime.Now;
                    session.Update(bill);
                    transaction.Commit();
                }
            }
        }

        // Get the highest/max Id from Bill
        public static int GetHighestBillId()
        {
            int billId;
            using (var session = DataProvider.SessionFactory.OpenSession())
            {
                billId = (int)session.QueryOver<Bill>()
                    .Select(
                        Projections
                            .ProjectionList()
                            .Add(Projections.Max<Bill>(x => x.Id)))
                    .List<int>()
                    .First();
            }
            return billId;
        }

        // Create new Bill for a table with tableId
        public static void CreateBill(int tableId)
        {
            using (var session = DataProvider.SessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                // Create a new Bill
                var newBill = new Bill()
                {
                    DateCheckIn = DateTime.Now,
                    DateCheckOut = null,
                    GuestTable = session.Get<GuestTable>(tableId),
                    Status = false
                };
                session.Save(newBill);
                tx.Commit();
            }
        }

        /// <summary>
        /// Get the bill from this table, that was not paid
        /// </summary>
        /// <param name="tableId"></param>
        /// <returns>-1 if all bill in this table has been paid</returns>
        /// <returns>id of the bill from this table that haven't been paid</returns>
        public static int GetUncheckedBillIdByTableId(int tableId)
        {
            using (var session = DataProvider.SessionFactory.OpenSession())
            {
                // Search for the Bill from "tableId" and not been paid
                var uncheckBill = session.QueryOver<Bill>()
                    .Where(b => b.Status == false)
                    .Where(b => b.GuestTable.Id == tableId)
                    .SingleOrDefault();
                // When all the bill has been paid
                if (uncheckBill == null)
                    return -1;
                // else return the bill to be paid
                return uncheckBill.Id;
            }
        }

        // Add new BillInfo to this Bill
        public virtual void AddBillInfo(BillInfo billInfo)
        {
            BillInfoCollection.Add(billInfo);
            billInfo.Bill = this;
        }

        #endregion

     
    }
}
