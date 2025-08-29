using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLayer
{
    public class clsShipping
    {
        public enum en_Status {  Processing = 1, OutforDelivery = 2 , Delivered = 3 ,ReturnToSender = 4 }
        public en_Status Status { get; set; }
        public int ShipmentID { get; set; }
        public int OrderID { get; set; }
        public clsOrder Order;
        public string CarrierName { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public DateTime ActualDeliveryData { get; set; }


        public clsShipping()
        {
            ShipmentID = 0;
            OrderID = 0;
            Status = en_Status.Processing;
            CarrierName = string.Empty;
            EstimatedDeliveryDate = DateTime.Now;
            ActualDeliveryData = DateTime.Now;
        }

        private clsShipping( int shipmentID, int orderID, string carrierName, en_Status status, DateTime estimatedDeliveryDate, DateTime actualDeliveryData)
        {
            Status = status;
            ShipmentID = shipmentID;
            OrderID = orderID;
            Order = clsOrder.FindOrder(orderID);
            CarrierName = carrierName;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            ActualDeliveryData = actualDeliveryData;
        }

        public bool AddNewShipment()
        {
            int ID = clsShippingData.AddNewShipping(OrderID, CarrierName, EstimatedDeliveryDate);
            if (ID > 0) { ShipmentID = ID; return true; }
            return false;
        }

        public bool UpdateShipmentStatus()
        {
            return clsShippingData.UpdateShipmentStatusData(ShipmentID, (byte)Status);
        }

        public static clsShipping FindShipmentByOrderID(int orderID)
        {
            int shipmentID = -1;
            string carrierName = "";
            byte status = 1;
            DateTime estimatedDeliveryDate = DateTime.Now, actualDeliveryData = DateTime.Now;
            if(clsShippingData.FindShippnigData(ref shipmentID, orderID, ref carrierName, ref status, ref estimatedDeliveryDate, ref actualDeliveryData))
            {
                return new clsShipping(shipmentID, orderID, carrierName, (en_Status)status, estimatedDeliveryDate, actualDeliveryData);
            }
            return null;
        }


        public static bool RemoveShipment(int ShipmentID)
        {
            return clsShippingData.DeleteShipmentData(ShipmentID);
        }


        public static DataTable GetAllShippings()
        {
            return clsShippingData.GetAllShippingsData();
        }
    }
}
