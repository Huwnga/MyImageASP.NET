using CusClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CusClient.Api
{
    public class EmployeesApi
    {
        public static List<Employee> GetEmployees()
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Employees";
            string resStrCats = resClient.RestRequestAll();
            List<Employee> emps = JsonConvert.DeserializeObject<List<Employee>>(resStrCats);

            return emps;
        }

        public static Employee GetEmployeeById(int id)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Employees?id=" + id;
            string resStrCats = resClient.RestRequestAll();
            Employee emps = JsonConvert.DeserializeObject<Employee>(resStrCats);

            return emps;
        }

        public static bool InsertEmployee(Employee emp)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Employees";
            bool isSuccess = resClient.InsertData(emp);

            return isSuccess;
        }

        public static bool UpdateEmployee(int id, Employee emp)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Employees?id=" + id;
            bool isSuccess = resClient.UpdateData(emp);

            return isSuccess;
        }

        public static bool DeleteEmployee(int id)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Employees?id=" + id;
            bool isSuccess = resClient.DeleteData();

            return isSuccess;
        }
    }
}