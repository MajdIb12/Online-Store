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

namespace OnlineStore.Paymenets
{
    public partial class frmPayments : Form
    {
        DataTable dt;
        public frmPayments()
        {
            InitializeComponent();
        }

        private void _RefreshData()
        {
            
            if (clsGlobal.LoginUser == clsGlobal.en_LoginUser.Customer)
            {
                dt = clsPayment.GetAllPaymentByID(clsGlobal.CustomerUser.CustomerID);
                dgvPayments.DataSource = dt;
            }
            else
            {
                dt = clsPayment.GetAllPayment();
                dgvPayments.DataSource = dt;
            }
            if (rbPaybal.Checked)
                dt.DefaultView.RowFilter = string.Format("[MethodName] Like 'Pay%'");
            else if(rbCreditCard.Checked)
                dt.DefaultView.RowFilter = string.Format("[MethodName] Like 'Cre%'");
            lblCount.Text = dt.Rows.Count.ToString();
        }
        private void frmPayments_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbPaybal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPaybal.Checked)
                dt.DefaultView.RowFilter = string.Format("[MethodName] Like 'Pay%'");
            else if (rbCreditCard.Checked)
                dt.DefaultView.RowFilter = string.Format("[MethodName] Like 'Cre%'");
            lblCount.Text = dt.Rows.Count.ToString();
        }

        private void rdNone_CheckedChanged(object sender, EventArgs e)
        {
            _RefreshData();
        }
    }
}
