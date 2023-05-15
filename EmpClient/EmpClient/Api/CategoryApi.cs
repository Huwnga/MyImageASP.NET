using EmpClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Api
{
    public class CategoryApi
    {
        public static List<Category> GetCategorys()
        {
            string endPoint = "api/Categories";
            List<Category> categorys = ApiTemplate.GetByEndPoint<List<Category>>(endPoint);

            return categorys;
        }
        public static List<Category> GetCategoryById(int id)
        {
            string endPoint = "api/Categories?id=" + id;
            List<Category> categorys = ApiTemplate.GetByEndPoint<List<Category>>(endPoint);

            return categorys;
        }

        public static Category InsCat(Category obj)
        {
            string endPoint = "api/Categories";
            Category category = ApiTemplate.InserObjByEndPoint<Category>(endPoint, obj);

            return category;
        }

        public static bool UpdCat(int id, Category obj)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Categories?id=" + id;
            bool isSuccess = resClient.UpdateData(obj);

            return isSuccess;
        }

        public static bool DelCat(int id)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Categories?id=" + id;
            bool isSuccess = resClient.DeleteData();

            return isSuccess;
        }
    }
}