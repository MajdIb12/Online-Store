using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsProductImagesData
    {
       

        public static int AddNewProductImageData(string ImageURl, int ProductID, int ImageOrder)
        {
            int ID = -1;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_AddProductImage", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ImageURl", ImageURl);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@ImageOrder", ImageOrder);
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

        public static bool UpdateProductImageData(int ImageID, string ImageURl, int ProductID, int ImageOrder)
        {
            bool Result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateProductImage", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ImageID", ImageID);
                cmd.Parameters.AddWithValue("@ImageURl", ImageURl);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@ImageOrder", ImageOrder);

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

        public static bool DeleteproductImagesData(int ProductID)
        {
            bool Result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteProductImages", conn);
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

        

        public static DataTable GetAllProductImagesDataByProductID(int ProductID)
        {
            DataTable result = new DataTable();
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                string Query = "Select * from ProductImages where ProductID = @ProductID order by ImageOrder";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
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
