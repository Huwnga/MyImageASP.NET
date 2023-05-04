using CusClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CusClient.Api
{
    public class CategoriesApi
    {
        public static List<Category> GetCategories()
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Categories";
            string resStrCats = resClient.RestRequestAll();
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(resStrCats);

            return categories;
        }
    }
}