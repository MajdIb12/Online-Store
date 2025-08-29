using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLayer
{
    public class clsCustomer
    {
        private enum _enMode { AddNew = 1, UpdateMode = 2 };
        private _enMode _Mode = _enMode.AddNew;
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public clsCustomer()
        {
            CustomerID = -1;
            FirstName = string.Empty;
            LastName = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            Address = string.Empty;
            PhoneNumber = string.Empty;
            Image = string.Empty;
            _Mode = _enMode.AddNew;
        }

        private clsCustomer(int customerID, string firstName, string lastName, string address, string phoneNumber, string image, string email, string password)
        {
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            Image = image;
            Email = email;
            Password = password;
            _Mode = _enMode.UpdateMode;
        }

        private bool _AddNewCustomer()
        {
            int ID = clsCustomerData.AddNewCustomerData(FirstName, LastName,  Address, PhoneNumber, Image, Email, Password);
            return (ID > 0);
        }

        private bool _UpdateCustomer()
        {
            return clsCustomerData.UpdateCustomerData(CustomerID, FirstName, LastName, Address, PhoneNumber, Image, Email, Password);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode.AddNew:
                    if (_AddNewCustomer())
                    {
                        _Mode = _enMode.UpdateMode;
                        return true;
                    }
                    return false;
                case _enMode.UpdateMode:
                    return _UpdateCustomer();
            }
            return false;
        }

        public static clsCustomer FindCustomer(int CustomerID)
        {
            
            string firstName = "", lastName = "", address = "", phoneNumber = "", image = "", email = "", password = "";
            if (clsCustomerData.FindCustomerData(CustomerID, ref firstName, ref lastName,ref address, ref phoneNumber, ref image, ref email, ref password))
            {
                return new clsCustomer(CustomerID, firstName, lastName, address, phoneNumber, image, email, password);
            }
            return null;
        }

        public static clsCustomer FindCustomerByEmail(string email)
        {
            int CustomerID = -1;
            string firstName = "", lastName = "", address = "", phoneNumber = "", image = "", password = "";
            if (clsCustomerData.FindCustomerDataByEmail(ref CustomerID, ref firstName, ref lastName, ref address, ref phoneNumber, ref image, email, ref password))
            {
                return new clsCustomer(CustomerID, firstName, lastName, address, phoneNumber, image, email, password);
            }
            return null;
        }

        public static bool RemoveCustomer(int CustomerID)
        {
            return clsCustomerData.DeleteCustomerData(CustomerID);
        }

        public static bool IsCustomerExist(int CustomerID)
        {
            return clsCustomerData.ISCustomerExistData(CustomerID);
        }

        public static DataTable GetAllCustomer()
        {
            return clsCustomerData.GetAllCustomersData();
        }
    }
}
