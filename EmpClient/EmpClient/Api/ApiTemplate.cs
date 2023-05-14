using EmpClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Api
{
    public class ApiTemplate
    {
        public static T GetByEndPoint<T>(string endPoint)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = endPoint;
            string resStrObjs = resClient.RestRequestAll();

            if (!resStrObjs.StartsWith("Error:"))
            {
                T nObj = JsonConvert.DeserializeObject<T>(resStrObjs);

                return nObj;
            }

            return default(T);
        }

        public static T InserObjByEndPoint<T>(string endPoint, T obj)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = endPoint;
            string resStrObj = resClient.InsertData(obj);

            if (!resStrObj.StartsWith("Error:"))
            {
                T nObj = JsonConvert.DeserializeObject<T>(resStrObj);

                return nObj;
            }

            return default(T);
        }
    }
}