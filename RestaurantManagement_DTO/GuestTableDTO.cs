using System.Collections.Generic;
using RestaurantManagement_DAO.Entity_and_Mapping;

namespace RestaurantManagement_DTO
{
    public class GuestTableDTO
    {
        #region Constructor
        
        //Conversion from GuestTable to GuestTableDTO
        public GuestTableDTO(GuestTable guestTable)
        {
            Id = guestTable.Id;
            Name = guestTable.Name;
            Status = guestTable.Status;
        }
        // Lary Loading GuestTable
        public GuestTableDTO(int id, string name, string status)
        {
            Id = id;
            Name = name;
            Status = status;
        }
        #endregion
        #region Item from GuestTable

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Status { get; private set; }

        #endregion
        /// <summary>
        /// Load all the Table from the restaurant
        /// </summary>
        /// <returns>List of every table from this restaurant</returns>
        public static IList<GuestTableDTO> LoadTable()
        {
            // Get the Table list from database
            IList<GuestTable> guestTableList = GuestTable.LoadTable();
            // Convert data from clas GuestTable to GuestTableDTO so FrontEnd can understand
            IList<GuestTableDTO> guestTableDTOList = new List<GuestTableDTO>();
            foreach (var guestTable in guestTableList)
            {
                var guestTableDTO = new GuestTableDTO(guestTable);
                guestTableDTOList.Add(guestTableDTO);
            }
            return guestTableDTOList;
        }


        public static void SwitchTable(int table1, int table2)
        {
            GuestTable.SwitchTable(table1, table2);
        }
    }
}
