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
        public static List<Category> GetSystemFeedbacks()
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Feedbacks/System";
            string resStrCats = resClient.RestRequestAll();
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(resStrCats);

            return categories;
        }
    }
}