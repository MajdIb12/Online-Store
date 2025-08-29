using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsOrderItemsData
    {
        public static bool FindOrderItemsData(ref int itemID, int OrderID, ref int ProductID, ref int Quantity, ref double Price, ref double TotalItemPrice)
        {
            bool Found = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_FindOrderItems", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", OrderID);
                try
                {
                    conn.Open();
                    SqlDataReader Reader = cmd.ExecuteReader();
                    if (Reader.Read())
                    {
                        Found = true;
                        itemID = (int)Reader["itemID"];
                        ProductID = (int)Reader["ProductID"];
                        Quantity = (int)Reader["Quantity"];
                        Price = (double)Reader["Price"];
                        TotalItemPrice = (double)Reader["TotalItemPrice"];
                    }
                }
                catch { }

            }
            return Found;
        }


        
        public static int AddNewOrderItemsData(int OrderID,  int ProductID,  int Quantity)
        {
            int ID = -1;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_AddNewOrderItem", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", OrderID);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@Quantity", Quantity);
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

        public static bool UpdateOrderItemsStatus(int ItemID, int ProductID, int Quantity)
        {
            bool Result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateOrderItemsInfo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemID", ItemID);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@Quantity", Quantity);


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

        public static bool DeleteOrderItemsData(int ItemID)
        {
            bool Result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteOrderItems", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemID", ItemID);
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

        public static bool ISOrderItemsExistData(int ItemID)
        {
            bool Result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_IsOrderItemsExist", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemID", ItemID);
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

        public static DataTable GetAllOrderItemsData(int OrderID)
        {
            DataTable result = new DataTable();
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                string Query = @"SELECT ProductManagment.ProductName, OrderItems.Quantity
                                   FROM     OrderItems INNER JOIN
                                   ProductManagment ON OrderItems.ProductID = ProductManagment.ProductID
				                      where OrderID = @OrderID";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@OrderID", OrderID);
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
