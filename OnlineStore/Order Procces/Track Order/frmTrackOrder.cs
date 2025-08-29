using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore.Order_Procces.Track_Order
{
    
    public partial class frmTrackOrder : Form
    {

        public frmTrackOrder(int OrderID)
        {
            InitializeComponent();
            ctrlAdminTracking1.Visible = false;
            ctrlShippingStatus1.Close += this._Close;
            ctrlShippingStatus1.LoadData(OrderID);
        }

        public frmTrackOrder()
        {
            InitializeComponent();
            ctrlShippingStatus1.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _Close()
        {
            this.Close();
        }
    }
}
