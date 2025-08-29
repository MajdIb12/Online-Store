using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsOrderData
    {
        public static bool FindOrderData(int OrderID, ref int CustomerID, ref DateTime OrderDate, ref double OrderPrice, ref byte Status)
        {
            bool Found = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_FindOrder", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", OrderID);
                try
                {
                    conn.Open();
                    SqlDataReader Reader = cmd.ExecuteReader();
                    if (Reader.Read())
                    {
                        Found = true;
                        CustomerID = (int)Reader["CustomerID"];
                        OrderDate = (DateTime)Reader["OrderDate"];
                        OrderPrice = Convert.ToDouble(Reader["OrderPrice"]);
                        Status = Convert.ToByte(Reader["Status"]);
                    }
                }
                catch { }

            }
            return Found;
        }


        
        public static int AddNewOrderData(int CustomerID)
        {
            int ID = -1;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_AddNewOrder", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
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

        public static bool UpdateOrderStatusData(int OrderID, int Status)
        {
            bool Result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateOrderStatus", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", OrderID);
                cmd.Parameters.AddWithValue("@Status", Status);


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

        public static bool DeleteOrderData(int OrderID)
        {
            bool Result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteOrder", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", OrderID);
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

        public static bool ISOrderExistData(int OrderID)
        {
            bool Result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_IsOrderExist", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", OrderID);
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

        public static DataTable GetAllOrdersData()
        {
            DataTable result = new DataTable();
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                string Query = "Select * from Orders";
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

        public static DataTable GetAllOrdersDataByCustomer(int CustomerID)
        {
            DataTable result = new DataTable();
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                string Query = "Select * from Orders where CustomerID = @CustomerID";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
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

        public static int IsCustomerHaveOrderPendingData(int CustomerID)
        {
            int ID = -1;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_IsCustomerHaveOrderPending", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                
                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        ID = insertedID;
                    }

                }
                catch { }


            }
            return ID;
        }

        public static double GetPriceOfOrderData(int OrderID)
        {
            double Price = 0;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                string Query = @"SELECT sum(OrderItems.TotalItemPrice)
                                    FROM     Orders INNER JOIN
                                     OrderItems ON Orders.OrderID = OrderItems.OrderID
                                     where Orders.OrderID = @OrderID ";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@OrderID", OrderID);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && double.TryParse(result.ToString(), out double Prices))
                    {
                        Price = Prices;
                    }

                    

                }
                catch { }


            }
            return Price;
        }
    }
}
