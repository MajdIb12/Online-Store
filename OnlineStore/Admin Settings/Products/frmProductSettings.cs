using businessLayer;
using OnlineStore.Admin_Settings.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore.Admin_Settings
{
    public partial class frmProductSettings : Form
    {
        private DataTable _Products;
        public frmProductSettings()
        {
            InitializeComponent();
        }
        private void _RefreshData()
        {
            int CategoryID;
            _Products = clsProduct.GetAllProduct();
            if (rbMobile.Checked) { CategoryID = 1; } else { CategoryID = 2; }
            _Products.DefaultView.RowFilter = string.Format($"CategoryID = {CategoryID}");
            dgvProducts.DataSource = _Products;
            lblCount.Text = dgvProducts.RowCount.ToString();
        }
        private void frmProductSettings_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (txtFilter.Text.Trim() == "")
            {
                
                _RefreshData();
                return;
            }
            _Products.DefaultView.RowFilter = string.Format($"[ProductName] like '{txtFilter.Text}%'");
            lblCount.Text = dgvProducts.RowCount.ToString();
        }

        private void rbPC_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPC.Checked)
            {
                _Products.DefaultView.RowFilter = string.Format("CategoryID = 2");
            }
            else
            {
                _Products.DefaultView.RowFilter = string.Format("CategoryID = 1");
            }
            lblCount.Text = dgvProducts.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductDetails frmProductDetails = new frmProductDetails((int)dgvProducts.CurrentRow.Cells[0].Value);
            frmProductDetails.ShowDialog();
        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditProduct frm = new frmAddEditProduct();
            frm.ShowDialog();
            _RefreshData();
        }

        private void updateProducToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditProduct frm = new frmAddEditProduct((int)dgvProducts.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ProductID = (int)dgvProducts.CurrentRow.Cells[0].Value;
            if (clsProduct.ISProductCanDeleted(ProductID))
            {
                MessageBox.Show("This Product can not removed");
                return;
            }


            if (MessageBox.Show("Are you sure!!", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DataTable data = clsProductImage.GetAllProductImagesByProductID(ProductID);
                if (clsProductImage.RemoveProductImages(ProductID))
                {
                    foreach (DataRow row in data.Rows)
                    {
                        File.Delete(row[2].ToString());
                    }
                }


                if (clsProduct.RemoveProduct((int)dgvProducts.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Removed Successfuly");
                    _RefreshData();
                }
            }

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditProduct frm = new frmAddEditProduct();
            frm.ShowDialog();
            _RefreshData();
        }
    }
}
