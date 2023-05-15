using EmpClient.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Api
{
    public class ProductApi
    {
        public static List<Product> GetProducts()
        {
            string endPoint = "api/Products";
            List<Product> products = ApiTemplate.GetByEndPoint<List<Product>>(endPoint);

            return products;
        }

        public static List<Product> GetProductsWithAll()
        {
            string endPoint = "api/ProductsWithAll";
            List<Product> products = ApiTemplate.GetByEndPoint<List<Product>>(endPoint);

            return products;
        }

        public static Product GetProductByID(int id)
        {
            string endPoint = "api/Products?id=" + id;
            Product products = ApiTemplate.GetByEndPoint<Product>(endPoint);

            return products;
        }

        public static Product InsertProduct(Product prd)
        {
            string endPoint = "api/Products";
            Product product = ApiTemplate.InserObjByEndPoint<Product>(endPoint, prd);

            return product;
        }

        public static bool UpdateProduct(int id, Product prd)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Products?id=" + id;
            bool isSuccess = resClient.UpdateData(prd);

            return isSuccess;
        }

        public static bool DeleteProduct(int id)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Products?id=" + id;
            bool isSuccess = resClient.DeleteData();

            return isSuccess;
        }
    }
}