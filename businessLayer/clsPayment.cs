using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLayer
{
    public class clsPayment
    {

        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public clsOrder Order;
        public int PaymentMethodID { get; set; }
        public DateTime TransactionDate { get; set; }
        public double Amount { get; set; }

       

        public clsPayment()
        {
            PaymentID = 0;
            OrderID = 0;
            PaymentMethodID = 0;
            TransactionDate = DateTime.Now;
            Amount = 0;
        }

        private clsPayment(int paymentID, int orderID, int paymentMethodID, DateTime transactiondate, double amount)
        {
            PaymentID = paymentID;
            OrderID = orderID;
            Order = clsOrder.FindOrder(OrderID);
            PaymentMethodID = paymentMethodID;
            TransactionDate = transactiondate;
            Amount = amount;
        }

        public bool AddNewPayment()
        {
            int ID = clsPaymentData.AddNewPaymentData(OrderID, PaymentMethodID);
            if (ID > 0) { PaymentID = ID; return true; }
            return false;
        }

        public bool UpdatePayment()
        {
            return clsPaymentData.UpdatePaymentData(PaymentID, OrderID, PaymentMethodID);
        }

        public static clsPayment FindOrder(int orderID)
        {
            int paymentID = -1, paymentMethodID = -1;
            DateTime transactiondate = DateTime.Now;
            double amount = 0;
            if (clsPaymentData.FindPaymentDataByOrderID(ref paymentID, orderID, ref paymentMethodID, ref amount, ref transactiondate))
            {
                return new clsPayment(paymentID, orderID, paymentMethodID, transactiondate, amount);
            }
            return null;
        }


        public static bool RemovePayment(int PaymentID)
        {
            return clsPayment.RemovePayment(PaymentID);
        }


        public static DataTable GetAllPayment()
        {
            return clsPaymentData.GetAllPaymnetsData();
        }

        public static DataTable GetAllPaymentByID(int PaymentID)
        {
            return clsPaymentData.GetAllPaymnetsDataByID(PaymentID);
        }

        public static bool AddNewPaymentMethod(string MethodName)
        {
            int ID = clsPaymentMethodData.AddNewPaymentMethodData(MethodName);
            return (ID > 0);
        }

        public static bool RemovePaymentMethod(int PaymentID)
        {
            return clsPaymentMethodData.DeletePaymentMethodData(PaymentID);
        }

        public static DataTable GetAllPaymnetMethod()
        {
            return clsPaymentMethodData.GetAllPaymnetsData();
        }
    }
}
