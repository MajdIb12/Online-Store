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

namespace OnlineStore.Admin_Settings.Shippings.Controls
{
    
    public partial class ctrlShippingStatus : UserControl
    {
        public delegate void FormClosing_EventHandler();

        public event FormClosing_EventHandler Close;

        private clsShipping _Shipping;
        public ctrlShippingStatus()
        {
            InitializeComponent();
        }

        public void LoadData(int OrderID)
        {
            _Shipping = clsShipping.FindShipmentByOrderID(OrderID);
            if ( _Shipping != null )
            {
                lblShippingId.Text = _Shipping.ShipmentID.ToString();
                lblOrderId.Text = OrderID.ToString();
                lblName.Text = _Shipping.CarrierName;
                lblEstimatedDate.Text = _Shipping.EstimatedDeliveryDate.ToShortDateString();
                lblActualDate.Text = _Shipping.ActualDeliveryData.ToShortDateString();
                lblStatus.Text = _Shipping.Status.ToString();
                if (_Shipping.Status != clsShipping.en_Status.OutforDelivery)
                {
                    btnDeliverd.Enabled = false;
                    btnReturn.Enabled = false;
                }

            }
            else
            {
                this.Enabled = false;
            }
        }

        private void btnDeliverd_Click(object sender, EventArgs e)
        {
            _Shipping.Status = clsShipping.en_Status.Delivered;
            if (_Shipping.UpdateShipmentStatus() )
            {
                MessageBox.Show("Welcome in our store, we hope see you again");
                Close?.Invoke();

            }
            else
            MessageBox.Show("Wrong with Delivred");
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            _Shipping.Status = clsShipping.en_Status.ReturnToSender;
            if (_Shipping.UpdateShipmentStatus())
            {
                MessageBox.Show("Welcome in our store, we sorry for that");
                Close?.Invoke();
            }
            else
            MessageBox.Show("Wrong with Return");
        }
    }
}
