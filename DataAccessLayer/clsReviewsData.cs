using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsReviewsData
    {
        public static bool FindReview(ref int ReviewID, int ProductID,  int CustomerID,
            ref string ReviewText, ref double Rating, ref DateTime ReviewDate)
        {
            bool Found = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_FindReview", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                try
                {
                    conn.Open();
                    SqlDataReader Reader = cmd.ExecuteReader();
                    if (Reader.Read())
                    {
                        Found = true;
                        ProductID = (int)Reader["ReviewID"];
                        ReviewText = (string)Reader["ReviewText"];
                        ReviewDate = (DateTime)Reader["ReviewDate"];
                        Rating = (double)Reader["Rating"];
                    }
                }
                catch { }

            }
            return Found;
        }



        public static int AddNewReviewData(int ProductID, int CustomerID, string ReviewText, double Rating)
        {
            int ID = -1;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_AddNewReview", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmd.Parameters.AddWithValue("@ReviewText", ReviewText);
                cmd.Parameters.AddWithValue("@Rating", Rating);
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


        public static bool UpdateReviewData(int ReviewID, string ReviewText, double Rating)
        {
            bool result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateReview", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReviewID", ReviewID);
                cmd.Parameters.AddWithValue("@ReviewText", ReviewText);
                cmd.Parameters.AddWithValue("@Rating", Rating);
                try
                {
                    conn.Open();
                    int RowAffected = cmd.ExecuteNonQuery();
                    if (RowAffected > 0) { result = true; }


                }
                catch { }


            }
            return result;
        }
        public static bool DeleteReviewData(int ReviewID)
        {
            bool Result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteReview", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReviewID", ReviewID);
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


        public static DataTable GetAllReviewsDataByProduct(int ProductID)
        {
            DataTable result = new DataTable();
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                string Query = "Select * from Reviews where ProductID = @ProductID";
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

        public static int GetAvgOfReviewsByProductData(int ProductID)
        {
            int AVG = 0;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                string Query = "Select AVG(Rating) from Reviews where ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                try
                {
                    conn.Open();
                    object Data = cmd.ExecuteScalar();
                    if(int.TryParse(Data.ToString(), out int Result))
                    {
                        AVG = Result;
                    }
                    

                }
                catch { }
            }
            return AVG;
        }

        public static int GetNumberOfReviewsByProductData(int ProductID)
        {
            int AVG = 0;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                string Query = "Select count(Rating) from Reviews where ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                try
                {
                    conn.Open();
                    object Data = cmd.ExecuteScalar();
                    if (int.TryParse(Data.ToString(), out int Result))
                    {
                        AVG = Result;
                    }


                }
                catch { }
            }
            return AVG;
        }
    }
}
