using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLayer
{
    public class clsProduct
    {
        private enum _enMode { AddNew = 1, UpdateMode = 2 };
        private _enMode _Mode = _enMode.AddNew;
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int CreatedByAdmin { get; set; }

        public clsAdmin Admin;
        public int CategoryID { get; set; }

        public clsProductCategory Category;

        public clsProduct()
        {
            ProductID = 0;
            ProductName = string.Empty;
            ProductDescription = string.Empty;
            Price = 0;
            Quantity = 0;
            CreatedByAdmin = 0;
            CategoryID = 0;
            _Mode = _enMode.AddNew;
        }

        private clsProduct(int productID, string productName, string productDescription, double price, int quantity, int createdByAdmin, int categoryID)
        {
            ProductID = productID;
            ProductName = productName;
            ProductDescription = productDescription;
            Price = price;
            Quantity = quantity;
            CreatedByAdmin = createdByAdmin;
            Admin = clsAdmin.FindAdmin(createdByAdmin);
            CategoryID = categoryID;
            Category = clsProductCategory.FindProductCategory(categoryID);
            _Mode = _enMode.UpdateMode;
        }

        private bool _AddNewProduct()
        {
            int ID = clsProductData.AddNewProductData(ProductName, ProductDescription, Price, Quantity, CreatedByAdmin, CategoryID);
            if (ID > 0)
            {
                this.ProductID = ID;
                return true;
            }
            return false;
        }

        private bool _UpdateProduct()
        {
            return clsProductData.UpdateProductData(ProductID, ProductName, ProductDescription, Price, Quantity, CreatedByAdmin, CategoryID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode.AddNew:
                    if (_AddNewProduct())
                    {
                        _Mode = _enMode.UpdateMode;
                        return true;
                    }
                    return false;
                case _enMode.UpdateMode:
                    return _UpdateProduct();
            }
            return false;
        }

        public static clsProduct FindProduct(int ProductID)
        {

            int quantity = 0,  createdByAdmin = -1,  categoryID = -1;
            string productName = "", productDescription = "";
            double price = 0;
            if (clsProductData.FindProductData(ProductID, ref productName, ref productDescription, ref price, ref quantity, ref createdByAdmin, ref categoryID))
            {
                return new clsProduct(ProductID, productName, productDescription, price, quantity, createdByAdmin, categoryID);
            }
            return null;
        }

        
        public static bool RemoveProduct(int ProductID)
        {
            return clsProductData.DeleteproductData(ProductID);
        }

        public static bool IsProductExist(int ProductID)
        {
            return clsProductData.ISProductExistData(ProductID);
        }

        public static DataTable GetPageODProduct(int CategoryID, short PageNumber)
        {
            return clsProductData.GetPageOfProductDataByCategotyID(CategoryID, PageNumber);
        }

        public static DataTable GetAllProduct()
        {
            return clsProductData.GetAllProductDataByCategotyID();
        }
        
        public static bool IsHaveSameProductName(string ProductName)
        {
            return clsProductData.IsHaveSameProductNameData(ProductName);
        }

        public static bool ISProductCanDeleted(int ProductID)
        {
            return clsProductData.IsProductCanDeletedData(ProductID);
        }
    }
}
