using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLayer
{
    public class clsReview
    {
        private enum _enMode { AddNew = 1, UpdateMode = 2 };
        private _enMode _Mode = _enMode.AddNew;
        public int ReviewID { get; set; }
        public int ProductID { get; set; }
        public clsProduct Product;
        public int CustomerID { get; set; }
        public clsCustomer Customer;
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
        public double Rating { get; set; }



        public clsReview()
        {
            ReviewID = 0;
            ProductID = 0;
            CustomerID = 0;
            ReviewText = string.Empty;
            ReviewDate = DateTime.Now;
            Rating = 0;
            _Mode = _enMode.AddNew;
        }

        private clsReview(int reviewID, int productID, int customerID, string reviewText, DateTime reviewDate, double rating)
        {
            ReviewID = reviewID;
            ProductID = productID;
            Product = clsProduct.FindProduct(productID);
            CustomerID = customerID;
            Customer = clsCustomer.FindCustomer(customerID);
            ReviewText = reviewText;
            ReviewDate= reviewDate;
            Rating = rating;
            _Mode = _enMode.UpdateMode;
        }

        private bool _AddNewReview()
        {
            int ID = clsReviewsData.AddNewReviewData(ProductID, CustomerID, ReviewText, Rating);
            if (ID > 0) { ReviewID = ID; return true; }
            return false;
        }

        private bool _UpdateReview()
        {
            return clsReviewsData.UpdateReviewData(ReviewID, ReviewText, Rating);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode.AddNew:
                    if (_AddNewReview())
                    {
                        _Mode = _enMode.UpdateMode;
                        return true;
                    }
                    return false;
                case _enMode.UpdateMode:
                    return _UpdateReview();
            }
            return false;
        }

        public static clsReview FindReview(int productID, int customerID)
        {
            int reviewID = -1;
            string reviewText = "";
            DateTime reviewDate = DateTime.Now;
            double rating = 0;
            if (clsReviewsData.FindReview(ref reviewID, productID, customerID, ref reviewText, ref rating, ref reviewDate))
            {
                return new clsReview(reviewID, productID, customerID, reviewText, reviewDate, rating);
            }
            return null;
        }


        public static bool RemoveReview(int ReviewID)
        {
            return clsReviewsData.DeleteReviewData(ReviewID);
        }


        public static DataTable GetAllReviews(int ProductID)
        {
            return clsReviewsData.GetAllReviewsDataByProduct(ProductID);
        }

        public static int GetNumberOfReviewsByProduct(int ProductID)
        {
            return clsReviewsData.GetNumberOfReviewsByProductData(ProductID);
        }

        public static int GetAVGOfReviewsByProduct(int ProductID)
        {
            return clsReviewsData.GetAvgOfReviewsByProductData(ProductID);
        }
    }
}
