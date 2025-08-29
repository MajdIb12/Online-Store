using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsShippingData
    {
        public static bool FindShippnigData(ref int ShipmentID, int OrderID, ref string CarrierName,  ref byte ShipmentStatus, ref DateTime EstimatedDeliveryDate, ref DateTime ActualDeliveryData)
        {
            bool Found = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_FindShippnigByOrderID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", OrderID);
                try
                {
                    conn.Open();
                    SqlDataReader Reader = cmd.ExecuteReader();
                    if (Reader.Read())
                    {
                        Found = true;
                        ShipmentID = (int)Reader["ShipmentID"];
                        CarrierName = (string)Reader["CarrierName"];
                        EstimatedDeliveryDate = (DateTime)Reader["EstimatedDeliveryDate"];
                        if (Reader["ActualDeliveryData"] == DBNull.Value)
                        {
                            ActualDeliveryData = DateTime.Now;
                        }
                        else
                        {
                            ActualDeliveryData = (DateTime)Reader["ActualDeliveryData"];
                        }
                        
                        ShipmentStatus = Convert.ToByte(Reader["ShipmentStatus"]);
                    }
                }
                catch { }

            }
            return Found;
        }



        public static int AddNewShipping(int OrderID, string CarrierName, DateTime EstimatedDeliveryDate)
        {
            int ID = -1;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_AddNewShipping", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", OrderID);
                cmd.Parameters.AddWithValue("@CarrierName", CarrierName);
                cmd.Parameters.AddWithValue("@EstimatedDeliveryDate", EstimatedDeliveryDate);
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


        public static bool UpdateShipmentStatusData(int ShipmentID, byte ShipmentStatus)
        {
            bool result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateShipmentStatus", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ShipmentID", ShipmentID);
                cmd.Parameters.AddWithValue("@ShipmentStatus", ShipmentStatus);
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
        public static bool DeleteShipmentData(int ShipmentID)
        {
            bool Result = false;
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteShipment", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ShipmentID", ShipmentID);
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


        public static DataTable GetAllShippingsData()
        {
            DataTable result = new DataTable();
            string Connectionstring = clsConnectionSettings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                string Query = "Select * from TrackingOrders";
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
