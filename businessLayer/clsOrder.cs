using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLayer
{
    public class clsOrder
    {
        

        public enum en_Status
        { Pending = 1, Processing = 2, Shipped = 3, Delivered = 4,Cancelled = 5, Refunded = 6 }
        
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderPrice { get; set; }
        

        public en_Status Status { get; set; }
        public string StatusText
        {
            get
            {
                switch (Status)
                {
                    case en_Status.Pending:
                        return "Pending";
                    case en_Status.Processing:
                        return "Processing";
                    case en_Status.Delivered:
                        return "Processing";
                    case en_Status.Cancelled:
                        return "cancelled";
                    case en_Status.Refunded:
                        return "Refunded";
                    case en_Status.Shipped:
                        return "Shipped";
                    default:
                        return "Unkown";
                }
            }
        }

        public clsOrder()
        {
            OrderID = 0;
            CustomerID = 0;
            OrderDate = DateTime.Now;
            OrderPrice = 0;
            Status = en_Status.Pending;

        }

        private clsOrder(int orderID, int customerID, DateTime orderdate, double orderPrice, en_Status status)
        {
            OrderID = orderID;
            CustomerID = customerID;
            OrderDate = orderdate;
            OrderPrice = clsOrderData.GetPriceOfOrderData(OrderID);
            Status = status;
        }

        public bool AddNewOrder()
        {
            int ID = clsOrderData.AddNewOrderData(CustomerID);
            if (ID > 0) { OrderID = ID; return true; }
            return false;
        }

      
        public bool UpdateOrderStatus()
        {
            return clsOrderData.UpdateOrderStatusData(OrderID, (int)Status);
        }

        

        public static clsOrder FindOrder(int OrderID)
        {
            int customerID = -1;
            DateTime orderdate = DateTime.Now;
            double orderPrice = 0;
            byte status = 1;
            if(clsOrderData.FindOrderData(OrderID, ref customerID, ref orderdate, ref orderPrice, ref status))
            {
                return new clsOrder(OrderID, customerID, orderdate, orderPrice, (en_Status)status);
            }
            return null;
        }


        public static bool RemoveOrder(int OrderID)
        {
            return clsOrderData.DeleteOrderData(OrderID);
        }

        public static DataTable GetAllOrders()
        {
            return clsOrderData.GetAllOrdersData();
        }

        public static DataTable GetAllOrderByCustomer(int CustomerID)
        {
            return clsOrderData.GetAllOrdersDataByCustomer(CustomerID);
        }

        public static clsOrder IsCustomerHaveOrderPending(int CustomerID)
        {
            int ID = clsOrderData.IsCustomerHaveOrderPendingData(CustomerID);
            if (ID > 0)
            {
                return clsOrder.FindOrder(ID);
            }
            return null;
        }
        
    }
}
