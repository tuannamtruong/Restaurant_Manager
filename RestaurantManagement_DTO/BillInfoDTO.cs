using System.Collections.Generic;
using RestaurantManagement_DAO.Entity_and_Mapping;

namespace RestaurantManagement_DTO
{
    public class BillInfoDTO
    {
        #region Variables from BillInfo
        public int Id { get; set; }
        public int Count { get; set; }
        public BillDTO Bill { get; set; }
        public FoodDTO Food { get; set; }
        #endregion

        #region Constructor

        //Conversion from BillInfo to BillInfoDTO
        public BillInfoDTO(BillInfo billInfo)
        {
            Id = billInfo.Id;
            Count = billInfo.Count;
            Bill = new BillDTO(billInfo.Bill);
            Food = new FoodDTO(billInfo.Food);
        }

        // Eager Loading Food from BillInfo
        public BillInfoDTO(int id, int count, Food food)
        {
            Id = id;
            Count = count;
            Food = new FoodDTO(food);
        }
        #endregion

        #region Function

        /// <summary>
        /// Get List of BillInfo belong to the given bill ID
        /// List can be null if there is no billinfo belong to the bill ID
        /// </summary>
        /// <param name="billId"></param>
        /// <returns>List of BillInfo belong to the given bill ID</returns>
        public static List<BillInfoDTO> GetBillInfoByBillId(int billId)
        {
            List<BillInfo> billInfoList = BillInfo.GetBillInfoByBillId(billId);
            List<BillInfoDTO> billInfoDTOList = new List<BillInfoDTO>();
            if (billInfoList != null)
            {
                // Convert List of BillInfo to List of BillInfoDTO
                foreach (var billInfo in billInfoList)
                {
                    BillInfoDTO billInfoDTO = new BillInfoDTO(billInfo.Id, billInfo.Count, billInfo.Food);
                    billInfoDTOList.Add(billInfoDTO);
                }
            }
            return billInfoDTOList;
        }

        /// <summary>
        /// Base on the value of arguments, the BillInfo will be modified accordingly
        /// If this Food is not in this Bill: Case (1) or (2)
        /// If this Food already in this Bill: Case (2) or (3)
        /// (1) If the new count is positive: Add new Food into this Bill
        /// (2) If the new count of this food is negative or 0: Delete this Food from this Bill
        /// (3) If the new count is positive: Update the new count of this Food
        /// </summary>
        public static void ModifyBillInfo(int billId, int foodId, int count)
        {
            BillInfo.ModifyBillInfo(billId, foodId, count);
        }

        #endregion
    }
}
