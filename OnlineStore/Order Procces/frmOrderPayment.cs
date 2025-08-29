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
    public partial class frmOrderPayment : Form
    {
        private int _OrderId;
        public frmOrderPayment(int OrderID)
        {
            InitializeComponent();
            _OrderId = OrderID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOrderPayment_Load(object sender, EventArgs e)
        {
            clsOrder Order = clsOrder.FindOrder(_OrderId);
            if (Order != null)
            {
                clsCustomer Customer = clsCustomer.FindCustomer(Order.CustomerID);
                lblName.Text = Customer.FirstName + " " + Customer.LastName;
                StringBuilder S = new StringBuilder();
                DataTable OrderData = clsOrderItems.GetAllOrderItems(_OrderId);
                if (OrderData.Rows.Count > 0)
                {
                    foreach (DataRow Row in OrderData.Rows)
                    {
                        S.Append(Row["Quantity"].ToString());
                        S.Append(" Of ");
                        S.Append(Row["ProductName"].ToString());
                        S.Append(", ");
                    }
                }
                lblItems.Text = S.ToString();
                lblDate.Text = Order.OrderDate.ToShortDateString();
                lblPrice.Text = Order.OrderPrice.ToString();
                lblStatus.Text = Order.StatusText;
                
            }
            if (Order.Status == clsOrder.en_Status.Cancelled)
            {
                this.Close();
                return;
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            clsPayment payment = clsPayment.FindOrder(_OrderId);
            if (payment == null)
            {
                payment = new clsPayment();
                payment.OrderID = _OrderId;
                if (rdPaypal.Checked)
                {
                    payment.PaymentMethodID = 1;
                }
                else
                {
                    payment.PaymentMethodID = 2;
                }
                if (!payment.AddNewPayment())
                {
                    MessageBox.Show("Wrong with payment");
                    return;
                }
            }
            else
            {
                if (rdPaypal.Checked)
                {
                    payment.PaymentMethodID = 1;
                }
                else
                {
                    payment.PaymentMethodID = 2;
                }
                if (!payment.UpdatePayment())
                {
                    MessageBox.Show("Wrong with payment");
                    return;
                }
            }
            
             clsOrder Order = clsOrder.FindOrder(_OrderId);
             Order.Status = clsOrder.en_Status.Processing;
             clsShipping shipping = clsShipping.FindShipmentByOrderID(Order.OrderID);
             if (shipping == null)
             {
                 shipping = new clsShipping();
                 shipping.OrderID = _OrderId;
                 shipping.CarrierName = lblName.Text;
                 DateTime time = DateTime.Now;
                 shipping.EstimatedDeliveryDate = time.AddHours(1);
                 if (!shipping.AddNewShipment())
                 {
                     MessageBox.Show("Wrong with shipment");
                     return;
                 }
             }
             
             if (Order.UpdateOrderStatus())
                 MessageBox.Show("Shipped Succesfully");
            
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wanna Cancel Order", "!!!", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                clsOrder Order = clsOrder.FindOrder(_OrderId);
                Order.Status = clsOrder.en_Status.Cancelled;
                if (Order.UpdateOrderStatus())
                {

                    MessageBox.Show("Order Canelled Succefully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong");
                }
            }
            
        }
    }
}
