using businessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore.Order_Procces
{
    public partial class frmProductMain : Form
    {
        private DataTable _ProductsTable;
        private int _CategoryID;
        public frmProductMain(int CategoryID)
        {
            InitializeComponent();
            _CategoryID = CategoryID;
        }

        private void _RefreshData()
        {

            short PageNumber = Convert.ToInt16(npdPage.Value);
            _ProductsTable = clsProduct.GetPageODProduct(_CategoryID, PageNumber);
            ctrlProductDetails1.Visible = true;
            ctrlProductDetails2.Visible = true;
            ctrlProductDetails3.Visible = true;
            if (_ProductsTable.Rows.Count == 0)
            {
                ctrlProductDetails1.Visible = false;
                ctrlProductDetails2.Visible = false;
                ctrlProductDetails3.Visible = false;
            }
            else if (_ProductsTable.Rows.Count == 1)
            {
                ctrlProductDetails1.LoadData(Convert.ToInt32(_ProductsTable.Rows[0][0]));
                ctrlProductDetails2.Visible = false;
                ctrlProductDetails3.Visible = false;
            }
            else if (_ProductsTable.Rows.Count == 2)
            {
                ctrlProductDetails1.LoadData(Convert.ToInt32(_ProductsTable.Rows[0][0]));
                ctrlProductDetails2.LoadData(Convert.ToInt32(_ProductsTable.Rows[1][0]));
                ctrlProductDetails3.Visible = false;
            }
            else
            {
                ctrlProductDetails1.LoadData(Convert.ToInt32(_ProductsTable.Rows[0][0]));
                ctrlProductDetails2.LoadData(Convert.ToInt32(_ProductsTable.Rows[1][0]));
                ctrlProductDetails3.LoadData(Convert.ToInt32(_ProductsTable.Rows[2][0]));
            }

        }

        private void frmProductMain_Load(object sender, EventArgs e)
        {
            lblProductCategory.Text = clsProductCategory.FindProductCategory(_CategoryID).CategoryName;
            _RefreshData();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            clsOrder Order = clsOrder.IsCustomerHaveOrderPending(clsGlobal.CustomerUser.CustomerID);
            if (Order != null)
            {
                frmOrderPayment frmOrderPayment = new frmOrderPayment(Order.OrderID);
                frmOrderPayment.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Order Exist");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
