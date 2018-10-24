using RestaurantManagement_DAO.DAO;

namespace RestaurantManagement_DAO.Entity_and_Mapping
{
    public class Account
    {
        #region Variable from the Table

        public virtual int Id { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual bool Type { get; set; }

        #endregion

        #region Function

        /// <summary>
        /// Check the validatoin of the inputed username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool Login(string username, string password)
        {
            using (var session = DataProvider.SessionFactory.OpenSession())
            {
                var query = session.QueryOver<Account>()
                    .Where(m => m.UserName == username)
                    .Where(m => m.Password == password)
                    .List();

                if (query.Count > 0)
                    return true;
                return false;
            }
        }

        #endregion

    }    
}
