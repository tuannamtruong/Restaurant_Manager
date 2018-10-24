using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement_DAO.Entity_and_Mapping;

namespace RestaurantManagement_DTO
{
    public class FoodCategoryDTO
    {
        #region Item from FoodCategory Table

        public int Id { get; set; }
        public string Name { get; set; }
        #endregion

        #region Constructor

        // Conversion from FoodCategory to FoodCategoryDTO
        public FoodCategoryDTO(FoodCategory foodCategory)
        {
            Id = foodCategory.Id;
            Name = foodCategory.Name;
        }

        #endregion

        /// <summary>
        /// Load all FoodCategory
        /// Convert FoodCategory to FoodCategoryDTO
        /// </summary>
        /// <returns>List of all FoodCategory</returns>
        public static List<FoodCategoryDTO> LoadCategory()
        {
            // Load all FoodCategory
            List<FoodCategory> foodCategoryList = FoodCategory.LoadCategory();

            // Convert FoodCategory to FoodCategoryDTO
            List<FoodCategoryDTO> foodCategoryDTOList = new List<FoodCategoryDTO>();
            foreach (var foodCategory in foodCategoryList)
            {
                var foodCategoryDTO = new FoodCategoryDTO(foodCategory);
                foodCategoryDTOList.Add(foodCategoryDTO);
            }
            return foodCategoryDTOList;
        }
    }
}
