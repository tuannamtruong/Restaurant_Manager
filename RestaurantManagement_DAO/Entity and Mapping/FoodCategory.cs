using System.Collections.Generic;
using System.Linq;
using Iesi.Collections.Generic;
using RestaurantManagement_DAO.DAO;

namespace RestaurantManagement_DAO.Entity_and_Mapping
{
    public class FoodCategory
    {
        #region Item From Table

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        #endregion

        public FoodCategory()
        {
            FoodCollection = new HashedSet<Food>();
        }

        #region Relation

        //One to Many Relation with Food
        public virtual Iesi.Collections.Generic.ISet<Food> FoodCollection { get; set; }


        #endregion

        #region Function

        // Add new Food to FoodCategory
        public virtual void AddFood(Food food)
        {
            FoodCollection.Add(food);
            food.FoodCategory = this;
        }

        /// <summary>
        /// Load all FoodCategory
        /// </summary>
        /// <returns>List of all FoodCategory</returns>
        public static List<FoodCategory> LoadCategory()
        {
            List<FoodCategory> foodCategoryList;
            using (var session = DataProvider.SessionFactory.OpenSession())
            {
                foodCategoryList = session.CreateCriteria<FoodCategory>()
                    .List<FoodCategory>()
                    .ToList();
            }

            return foodCategoryList;
        }

        #endregion


    }
}
