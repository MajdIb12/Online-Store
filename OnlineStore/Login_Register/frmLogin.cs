using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using businessLayer;
using OnlineStore.Global;
using OnlineStore.Login_Register;
namespace OnlineStore
{
    public partial class frmLogin : Form
    {
        
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!(clsGlobal.IsAdmin(txtEmail.Text.Trim(), txtPassword.Text.Trim()) || clsGlobal.IsCustomer(txtEmail.Text.Trim(), txtPassword.Text.Trim())))
            {
                MessageBox.Show("Invalid email or password");
                return;
            }
            if (cbRememberMe.Checked)
            {
                
                clsGlobal.SaveRegistry(txtEmail.Text.Trim(), txtPassword.Text.Trim());
            }
            this.Hide();
            frmMain frmMain = new frmMain(this);
            frmMain.ShowDialog();
            
        }

        private void llCraete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            frmRegister frmRegister = new frmRegister();
            frmRegister.DataBack += frmLogin_DataBack;
            frmRegister.ShowDialog();
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (clsGlobal.GetAccountFromRegistry())
            {
                if (clsGlobal.AdminUser.Email != "")
                {
                    txtEmail.Text = clsGlobal.AdminUser.Email;
                    txtPassword.Text = clsGlobal.AdminUser.Password;
                }
                else
                {
                    txtEmail.Text = clsGlobal.CustomerUser.Email;
                    txtPassword.Text = clsGlobal.CustomerUser.Password;
                }
            }
            
        }

        private void frmLogin_DataBack(object sender, string Email, string Password)
        {
            txtEmail.Text = Email;
            txtPassword.Text = Password;
        }
    }
}
