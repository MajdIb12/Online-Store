using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DataAccessLayer
{
    public class clsAdminData
    {
        public static bool FindAdminData(int AdminID, ref string FirstName, ref string LastName, ref int Permission, ref string Address,
            ref string PhoneNumber, ref string Image, ref string Email, ref string Password)
        {
            bool Found = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_FindAdmin", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AdminID", AdminID);
                try
                {
                    conn.Open();
                    SqlDataReader Reader = cmd.ExecuteReader();
                    if (Reader.Read())
                    {
                        Found = true;
                        FirstName = (string)Reader["FirstName"];
                        LastName = (string)Reader["LastName"];
                        Permission = (int)Reader["Permission"];
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
                catch {  }
                
            }
            return Found;
        }


        public static bool FindAdminDataByEmail(ref int AdminID, ref string FirstName, ref string LastName, ref int Permission, ref string Address,
            ref string PhoneNumber, ref string Image, string Email, ref string Password)
        {
            bool Found = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_FindAdminByEmail", conn);
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
                        Permission = (int)Reader["Permission"];
                        Address = (string)Reader["Address"];
                        PhoneNumber = (string)Reader["PhoneNumber"];
                        if (Reader["Image"] != DBNull.Value)
                        {
                            Image = (string)Reader["Image"];
                        }
                        AdminID = (int)Reader["AdminID"];
                        Password = (string)Reader["Password"];
                    }
                }
                catch { }

            }
            return Found;
        }
        public static int AddNewAdminData(string FirstName,  string LastName,  int Permission,  string Address,
             string PhoneNumber,  string Image,  string Email,  string Password)
        {
            int ID = -1;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_AddNewAdmin", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@Permission", Permission);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                if (!string.IsNullOrEmpty(Image))
                    cmd.Parameters.AddWithValue("@Image", Image);
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

        public static bool UpdateAdminData(int AdminID,string FirstName, string LastName, int Permission, string Address,
             string PhoneNumber, string Image, string Email, string Password)
        {
            bool Result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateAdminInfo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AdminID", AdminID);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@Permission", Permission);
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
                    int RowAffected =  cmd.ExecuteNonQuery();
                    if (RowAffected > 0) { Result = true; }
                    

                }
                catch { }
                

            }
            return Result;
        }

        public static bool DeleteAdminData(int AdminID)
        {
            bool Result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteAdmin", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AdminID", AdminID);
                try
                {
                    conn.Open();
                    int RowAffected = cmd.ExecuteNonQuery();
                    if (RowAffected > 0) { Result = true; }

                }catch { }
            }   
            return Result;
        }

        public static bool ISAdminExistData(string Email)
        {
            bool Result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_IsAdminExist", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", Email);
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

        public static DataTable GetAllAdminsData()
        {
            DataTable result = new DataTable();
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                string Query = "Select * from Admins";
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
