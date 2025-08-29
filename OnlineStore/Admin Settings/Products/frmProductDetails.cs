using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore.Admin_Settings.Products
{
    public partial class frmProductDetails : Form
    {
        private int _ProductID;
        public frmProductDetails(int ProductID)
        {
            InitializeComponent();
            this._ProductID = ProductID;
        }

        private void frmProductDetails_Load(object sender, EventArgs e)
        {
            ctrlProductDetails1.LoadDataAsAdmin(_ProductID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
