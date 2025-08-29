using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLayer
{
    public class clsOrderItems
    {
        private enum _enMode { AddNew = 1, UpdateMode = 2 };
        private _enMode _Mode = _enMode.AddNew;
        public int ItemID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public double TotalItemPrice { get; set; }

        public clsOrderItems()
        {
            ItemID = 0;
            OrderID = 0;
            ProductID = 0;
            Quantity = 0;
            Price = 0;
            TotalItemPrice = 0;
            _Mode = _enMode.AddNew;
        }

        private clsOrderItems(int itemID, int orderID, int productId, int quantity, double price, double totalItemPrice)
        {
            ItemID = itemID;
            OrderID = orderID;
            ProductID = productId;
            Quantity = quantity;
            Price = price;
            TotalItemPrice = totalItemPrice;
            _Mode = _enMode.UpdateMode;
        }

        private bool _AddNewOrderItems()
        {
            int ID = clsOrderItemsData.AddNewOrderItemsData(OrderID, ProductID, Quantity);
            return (ID > 0);
        }

        private bool _UpdateOrderItems()
        {
            return clsOrderItemsData.UpdateOrderItemsStatus(ItemID, ProductID, Quantity);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode.AddNew:
                    if (_AddNewOrderItems())
                    {
                        _Mode = _enMode.UpdateMode;
                        return true;
                    }
                    return false;
                case _enMode.UpdateMode:
                    return _UpdateOrderItems();
            }
            return false;
        }

        public static clsOrderItems FindOrderItems(int OrderID)
        {

            int itemID = -1, productId = -1,  quantity = -1;
            double price = 0, totalItemPrice = 0;
            if (clsOrderItemsData.FindOrderItemsData(ref itemID, OrderID, ref productId, ref quantity, ref price, ref totalItemPrice))
            {
                return new clsOrderItems(itemID, OrderID, productId, quantity, price, totalItemPrice);
            }
            return null;
        }


        public static bool RemoveOrderItems(int ItemID)
        {
            return clsOrderItemsData.DeleteOrderItemsData(ItemID);
        }



        public static DataTable GetAllOrderItems(int OrderID)
        {
            return clsOrderItemsData.GetAllOrderItemsData(OrderID);
        }
    }
}
