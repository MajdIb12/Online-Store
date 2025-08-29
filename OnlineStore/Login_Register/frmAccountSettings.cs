using businessLayer;
using OnlineStore.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore.Login_Register
{
    public partial class frmAccountSettings : Form
    {
        enum enUser {Admin = 1, Customer = 2};
        enUser _User;
        public frmAccountSettings()
        {
            InitializeComponent();
            if (clsGlobal.LoginUser == clsGlobal.en_LoginUser.Admin)
            
                _User = enUser.Admin;
           
            else 
                _User = enUser.Customer;

        }

        private void LoadData()
        {
            if (_User == enUser.Admin)
            {
                var User = clsGlobal.AdminUser;
                txtFirstName.Text = User.FirstName;
                txtLastName.Text = User.LastName;
                txtEmail.Text = User.Email;
                txtPassword.Text = User.Password;
                txtPhone.Text = User.PhoneNumber;
                txtAddress.Text = User.Address;
            }
            else
            {
                var User = clsGlobal.CustomerUser;
                txtFirstName.Text = User.FirstName;
                txtLastName.Text = User.LastName;
                txtEmail.Text = User.Email;
                txtPassword.Text = User.Password;
                txtPhone.Text = User.PhoneNumber;
                txtAddress.Text = User.Address;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_User != enUser.Admin)
            {
                clsCustomer Customer = clsGlobal.CustomerUser;
                if (Customer.Email != txtEmail.Text)
                {
                    var newCustomer = clsCustomer.FindCustomerByEmail(txtEmail.Text.Trim());
                    if (newCustomer != null)
                    {
                        MessageBox.Show("This email already exist");
                        return;
                    }
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
                Customer.Email = txtEmail.Text.Trim();
                Customer.FirstName = txtFirstName.Text.Trim();
                Customer.LastName = txtLastName.Text.Trim();
                Customer.Address = txtAddress.Text.Trim();
                Customer.PhoneNumber = txtPhone.Text.Trim();
                Customer.Password = txtPassword.Text.Trim();

                if (Customer.Save())
                {
                    MessageBox.Show("Saved Successfully");
                }


            }
            else
            {
                clsAdmin Admin = clsGlobal.AdminUser;
                if (Admin.Email != txtEmail.Text)
                {
                    var newAdmin = clsAdmin.FindAdminByEmail(txtEmail.Text.Trim());
                    if (newAdmin != null)
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
                Admin.Email = txtEmail.Text.Trim();
                Admin.FirstName = txtFirstName.Text.Trim();
                Admin.LastName = txtLastName.Text.Trim();
                Admin.Address = txtAddress.Text.Trim();
                Admin.PhoneNumber = txtPhone.Text.Trim();
                Admin.Password = txtPassword.Text.Trim();

                if (Admin.Save())
                {
                    MessageBox.Show("Saved Successfully");
                }
            }
        }

        private void frmAccountSettings_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
