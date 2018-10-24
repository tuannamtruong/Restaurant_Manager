using System;
using RestaurantManagement_DAO.Entity_and_Mapping;

namespace RestaurantManagement_DTO
{
    public class BillDTO
    {
        #region Item From Bill Table
        public int Id { get; set; }
        public DateTime? DateCheckIn { get; set; }
        public DateTime? DateCheckOut { get; set; }
        public GuestTableDTO GuestTable { get; set; }
        public bool Status { get; set; }
        public int Discount { get; set; }
        #endregion

        #region Constructor

        // Constructor for conversion from Bill to BillDTO
        public BillDTO(Bill bill)
        {
            Id = bill.Id;
            DateCheckIn = bill.DateCheckIn;
            DateCheckOut = bill.DateCheckOut;
            GuestTable = new GuestTableDTO(bill.GuestTable);
            Status = bill.Status;
            Discount = bill.Discount;
        }
        // Constructor when lazy loading GuestTableDTO
        public BillDTO(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, bool status, int discount = 0)
        {
            Id = id;
            DateCheckIn = dateCheckIn;
            DateCheckOut = dateCheckOut;           
            Status = status;
            Discount = discount;
        }
        #endregion

        #region Function

        // The bill been paid
        public static void CheckOut(int billId) 
        {
            Bill.CheckOut(billId);
        }

        /// <summary>
        /// Create new Bill to the Table
        /// </summary>
        /// <param name="tableId">Table where new bill will be created</param>
        public static void CreateBill(int tableId)
        {
            Bill.CreateBill(tableId);
        }

        // Get the highest/max Id from Bill
        public static int getHighestBillId()
        {
            return Bill.GetHighestBillId();
        }

        /// <summary>
        /// Get the bill from this table, that was not paid
        /// </summary>
        /// <param name="tableId"></param>
        /// <returns>-1 if all bill in this table has been paid</returns>
        /// <returns>id of the bill from this table that haven't been paid</returns>
        public static int GetUncheckedBillIdByTableId(int tableId)
        {
            return Bill.GetUncheckedBillIdByTableId(tableId);
        }

        #endregion

        
    }
}
