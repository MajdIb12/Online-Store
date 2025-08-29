using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLayer
{
    public class clsProductImage
    {
        private enum _enMode { AddNew = 1, UpdateMode = 2 };
        private _enMode _Mode = _enMode.AddNew;
        public int ImageID { get; set; }
        public int ProductID { get; set; }
        public clsProduct Product;
        public string ImageURl { get; set; }
        public int ImageOrder { get; set; }

        public clsAdmin Admin;

        public clsProductImage()
        {
            ImageID = 0;
            ProductID = 0;
            ImageURl = string.Empty;
            ImageOrder = 0;
        }

        private clsProductImage(int imageID, int productID, string imageURl, int imageOrder)
        {
            this.ImageID = imageID;
            this.ProductID = productID;
            this.Product = clsProduct.FindProduct(productID);
            this.ImageURl = imageURl;
            this.ImageOrder = imageOrder;
        }
        

        private bool _AddNewProductImage()
        {
            int ID = clsProductImagesData.AddNewProductImageData(ImageURl, ProductID, ImageOrder);
            return (ID > 0);
        }

        private bool _UpdateProductImage()
        {
            return clsProductImagesData.UpdateProductImageData(ImageID, ImageURl, ProductID, ImageOrder);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode.AddNew:
                    if (_AddNewProductImage())
                    {
                        _Mode = _enMode.UpdateMode;
                        return true;
                    }
                    return false;
                case _enMode.UpdateMode:
                    return _UpdateProductImage();
            }
            return false;
        }

       


        public static bool RemoveProductImages(int ProductID)
        {
            return clsProductImagesData.DeleteproductImagesData(ProductID);
        }



        public static DataTable GetAllProductImagesByProductID(int productID)
        {
            return clsProductImagesData.GetAllProductImagesDataByProductID(productID);
        }
    }
}
