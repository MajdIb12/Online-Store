using businessLayer;
using OnlineStore.Admin_Settings.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore.Order_Procces.Controls
{
    public partial class ctrlAdminTracking : UserControl
    {
        private DataTable _Orders;
        public ctrlAdminTracking()
        {
            InitializeComponent();
        }
        private void _RefreshData()
        {

            _Orders = clsShipping.GetAllShippings();
            dgvProducts.DataSource = _Orders;
            lblCount.Text = dgvProducts.RowCount.ToString();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (txtFilter.Text.Trim() == "")
            {
                _RefreshData();
                return;
            }
            _Orders.DefaultView.RowFilter = string.Format($"[CarrierName] like '{txtFilter.Text}%'");
            lblCount.Text = _Orders.Rows.Count.ToString();
        }

        private void ctrlAdminTracking_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }
        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.Text.Trim() == "None")
            {
                _RefreshData();
                return;
            }
            _Orders.DefaultView.RowFilter = string.Format($"OrderStatus = '{cbStatus.Text}'");
            lblCount.Text = _Orders.Rows.Count.ToString();
        }

        private void cancelOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wanna Cancel Order", "!!!", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                clsOrder Order = clsOrder.FindOrder((int)dgvProducts.CurrentRow.Cells[1].Value);
                if (Order == null)
                {
                    return;
                }
                if (Order.Status != clsOrder.en_Status.Pending && Order.Status != clsOrder.en_Status.Processing)
                {
                    MessageBox.Show("Order already out");
                    return;
                }
                Order.Status = clsOrder.en_Status.Cancelled;
                if (Order.UpdateOrderStatus())
                {

                    MessageBox.Show("Order Canelled Succefully");
                    _RefreshData();
                }
                else
                {
                    MessageBox.Show("Wrong");
                }
            }
        }

        private void outOrderForDeliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsShipping shipping = clsShipping.FindShipmentByOrderID((int)dgvProducts.CurrentRow.Cells[1].Value);
            if (shipping == null)
            {
                return;
            }
            if (shipping.Status != clsShipping.en_Status.Processing)
            {
                MessageBox.Show("Order already out");
                return;
            }
            shipping.Status = clsShipping.en_Status.OutforDelivery;
            if (shipping.UpdateShipmentStatus())
            {
                MessageBox.Show("Shipping Succefully");
                _RefreshData();
            }
            else
            {
                MessageBox.Show("Wrong with Shippings");
            }
        }
    }
}
