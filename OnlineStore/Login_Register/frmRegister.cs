using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using businessLayer;
using OnlineStore.Global;
using OnlineStore.Properties;


namespace OnlineStore.Login_Register
{
    public partial class frmRegister : Form
    {
        public delegate void DataBackSender(object Sender, string Email, string Password);
        public event DataBackSender DataBack;
        public frmRegister()
        {
            InitializeComponent();
        }

       

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsCustomer Customer = clsCustomer.FindCustomerByEmail(txtEmail.Text.Trim());
            if (Customer != null)
            {
                MessageBox.Show("This email already exist");
                return;
            }
            if (!clsValidation.EmailValidation(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Email Not valid, try to Enter another one");
                return;
            }
            if (!clsValidation.IsValidPhone(txtPhone.Text.Trim()))
            {
                MessageBox.Show("Phone Number Not valid, try to Enter another one");
                return;
            }
            Customer = new clsCustomer();
            Customer.Email = txtEmail.Text.Trim();
            Customer.FirstName = txtFirstName.Text.Trim();
            Customer.LastName = txtLastName.Text.Trim();
            Customer.Address = txtAddress.Text.Trim();
            Customer.PhoneNumber = txtPhone.Text.Trim();
            Customer.Password = txtPassword.Text.Trim();

            if (Customer.Save())
            {
                MessageBox.Show("Saved Successfuly");
                DataBack.Invoke(this, Customer.Email, Customer.Password);
                return;
            }
            
            MessageBox.Show("Wrong data");
            
        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
