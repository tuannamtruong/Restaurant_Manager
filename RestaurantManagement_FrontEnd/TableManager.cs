using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using RestaurantManagement_DTO;

namespace RestaurantManagement_FrontEnd
{
    public partial class TableManagerForm : Form
    {
        public TableManagerForm()
        {
            InitializeComponent();
            LoadTable();        
            LoadCategory();
            LoadComboboxTable(_switchTableComboBox);
        }


        #region Function

       
        // Load all Food that belong to one category ( the one that have categoryId)
        private void LoadFoodByCategoryId(int categoryId)
        {
            List<FoodDTO> foodList = FoodDTO.LoadFoodByCategoryId(categoryId);
            _foodComboBox.DataSource = foodList;
            _foodComboBox.DisplayMember = "Name";
        }

        // Load all Food Category
        private void LoadCategory()
        {
            List<FoodCategoryDTO> foodCategoryList = FoodCategoryDTO.LoadCategory();
            _categoryComboBox.DataSource = foodCategoryList;
            _categoryComboBox.DisplayMember = "Name";
        }

        /// <summary>
        /// Load all the Table of the Restaurant
        /// Each Table represnt as a buton, that have Table's name and status
        /// </summary>
        private void LoadTable()
        {
            _tableManagerFlowLayoutPanel.Controls.Clear();
            var listTable = GuestTableDTO.LoadTable();
            foreach (var item in listTable)
            {
                var btn = new Button() { Height = 80, Width = 80 };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += TableButton_Click; // Add EventHandler
                btn.Tag = item;         // Add Tag to each Button. Tag is a single GuestTable
                switch (item.Status)
                {
                    case "Busy":
                        btn.BackColor = Color.Red;
                        break;
                    case "Empty":
                    default:
                        btn.BackColor = Color.LightGreen;
                        break;

                }
                _tableManagerFlowLayoutPanel.Controls.Add(btn);
            }
        }
        
        /// <summary>
            /// Show all the order of the unpaid bill in this table into the billView
            /// If there is no unpaid bill in this table => return;
            /// </summary>
            /// <param name="tableId">id of the selected table</param>
        private void ShowBill(int tableId)
        {
            _billView.Items.Clear();
            // To get all the orders from this table. First, we get the unpaid bill(ID) from this table
            // When we have the Id, we can get all the billInfo from this Bill.
            // The List billInfoList will contains all of the orders(billInfo) from this table.
            // If there is no unpaid bill from this Table(List == null) then return;
            List<BillInfoDTO> billInfoList =
                BillInfoDTO.GetBillInfoByBillId(BillDTO.GetUncheckedBillIdByTableId(tableId));
            if (billInfoList == null)
                return;
            decimal totalBill = 0;
            // Print out the data from billInfoList to billView
            foreach (var billInfo in billInfoList)
            {
                MenuDTO menu = new MenuDTO(billInfo.Food.Name, billInfo.Count, billInfo.Food.Price);
                ListViewItem lsvItem = new ListViewItem(menu.FoodName);
                lsvItem.SubItems.Add(menu.Count.ToString());
                lsvItem.SubItems.Add(menu.Price.ToString());
                lsvItem.SubItems.Add(menu.TotalPrice.ToString());
                _billView.Items.Add(lsvItem);
                totalBill += menu.TotalPrice;
            }
            _totalPriceTextBox.Text = totalBill.ToString("c", CultureInfo.CreateSpecificCulture("de-DE"));
        }

        #endregion

        #region Event

        // User pay the bill
        private void _payButton_Click(object sender, EventArgs e)
        {
            GuestTableDTO table = (_billView.Tag as GuestTableDTO);
            var billId = BillDTO.GetUncheckedBillIdByTableId(table.Id); // Get the unpaid bill from this table

            int discount = (int)_discountNumericUpDown.Value;
            decimal totalPrice = Convert.ToDecimal(_totalPriceTextBox.Text.Split(',')[0]);
            decimal afterDiscount = totalPrice - (totalPrice / 100 * discount);
            if (billId != -1)
            {
                if (MessageBox.Show(string.Format("Confirm for Payment? {0}\n After Discount: {1}", table.Name, afterDiscount), "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    BillDTO.CheckOut(billId);
                ShowBill(table.Id);
            }
            LoadTable();
        }

        // User click Order Button
        private void _addOrderButton_Click(object sender, EventArgs e)
        {
            // Get what is the order/billInfo 
            var count = _countNumericUpDown.Value;
            var foodId = (_foodComboBox.SelectedItem as FoodDTO).Id;
            if (_foodComboBox.SelectedItem == null) return; // If this Category have no Food Item
            /*
             * If the current Customer haven't ordered anything (Which mean no unchecked Bill)
             * Create new Bill
             */
            var tableId = (_billView.Tag as GuestTableDTO).Id;
            if (_billView.Tag == null) return;
            // Check if there is an order already on this table
            var billId = BillDTO.GetUncheckedBillIdByTableId(tableId);
            if (billId == -1)   // If there is no uncheck bill in this table
            {
                BillDTO.CreateBill(tableId);    // Create a new bill for this table
                // The new Bill will have the heighest value
                BillInfoDTO.ModifyBillInfo(BillDTO.getHighestBillId(), foodId, (int)count);
            }
            else
                BillInfoDTO.ModifyBillInfo(billId, foodId, (int)count);
            ShowBill(tableId);
            LoadTable();
        }


        // When user choose/change foodCategory, Load all food from this new category
        private void _categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            // If there is no category
            if (comboBox == null) return;

            // Get the foodCategory Id
            FoodCategoryDTO category = comboBox.SelectedItem as FoodCategoryDTO;
            int categoryId = category.Id;
            
            // Load all food from this category
            LoadFoodByCategoryId(categoryId);
        }

        // User click on a table
        void TableButton_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as GuestTableDTO).Id;
            // Pass the current Table into billView.Tag
            _billView.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
        #region Strip Menu Item

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #endregion
        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = GuestTableDTO.LoadTable();
            cb.DisplayMember = "Name";
        }

        private void _switchTableButton_Click(object sender, EventArgs e)
        {
            // If both table are empty, then there are nothing to swap
            if ((_billView.Tag as GuestTableDTO) == null &&
                (_switchTableComboBox.SelectedItem as GuestTableDTO) == null)
                return;

            int table1 = (_billView.Tag as GuestTableDTO).Id;
            int table2 = (_switchTableComboBox.SelectedItem as GuestTableDTO).Id;
            GuestTableDTO.SwitchTable(table1, table2);

            LoadTable();
        }
    }
}