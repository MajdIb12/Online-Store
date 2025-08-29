using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsCustomerData
    {
        public static bool FindCustomerData(int CustomerID, ref string FirstName, ref string LastName, ref string Address,
            ref string PhoneNumber, ref string Image, ref string Email, ref string Password)
        {
            bool Found = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_FindCustomer", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                try
                {
                    conn.Open();
                    SqlDataReader Reader = cmd.ExecuteReader();
                    if (Reader.Read())
                    {
                        Found = true;
                        FirstName = (string)Reader["FirstName"];
                        LastName = (string)Reader["LastName"];
                        Address = (string)Reader["Address"];
                        PhoneNumber = (string)Reader["PhoneNumber"];
                        if (Reader["Image"] != DBNull.Value)
                        {
                            Image = (string)Reader["Image"];
                        }
                        Email = (string)Reader["Email"];
                        Password = (string)Reader["Password"];
                    }
                }
                catch { }

            }
            return Found;
        }


        public static bool FindCustomerDataByEmail(ref int CustomerID, ref string FirstName, ref string LastName, ref string Address,
            ref string PhoneNumber, ref string Image, string Email, ref string Password)
        {
            bool Found = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_FindCustomerByEmail", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", Email);
                try
                {
                    conn.Open();
                    SqlDataReader Reader = cmd.ExecuteReader();
                    if (Reader.Read())
                    {
                        Found = true;
                        FirstName = (string)Reader["FirstName"];
                        LastName = (string)Reader["LastName"];
                        Address = (string)Reader["Address"];
                        PhoneNumber = (string)Reader["PhoneNumber"];
                        if (Reader["Image"] != DBNull.Value)
                        {
                            Image = (string)Reader["Image"];
                        }
                        CustomerID = (int)Reader["CustomerID"];
                        Password = (string)Reader["Password"];
                    }
                }
                catch { }

            }
            return Found;
        }
        public static int AddNewCustomerData(string FirstName, string LastName, string Address,
             string PhoneNumber, string Image, string Email, string Password)
        {
            int ID = -1;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_AddNewCustomer", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                if (!string.IsNullOrEmpty(Image))
                {
                    cmd.Parameters.AddWithValue("@Image", Image);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Image", DBNull.Value);
                }
                    
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);
                SqlParameter IDParam = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Output
                };
                cmd.Parameters.Add(IDParam);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    ID = (int)cmd.Parameters["@ID"].Value;

                }
                catch { }


            }
            return ID;
        }

        public static bool UpdateCustomerData(int CustomerID, string FirstName, string LastName, string Address,
             string PhoneNumber, string Image, string Email, string Password)
        {
            bool Result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateCustomerInfo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                if (!string.IsNullOrEmpty(Image))
                    cmd.Parameters.AddWithValue("@Image", Image);
                else
                    cmd.Parameters.AddWithValue("@Image", "");
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);


                try
                {
                    conn.Open();
                    int RowAffected = cmd.ExecuteNonQuery();
                    if (RowAffected > 0) { Result = true; }


                }
                catch { }


            }
            return Result;
        }

        public static bool DeleteCustomerData(int CustomerID)
        {
            bool Result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteCustomer", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                try
                {
                    conn.Open();
                    int RowAffected = cmd.ExecuteNonQuery();
                    if (RowAffected > 0) { Result = true; }

                }
                catch { }
            }
            return Result;
        }


        public static bool ISCustomerExistData(int CustomerID)
        {
            bool Result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_IsCustomerExist", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                try
                {
                    conn.Open();
                    int RowAffected = (int)cmd.ExecuteScalar();
                    if (RowAffected > 0) { Result = true; }

                }
                catch { }
            }
            return Result;
        }
        public static DataTable GetAllCustomersData()
        {
            DataTable result = new DataTable();
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                string Query = "Select * from Customers";
                SqlCommand cmd = new SqlCommand(Query, conn);
                try
                {
                    conn.Open();
                    SqlDataReader Reader = cmd.ExecuteReader();
                    result.Load(Reader);

                }
                catch { }
            }
            return result;
        }
    }
}
