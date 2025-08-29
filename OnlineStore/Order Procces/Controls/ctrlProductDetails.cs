using businessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace OnlineStore.Order_Procces.Controls
{
    public partial class ctrlProductDetails : UserControl
    {
        private clsProduct _Product;
        private int _ProductID;
        private DataTable _Images;
        private int _CurrentRow = 0;
        public ctrlProductDetails()
        {
            InitializeComponent();
        }

        public void LoadData(int ProductID)
        {
            _ProductID = ProductID;
            clsProduct product = clsProduct.FindProduct(_ProductID);
            if (product != null)
            {
                _Product = product;
                DataTable Images = clsProductImage.GetAllProductImagesByProductID(_ProductID);
                _Images = Images;
                try
                {
                    if (Images.Rows[0][2] != null)
                    {
                        pbImage1.ImageLocation = Images.Rows[0][2].ToString();
                    }
                    
                }
                catch { }
                lblName.Text = _Product.ProductName;
                txtDescription.Text = _Product.ProductDescription;
            }
        }

        public void LoadDataAsAdmin(int ProductID)
        {
            _ProductID = ProductID;
            clsProduct product = clsProduct.FindProduct(_ProductID);
            if (product != null)
            {
                _Product = product;
                DataTable Images = clsProductImage.GetAllProductImagesByProductID(_ProductID);
                _Images = Images;
                try
                {
                    pbImage1.ImageLocation = Images.Rows[0][2].ToString();
                }
                catch { }
                lblName.Text = _Product.ProductName;
                txtDescription.Text = _Product.ProductDescription;
                btnAddToCart.Visible = false;
                npdQuantity.Value = Convert.ToDecimal(_Product.Quantity);
                npdQuantity.Enabled = false;
            }
        }
        private void button1_AddToCart(object sender, EventArgs e)
        {
            _Product = clsProduct.FindProduct(_ProductID);
            if (npdQuantity.Value <= 0)
            {
                MessageBox.Show("Quantity less than 1 not valid");
                return;
            }
            if (npdQuantity.Value > _Product.Quantity)
            {
                MessageBox.Show("there are " + _Product.Quantity.ToString() + " product only");
                return;
            }
            if (clsGlobal.LoginUser == clsGlobal.en_LoginUser.Admin)
            {
                return;
            }

            clsOrder order = clsOrder.IsCustomerHaveOrderPending(clsGlobal.CustomerUser.CustomerID);
            if (order == null)
            {
                order = new clsOrder();
                order.CustomerID = clsGlobal.CustomerUser.CustomerID;
                if (!order.AddNewOrder())
                {
                    return;
                }
            }

            clsOrderItems OrderItem = new clsOrderItems();
            OrderItem.OrderID = order.OrderID;
            OrderItem.ProductID = _ProductID;
            OrderItem.Quantity = Convert.ToInt32(npdQuantity.Value);
            if (OrderItem.Save())
            {
                MessageBox.Show("Add to cart succesfully");
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _CurrentRow += 1;
            try
            {
                pbImage1.ImageLocation = _Images.Rows[_CurrentRow][2].ToString();
                if (_CurrentRow >= _Images.Rows.Count - 1)
                {
                    btnNext.Enabled = false;
                    btnBack.Enabled = true;
                }
            }
            catch { }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _CurrentRow -= 1;
            try
            {
                pbImage1.ImageLocation = _Images.Rows[_CurrentRow][2].ToString();
                if (_CurrentRow <= _Images.Rows.Count - 1)
                {
                    btnBack.Enabled = false;
                    btnNext.Enabled = true;
                }
            }
            catch { }
        }
    }
}
