using CusClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace CusClient.Api
{
    public class ProductApi
    {
        public static IPagedList<ProductSize> GetProducts(int? pageNumber, int? pageSize)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Products?pageNumber=" + pageNumber + " && pageSize=" + pageSize;
            string resStrProducts = resClient.RestRequestAll();
            IPagedList<ProductSize> productSizes = JsonConvert.DeserializeObject<IPagedList<ProductSize>>(resStrProducts);

            return productSizes;
        }

        public static IPagedList<ProductSize> GetProductsByCategoryID(int CategoryID, int? pageNumber, int? pageSize)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Products/Category?categoryID=" + CategoryID + " && pagenumber=" + pageNumber + " && pageSize=" + pageSize;
            string resStrProducts = resClient.RestRequestAll();
            IPagedList<ProductSize> productSizes = JsonConvert.DeserializeObject<IPagedList<ProductSize>>(resStrProducts);

            return productSizes;
        }
        public static IPagedList<ProductSize> GetProductsBestSealer(int? pageNumber, int? pageSize)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Products/BestSealer?pageNumber=" + pageNumber + " && pageSize=" + pageSize;
            string resStrProducts = resClient.RestRequestAll();
            IPagedList<ProductSize> productSizes = JsonConvert.DeserializeObject<IPagedList<ProductSize>>(resStrProducts);

            return productSizes;
        }
        public static IPagedList<ProductSize> GetProductsLowerPrice(int? pageNumber, int? pageSize)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Products/LowerPrice?pageNumber=" + pageNumber + " && pageSize=" + pageSize;
            string resStrProducts = resClient.RestRequestAll();
            IPagedList<ProductSize> productSizes = JsonConvert.DeserializeObject<IPagedList<ProductSize>>(resStrProducts);

            return productSizes;
        }
    }
}