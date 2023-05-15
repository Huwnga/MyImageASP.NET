using EmpClient.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Api
{
    public class FeedbackApi
    {
        public static List<Feedback> GetFeedbacks()
        {
            string endPoint = "api/Feedbacks";
            List<Feedback> fbs = ApiTemplate.GetByEndPoint<List<Feedback>>(endPoint);

            return fbs;
        }
        public static List<Feedback> GetSystemFeedbacks()
        {
            string endPoint = "api/Feedbacks/System";
            List<Feedback> fbs = ApiTemplate.GetByEndPoint<List<Feedback>>(endPoint);

            return fbs;
        }
        public static List<Feedback> GetProductFeedbacks(int ProductID)
        {
            string endPoint = "api/Feedbacks/Product?productID=" + ProductID;
            List<Feedback> fbs = ApiTemplate.GetByEndPoint<List<Feedback>>(endPoint);

            return fbs;
        }
        public static List<Feedback> GetFeedbacksWithAll()
        {
            string endPoint = "api/FeedbacksWithAll";
            List<Feedback> fbs = ApiTemplate.GetByEndPoint<List<Feedback>>(endPoint);

            return fbs;
        }
    }
}