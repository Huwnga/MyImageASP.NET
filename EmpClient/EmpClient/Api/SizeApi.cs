using EmpClient.Api;
using EmpClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Api
{
    public class SizeApi
    {
        public static List<Size> GetSizes()
        {
            string endPoint = "api/Sizes";
            List<Size> sizes = ApiTemplate.GetByEndPoint<List<Size>>(endPoint);

            return sizes;
        }

        public static List<Size> GetSizesByProductID (int productID)
        {
            string endPoint = "api/Sizes?productID=" + productID;
            List<Size> sizes = ApiTemplate.GetByEndPoint<List<Size>>(endPoint);

            return sizes;
        }

        public static List<Size> GetSize(int id)
        {
            string endPoint = "api/Sizes?id=" + id;
            List<Size> sizes = ApiTemplate.GetByEndPoint<List<Size>>(endPoint);

            return sizes;
        }

        public static Size InsSize(Size size)
        {
            string endPoint = "api/Sizes";
            Size nSize = ApiTemplate.InserObjByEndPoint<Size>(endPoint, size);

            return nSize;
        }

        public static bool UpdSize (int id, Size size)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Sizes?id=" + id;
            bool isSuccess = resClient.UpdateData(size);

            return isSuccess;
        }

        public static bool DelSize(int id)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Sizes?id=" + id;
            bool isSuccess = resClient.DeleteData();

            return isSuccess;
        }
    }
}