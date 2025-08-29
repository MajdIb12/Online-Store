using businessLayer;
using OnlineStore.Admin_Settings;
using OnlineStore.Admin_Settings.Shippings;
using OnlineStore.Order_Procces;
using OnlineStore.Order_Procces.Track_Order;
using OnlineStore.Paymenets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore
{
    public partial class frmMain : Form
    {
        private frmLogin _Login;
        public frmMain(frmLogin login)
        {
            InitializeComponent();
            _Login = login;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (clsGlobal.LoginUser == clsGlobal.en_LoginUser.Admin)
            {
                adminsSettingsToolStripMenuItem.Visible = true;
            }
            this.BackColor = Color.White;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Login.Show();
            this.Close();
        }

        private void pCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductMain frmProductMain = new frmProductMain(2);
            frmProductMain.ShowDialog();
        }

        private void moblieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductMain frmProductMain = new frmProductMain(1);
            frmProductMain.ShowDialog();
        }

        private void productSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductSettings frmProductSettings = new frmProductSettings();
            frmProductSettings.ShowDialog();
        }

        

        private void trackOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.LoginUser == clsGlobal.en_LoginUser.Customer)
            {
                clsOrder Order = clsOrder.IsCustomerHaveOrderPending(clsGlobal.CustomerUser.CustomerID);
                if (Order != null)
                {
                    frmTrackOrder frmTrackOrder = new frmTrackOrder(Order.OrderID);
                    frmTrackOrder.ShowDialog();
                }
                else
                {
                    MessageBox.Show("There are not order pending");
                    return;
                }
            }
            else
            {
                frmTrackOrder frmTrackOrder = new frmTrackOrder();
                frmTrackOrder.ShowDialog();
            }
            
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPayments frmPayments = new frmPayments();
            frmPayments.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login_Register.frmAccountSettings frmAccountSettings = new Login_Register.frmAccountSettings();
            frmAccountSettings.ShowDialog();
        }
    }
}
