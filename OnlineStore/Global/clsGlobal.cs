using businessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace OnlineStore
{
    static class clsGlobal
    {
        public static clsAdmin AdminUser = new clsAdmin();

        public static clsCustomer CustomerUser = new clsCustomer();
        public  enum en_LoginUser {Admin = 1, Customer = 2}
        public static en_LoginUser LoginUser = en_LoginUser.Admin;

        
        public static bool IsAdmin(string Email, string Password)
        {
            clsAdmin Admin = clsAdmin.FindAdminByEmail(Email);
            if (Admin != null)
            {
                if (Admin.Password == Password)
                {
                    AdminUser = Admin;
                    LoginUser = en_LoginUser.Admin;
                    return true;
                }
            }
            return false;
        }

        public static bool IsCustomer(string Email, string Password)
        {
            clsCustomer Customer = clsCustomer.FindCustomerByEmail(Email);
            if (Customer != null)
            {
                if (Customer.Password == Password)
                {
                    CustomerUser = Customer;
                    LoginUser = en_LoginUser.Customer;
                    return true;
                }
            }
            return false;
        }

        public static string CombuteHash(string Input)
        {
            using(SHA256 sha256 = SHA256.Create())
            {
                byte[] hashByte = sha256.ComputeHash(Encoding.UTF8.GetBytes(Input));

                return BitConverter.ToString(hashByte).Replace("-", "").ToLower();
            }
        }

        public static void SaveRegistry(string Email, string Password)
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\OlineStore";
            try
            {
                Registry.SetValue(KeyPath, "Email", Email, RegistryValueKind.String);
                Registry.SetValue(KeyPath, "Password", Password, RegistryValueKind.String) ;
                
            }
            catch {  }
        }

        public static bool DeleteRegistry()
        {
            string keyPath = @"SOFTWARE\OlineStore";
            try
            {
                // Open the registry key in read/write mode with explicit registry view
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey key = baseKey.OpenSubKey(keyPath, true))
                    {
                        if (key != null)
                        {
                            // Delete the specified value
                            key.DeleteValue("Email");
                            key.DeleteValue("Password");
                            return true;
                        }
                    }
                }
            }
            catch { }
            return false;
        }

        public static bool GetAccountFromRegistry()
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\OlineStore";
            try
            {
                // Read the value from the Registry
                string Email = Registry.GetValue(KeyPath, "Email", null) as string;
                string Password = Registry.GetValue(KeyPath, "Password", null) as string;
                return (IsAdmin(Email, Password) || IsCustomer(Email, Password));
            }
            catch { return false; }
        }
    }
}
