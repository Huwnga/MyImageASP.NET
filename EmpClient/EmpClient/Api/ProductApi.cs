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
        public static IPagedList<Product> GetProducts(int? pageNumber, int? pageSize)
        {
            string endPoint = "api/Products?pageNumber=" + pageNumber
                    + "&pageSize=" + pageSize;
            IPagedList<Product> products = ApiTemplate.GetByEndPoint<IPagedList<Product>>(endPoint);

            return products;
        }

        public static List<Product> GetProductsWithAll()
        {
            string endPoint = "api/ProductsWithAll";
            List<Product> products = ApiTemplate.GetByEndPoint<List<Product>>(endPoint);

            return products;
        }

        public static Product GetProductsWithAll(int id)
        {
            string endPoint = "api/Products?id=" + id;
            Product products = ApiTemplate.GetByEndPoint<Product>(endPoint);

            return products;
        }

        public static Organization GetOrganizationByID(int id)
        {
            string endPoint = "api/Organizations?id=" + id;
            Organization orgs = ApiTemplate.GetByEndPoint<Organization>(endPoint);

            return orgs;
        }

        public static Organization InsertOrganization(Organization org)
        {
            string endPoint = "api/Organizations";
            Organization organization = ApiTemplate.InserObjByEndPoint<Organization>(endPoint, org);

            return organization;
        }

        public static bool UpdateOrganization(int id, Organization org)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Organizations?id=" + id;
            bool isSuccess = resClient.UpdateData(org);

            return isSuccess;
        }

        public static bool DeleteOrganization(int id)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Organizations?id=" + id;
            bool isSuccess = resClient.DeleteData();

            return isSuccess;
        }
    }
}