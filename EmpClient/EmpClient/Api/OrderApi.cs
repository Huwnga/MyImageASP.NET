using EmpClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Api
{
    public class OrderApi
    {
        public static List<Order> GetOrders ()
        {
            string endPoint = "api/Orders";
            List<Order> ords = ApiTemplate.GetByEndPoint<List<Order>>(endPoint);

            return ords;
        }
    }
}