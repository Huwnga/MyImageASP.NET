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

        public static List<Order> GetOrdersWithAll ()
        {
            string endPoint = "api/OrdersWithAll";
            List<Order> ords = ApiTemplate.GetByEndPoint<List<Order>>(endPoint);

            return ords;
        }

        public static List<Order> GetOrdersWithAllByCustomerID(int customerID)
        {
            string endPoint = "api/OrdersWithAll?customerID=" + customerID;
            List<Order> ords = ApiTemplate.GetByEndPoint<List<Order>>(endPoint);

            return ords;
        }

        public static List<Order> GetOrdersWithAllByEmployeeID(int employeeID)
        {
            string endPoint = "api/OrdersWithAll?employeeID=" + employeeID;
            List<Order> ords = ApiTemplate.GetByEndPoint<List<Order>>(endPoint);

            return ords;
        }

        public static Order GetOrder(int id)
        {
            string endPoint = "api/Orders?id=" + id;
            Order ord = ApiTemplate.GetByEndPoint<Order>(endPoint);

            return ord;
        }

        public static bool UpdOrd (int id, Order order)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Orders?id=" + id;
            bool isSuccess = resClient.UpdateData(order);

            return isSuccess;
        }

        public static bool DelOrd(int id)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Orders?id=" + id;
            bool isSuccess = resClient.DeleteData();

            return isSuccess;
        }
    }
}