using EmpClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Api
{
    public class CustomerApi
    {
        public static List<Customer> GetCustomers ()
        {
            string endPoint = "api/Customers";
            List<Customer> cuss = ApiTemplate.GetByEndPoint<List<Customer>>(endPoint);

            return cuss;
        }
    }
}