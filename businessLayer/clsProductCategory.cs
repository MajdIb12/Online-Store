using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLayer
{
    public class clsProductCategory
    {
        private enum _enMode { AddNew = 1, UpdateMode = 2 };
        private _enMode _Mode = _enMode.AddNew;
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int CreatedByAdmin { get; set; }

        public clsAdmin Admin;

        public clsProductCategory()
        {
            CategoryName = string.Empty;
            CategoryID = 0;
            CreatedByAdmin = 0;
            _Mode = _enMode.AddNew;
        }

        private clsProductCategory(int categoryID, string categoryName, int createdByAdmin)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
            CreatedByAdmin = createdByAdmin;
            Admin = clsAdmin.FindAdmin(createdByAdmin);
            _Mode = _enMode.UpdateMode;
        }

        private bool _AddNewProductCategory()
        {
            int ID = clsProductCategoryData.AddNewProductCategoryData(CategoryName, CreatedByAdmin);
            return (ID > 0);
        }

        private bool _UpdateProductCategory()
        {
            return clsProductCategoryData.UpdateProductCategoryData(CategoryID, CategoryName, CreatedByAdmin);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode.AddNew:
                    if (_AddNewProductCategory())
                    {
                        _Mode = _enMode.UpdateMode;
                        return true;
                    }
                    return false;
                case _enMode.UpdateMode:
                    return _UpdateProductCategory();
            }
            return false;
        }

        public static clsProductCategory FindProductCategory(int ProductCategoryID)
        {

            int createdByAdmin = -1;
            string categotyName = "";
            
            if (clsProductCategoryData.FindProductCategoryData(ProductCategoryID, ref categotyName, ref createdByAdmin))
            {
                return new clsProductCategory(ProductCategoryID, categotyName, createdByAdmin);
            }
            return null;
        }


        public static bool RemoveProductCategory(int ProductCategoryID)
        {
            return clsProductCategoryData.DeleteproductCategoryData(ProductCategoryID);
        }

       

        public static DataTable GetAllProductCategory()
        {
            return clsProductCategoryData.GetAllProductCategoryData();
        }
    }
}
