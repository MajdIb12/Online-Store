using businessLayer;
using OnlineStore.Global;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineStore.Admin_Settings.Products
{
    public partial class frmAddEditProduct : Form
    {
        int _ProductID;
        private enum _enMode {AddNew = 0, Update = 1};
        private _enMode _Mode;
        private clsProduct _Product;
        public frmAddEditProduct()
        {
            InitializeComponent();
            _Mode = _enMode.AddNew;
        }

        public frmAddEditProduct(int ProductID)
        {
            InitializeComponent();
            _ProductID = ProductID;
            _Product = clsProduct.FindProduct(ProductID);
            _Mode = _enMode.Update;
        }

        private void frmAddEditProduct_Load(object sender, EventArgs e)
        {
            if (_Mode == _enMode.AddNew)
            {
                lblMode.Text = "Add New Mode";
                this.Text = "Add New Product";
                return;
            }
            if (_Product != null)
            {
                lblMode.Text = "Update Mode";
                this.Text = "Update Product";
                
                lblID.Text = _ProductID.ToString();
                txtName.Text = _Product.ProductName;
                txtPrice.Text = _Product.Price.ToString();
                txtQuantity.Text = _Product.Quantity.ToString();
                txtDescription.Text = _Product.ProductDescription;
                if (_Product.CategoryID == 1)
                {
                    rbMoblie.Checked = true;
                }
                else
                {
                    rbPc.Checked = true;
                }
                DataTable Images = clsProductImage.GetAllProductImagesByProductID(_ProductID);
                for (int i = 0; i < Images.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        pictureBox1.ImageLocation = Images.Rows[0][2].ToString();
                    }
                    if (i == 1)
                    {
                        pictureBox2.ImageLocation = Images.Rows[1][2].ToString();
                    }
                    if (i == 2)
                    {
                        pictureBox3.ImageLocation = Images.Rows[2][2].ToString();
                    }
                }
                llRemoveImage1.Enabled = pictureBox1.ImageLocation != null;
                llRemoveImage2.Enabled = pictureBox2.ImageLocation != null;
                llRemoveImage3.Enabled = pictureBox3.ImageLocation != null;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsProduct.IsHaveSameProductName(txtName.Text.Trim()) && _Mode == _enMode.AddNew)
            {
                MessageBox.Show("This ProductName Alreadey Exist");
                return;
            }
            if (txtDescription.Text == "" || txtName.Text == "" || txtPrice.Text == "" || txtQuantity.Text == "")
            {
                MessageBox.Show("Please Fill All boxes");
                return;
            }
            if (_Mode == _enMode.AddNew)
            {
                clsProduct Product = new clsProduct();
                _Product = Product;
                _Product.ProductName = txtName.Text.Trim();
                _Product.CategoryID = rbMoblie.Checked ? 1 : 2;
            }
            
            _Product.Price = Convert.ToDouble(txtPrice.Text.Trim());
            _Product.Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
            _Product.ProductDescription = txtDescription.Text.Trim();
            _Product.CreatedByAdmin = clsGlobal.AdminUser.AdminID;
            if (!_Product.Save())
            {
                MessageBox.Show("Failed Saved");
                return;
            }
            MessageBox.Show("Data Saved Successfuly");
            lblID.Text = _Product.ProductID.ToString();


            if (_Mode == _enMode.Update)
            {
                DataTable data= clsProductImage.GetAllProductImagesByProductID(_ProductID);
                if (clsProductImage.RemoveProductImages(_ProductID))
                {
                    foreach (DataRow row in data.Rows)
                    {
                        File.Delete(row[2].ToString());

                    }
                }
                
                
            }
            if (pictureBox1.ImageLocation != null)
            {
                clsProductImage Image1 = new clsProductImage();
                Image1.ProductID = _Product.ProductID;
                string ImageURL = pictureBox1.ImageLocation;
                clsUtil.CopyImageToProjectImagesFolder(ref ImageURL);
                Image1.ImageURl = ImageURL;
                Image1.ImageOrder = 1;
                Image1.Save();
            }
            if (pictureBox2.ImageLocation != null)
            {
                clsProductImage Image2 = new clsProductImage();
                Image2.ProductID = _Product.ProductID; ;
                string ImageURL = pictureBox2.ImageLocation.ToString();
                clsUtil.CopyImageToProjectImagesFolder(ref ImageURL);
                Image2.ImageURl = ImageURL;
                Image2.ImageOrder = 2;
                Image2.Save();
            }
            if (pictureBox3.ImageLocation != null)
            {
                clsProductImage Image3 = new clsProductImage();
                Image3.ProductID = _Product.ProductID; ;
                string ImageURL = pictureBox3.ImageLocation.ToString();
                clsUtil.CopyImageToProjectImagesFolder(ref ImageURL);
                Image3.ImageURl = ImageURL;
                Image3.ImageOrder = 3;
                Image3.Save();
            }


        }




        private void llAddImage1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string imagepath = openFileDialog1.FileName;
                pictureBox1.ImageLocation = imagepath;
                llRemoveImage1.Enabled = true;
            }
        }

        private void llAddImage2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string imagepath = openFileDialog1.FileName;
                pictureBox2.ImageLocation = imagepath;
                llRemoveImage2.Enabled = true;
            }
        }

        private void llAddImage3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string imagepath = openFileDialog1.FileName;
                pictureBox3.ImageLocation = imagepath;
                llRemoveImage3.Enabled = true;
            }
        }

        private void llRemoveImage1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.ImageLocation = null;
            llRemoveImage1.Enabled = false;
        }

        private void llRemoveImage2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox2.ImageLocation = null;
            llRemoveImage2.Enabled = false;
        }

        private void llRemoveImage3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox3.ImageLocation = null;
            llRemoveImage3.Enabled = false;
        }
    }
}
