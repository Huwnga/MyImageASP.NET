using CusClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CusClient.Api
{
    public class FeedbackApi
    {
        public static List<Feedback> GetFeedbacks ()
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Feedbacks";
            string resStrFbs = resClient.RestRequestAll();
            List<Feedback> feedbacks = JsonConvert.DeserializeObject<List<Feedback>>(resStrFbs);

            return feedbacks;
        }

        public static List<Feedback> GetSystemFeedbacks()
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Feedbacks/System";
            string resStrFbs = resClient.RestRequestAll();
            List<Feedback> feedbacks = JsonConvert.DeserializeObject<List<Feedback>>(resStrFbs);

            return feedbacks;
        }
        
        public static List<Feedback> GetProductFeedbacks(int ProductID)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Feedbacks/Product?productID=" + ProductID;
            string resStrFbs = resClient.RestRequestAll();
            List<Feedback> feedbacks = JsonConvert.DeserializeObject<List<Feedback>>(resStrFbs);

            return feedbacks;
        }
    }
}