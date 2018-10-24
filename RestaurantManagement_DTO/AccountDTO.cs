using RestaurantManagement_DAO.Entity_and_Mapping;

namespace RestaurantManagement_DTO
{
    public class AccountDTO
    {
        /// <summary>
        /// Call the Login method from Account to check validation of input
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>value ofAccount.Login(username, password)</returns>
        public static bool Login(string username, string password)
        {
            return Account.Login(username, password);
        }
    }
}
