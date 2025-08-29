using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace businessLayer
{
    public class clsAdmin
    {
        private enum _enMode { AddNew = 1, UpdateMode = 2 };
        private _enMode _Mode = _enMode.AddNew;
        public int AdminID {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Permission {  get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public clsAdmin()
        {
            AdminID = -1;
            FirstName = string.Empty;
            LastName = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            Permission = 0;
            Address = string.Empty;
            PhoneNumber = string.Empty;
            Image = string.Empty;
            _Mode = _enMode.AddNew;
        }

        private clsAdmin(int adminID, string firstName, string lastName, int permission, string address, string phoneNumber, string image, string email, string password)
        {
            AdminID = adminID;
            FirstName = firstName;
            LastName = lastName;
            Permission = permission;
            Address = address;
            PhoneNumber = phoneNumber;
            Image = image;
            Email = email;
            Password = password;
            _Mode = _enMode.UpdateMode;
        }

        private bool _AddNewAdmin()
        {
           int ID =  clsAdminData.AddNewAdminData(FirstName, LastName, Permission, Address, PhoneNumber, Image, Email, Password);
            return (ID > 0);
        }

        private bool _UpdateAdmin()
        {
            return clsAdminData.UpdateAdminData(AdminID, FirstName, LastName, Permission, Address,PhoneNumber, Image, Email, Password);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode.AddNew:
                    if (_AddNewAdmin())
                    {
                        _Mode = _enMode.UpdateMode;
                        return true;
                    }
                    return false;
                case _enMode.UpdateMode:
                    return _UpdateAdmin();
            }
            return false ;
        }

        public static clsAdmin FindAdmin(int AdminID)
        {
            int permission = 0;
            string firstName = "", lastName = "", address = "", phoneNumber = "", image = "", email = "", password = "";
            if (clsAdminData.FindAdminData(AdminID, ref firstName, ref lastName, ref permission, ref address, ref phoneNumber, ref image, ref email, ref password))
            {
                return new clsAdmin(AdminID, firstName, lastName, permission, address, phoneNumber, image, email, password);
            }
            return null;
        }

        public static clsAdmin FindAdminByEmail(string email)
        {
            int adminID = -1, permission = 0;
            string firstName = "", lastName = "", address = "", phoneNumber = "", image = "", password = "";
            if (clsAdminData.FindAdminDataByEmail(ref adminID, ref firstName, ref lastName, ref permission, ref address, ref phoneNumber, ref image, email, ref password))
            {
                return new clsAdmin(adminID, firstName, lastName, permission, address, phoneNumber, image, email, password);
            }
            return null;
        }

        public static bool RemoveAdmin(int AdminID)
        {
            return clsAdminData.DeleteAdminData(AdminID);
        }

        public static bool IsAdminExist(string Email)
        {
            return clsAdminData.ISAdminExistData(Email);
        }

        public static DataTable GetAllAdmin()
        {
            return clsAdminData.GetAllAdminsData();
        }
    }
}
