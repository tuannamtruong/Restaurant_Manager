using System;
using System.Windows.Forms;
using RestaurantManagement_DTO;

namespace RestaurantManagement_FrontEnd
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();          
        }

      
        // Check validation of login info
        private bool Login(string username, string password)
        {
            return AccountDTO.Login(username, password);
        }

        #region Event

        // User click Login Button
        private void _loginButton_Click(object sender, EventArgs e)
        {
            if (Login(_userNameTextBox.Text, _passwordTextBox.Text))
            {

                TableManagerForm f = new TableManagerForm();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Wrong Usernam or Password");
            }
        }

        // User click Exit Button
        private void _exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // User close this form
        private void _loginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Confirm Exit?", "Confirm to Exit", MessageBoxButtons.OKCancel) !=
                System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }

        }

        #endregion

    }
}
