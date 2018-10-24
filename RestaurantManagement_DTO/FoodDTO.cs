using System.Collections.Generic;
using RestaurantManagement_DAO.Entity_and_Mapping;

namespace RestaurantManagement_DTO
{
    public class FoodDTO
    {
        #region Item from Food Table
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public FoodCategoryDTO FoodCategory { get; set; }
        #endregion

        #region Constructor

        // Conversion from Food to FoodDTO
        public FoodDTO(Food food)
        {
            Id = food.Id;
            Name = food.Name;
            Price = food.Price;
            FoodCategory = new FoodCategoryDTO(food.FoodCategory);
        }

        #endregion

        #region Function

        /// <summary>
        /// Load all Food from one category
        /// Convert Food.cs to FoodDTO.cs
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>list of food in this category</returns>
        public static List<FoodDTO> LoadFoodByCategoryId(int categoryId)
        {
            // Load all Food from one category
            List<Food> foodList = Food.LoadFoodByCategoryId(categoryId);
            // Convert Food.cs to FoodDTO.cs
            List<FoodDTO> foodDTOList = new List<FoodDTO>();
            foreach (var food in foodList)
            {
                var foodDTO = new FoodDTO(food);
                foodDTOList.Add(foodDTO);
            }

            return foodDTOList;
        }

        #endregion

    }
}
