using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Util;
using RestaurantManagement_DAO.DAO;

namespace RestaurantManagement_DAO.Entity_and_Mapping
{
    public class BillInfo
    {
        #region Variable from Table

        public virtual int Id { get; set; }    
        public virtual int Count { get; set; }

        #endregion

        #region Relation

        // Many to One Relation to Bill
        public virtual Bill Bill { get; set; }
        // Many to One Relation to Food
        public virtual Food Food { get; set; }

        #endregion

        #region Function

        /// <summary>
        /// Base on the value of arguments, the BillInfo will be modified accordingly
        /// If this Food is not in this Bill: Case (1) or (2)
        /// If this Food already in this Bill: Case (2) or (3)
        /// (1) If the new count is positive: Add new Food into this Bill
        /// (2) If the new count of this food is negative or 0: Delete this Food from this Bill
        /// (3) If the new count is positive: Update the new count of this Food
        /// </summary>
        /// <param name="billId"></param>
        /// <param name="foodId"></param>
        /// <param name="count">amount of this Food in this Bill</param>
        public static void ModifyBillInfo(int billId, int foodId, int count)
        {
            using (var session = DataProvider.SessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    // Get the Food and Bill with the given ID
                    var food = session.Get<Food>(foodId);
                    var bill = session.Get<Bill>(billId);

                    // Try to find if there is a Food with foodId in this Bill
                    var billInfo = (BillInfo)session.QueryOver<BillInfo>()
                        .Where(x => x.Food.Id == food.Id)
                        .Where(x => x.Bill.Id == bill.Id)
                        .List<BillInfo>()
                        .FirstOrNull();

                    // If this Food is not in this Bill: 
                    if (billInfo == null)
                    {
                        // (1) Add new Food into this Bill
                        var newBillInfo = new BillInfo()
                        {
                            Bill = bill,
                            Food = food,
                            Count = count
                        };
                        session.Save(newBillInfo);
                        newBillInfo.Bill.Status = false;
                    }
                    else
                    {
                        // Calculate the new amount of Food in this Bill
                        billInfo.Count += count;                       
                        if (billInfo.Count <= 0)   // (2) then delete this Food from Bill                     
                            session.Delete(billInfo);
                        else // (3) Update the new amount
                        {
                            session.Update(billInfo);
                            billInfo.Bill.Status = false;
                        }
                    }
                    session.Update(bill);
                    tx.Commit();
                }
            }
        }

        /// <summary>
        /// Get List of BillInfo belong to the given bill ID
        /// List can be null if there is no billinfo belong to the bill ID
        /// </summary>
        /// <param name="billId"></param>
        /// <returns>List of BillInfo belong to the given bill ID</returns>
        public static List<BillInfo> GetBillInfoByBillId(int billId)
        {
            using (var session = DataProvider.SessionFactory.OpenSession())
            {
                var bill = session.Get<Bill>(billId);
                if(bill!=null)
                // Eager Loading all Food from each BillInfo
                foreach (var item in bill.BillInfoCollection)
                    NHibernateUtil.Initialize(item.Food);                              
                // if this bill is not NULL and there is at least 1 billInfo on this bill
                // then return the list of billInfo from this bill
                return bill?.BillInfoCollection?.ToList();              
            }
        }

        #endregion

    }
}
