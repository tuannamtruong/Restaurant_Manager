namespace RestaurantManagement_DTO
{
    /// <summary>
    /// A class to project data from billInfo and Food
    /// count from billInfo, foodName and price from Food
    /// Also help to calculate the total price
    /// </summary>
    public class MenuDTO
    {
        public MenuDTO(string foodName, int count, decimal price)
        {
            FoodName = foodName;
            Count = count;
            Price = price;
            TotalPrice = count*price;
        }

        public string FoodName { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
