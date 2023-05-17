using EmpClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Api
{
    public class OrderDetailApi
    {
        public static List<OrderDetail> GetOrders()
        {
            string endPoint = "api/OrderDetails";
            List<OrderDetail> ords = ApiTemplate.GetByEndPoint<List<OrderDetail>>(endPoint);

            return ords;
        }

        public static List<OrderDetail> GetOrderDetailsWithAllByOrderID(int id)
        {
            string endPoint = "api/OrderDetailsWithAll?id="+id;
            List<OrderDetail> ords = ApiTemplate.GetByEndPoint<List<OrderDetail>>(endPoint);

            return ords;
        }

    }
}