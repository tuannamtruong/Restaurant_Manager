using System.Collections.Generic;
using System.Linq;
using Iesi.Collections.Generic;
using RestaurantManagement_DAO.DAO;

namespace RestaurantManagement_DAO.Entity_and_Mapping
{
    public class Food
    {
        #region Item From Table

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }

        #endregion

        #region Relation

        // Many to One Relation with FoodCategory
        public virtual FoodCategory FoodCategory { get; set; }
        // One to Many Relation with BillInfo
        public virtual Iesi.Collections.Generic.ISet<BillInfo> BillInfoCollection { get; set; }

        #endregion

        #region Function

        /// <summary>
        /// Get all Food that belong to one category 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>list of all the food from this category</returns>
        public static List<Food> LoadFoodByCategoryId(int categoryId)
        {
            List<Food> foodList;
            using (var session = DataProvider.SessionFactory.OpenSession())
            {
                foodList = session.QueryOver<Food>()
                    .Where(f => f.FoodCategory.Id == categoryId)
                    .List<Food>()
                    .ToList();
            }
            return foodList;
        }

        // Add BillInfo to this Food
        public virtual void AddBillInfo(BillInfo billInfo)
        {
            BillInfoCollection.Add(billInfo);
            billInfo.Food = this;
        }

        #endregion

        public Food()
        {
            BillInfoCollection = new HashedSet<BillInfo>();
        }    
    }
}
