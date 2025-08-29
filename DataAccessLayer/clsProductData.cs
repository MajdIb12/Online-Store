using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsProductData
    {
        public static bool FindProductData(int ProductID, ref string ProductName, ref string ProductDescription, ref double Price,
            ref int Quantity, ref int CreatedByAdmin, ref int CategoryID)
        {
            bool Found = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_FindProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                try
                {
                    conn.Open();
                    SqlDataReader Reader = cmd.ExecuteReader();
                    if (Reader.Read())
                    {
                        Found = true;
                        ProductName = (string)Reader["ProductName"];
                        ProductDescription = (string)Reader["ProductDescription"];
                        Price = Convert.ToDouble(Reader["Price"]);
                        Quantity = (int)Reader["Quantity"];
                        CreatedByAdmin = (int)Reader["CreatedByAdmin"];
                        CategoryID = (int)Reader["CategoryID"];
                    }
                }
                catch { }

            }
            return Found;
        }

        public static int AddNewProductData( string ProductName,  string ProductDescription,  double Price,
             int Quantity, int CreatedByAdmin,  int CategoryID)
        {
            int ID = -1;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_AddNewProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductName", ProductName);
                cmd.Parameters.AddWithValue("@ProductDescription", ProductDescription);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@Quantity", Quantity);
                cmd.Parameters.AddWithValue("@CreatedByAdmin", CreatedByAdmin);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
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

        public static bool UpdateProductData(int ProductID, string ProductName, string ProductDescription, double Price,
             int Quantity, int CreatedByAdmin, int CategoryID)
        {
            bool Result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateProductInfo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@ProductName", ProductName);
                cmd.Parameters.AddWithValue("@ProductDescription", ProductDescription);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@Quantity", Quantity);
                cmd.Parameters.AddWithValue("@CreatedByAdmin", CreatedByAdmin);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);

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

        public static bool DeleteproductData(int ProductID)
        {
            bool Result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
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

        public static bool ISProductExistData(int ProductID)
        {
            bool Result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_IsProductExist", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
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

        public static DataTable GetPageOfProductDataByCategotyID(int CategoryID, short PageNumber)
        {
            DataTable result = new DataTable();
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                string Query = @"Select * from ProductManagment where CategoryID = @CategoryID
                                  order by ProductID
                                  Offset (@PageNumber - 1) * 3 ROWS
                                  Fetch NEXT 3 ROWS ONLY";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
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

        public static DataTable GetAllProductDataByCategotyID()
        {
            DataTable result = new DataTable();
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                string Query = @"Select * from ProductManagment";
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

        public static bool IsHaveSameProductNameData(string Name)
        {
            bool result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                string Query = "Select 1 from ProductManagment where @ProductName = ProductName";
                SqlCommand Command = new SqlCommand(Query, conn);
                Command.Parameters.AddWithValue("@ProductName", Name);
                try
                {
                    conn.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    result = Reader.HasRows;
                    Reader.Close();
                }catch { }
                return result;
            }
        }


        public static bool IsProductCanDeletedData(int Name)
        {
            bool result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                string Query = @"SELECT 1
FROM     ProductManagment INNER JOIN
                  OrderItems ON ProductManagment.ProductID = OrderItems.ProductID
				  where ProductManagment.ProductID = @ProductID";
                SqlCommand Command = new SqlCommand(Query, conn);
                Command.Parameters.AddWithValue("@ProductID", Name);
                try
                {
                    conn.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    result = Reader.HasRows;
                    Reader.Close();
                }
                catch { }
                return result;
            }
        }
    }
}
