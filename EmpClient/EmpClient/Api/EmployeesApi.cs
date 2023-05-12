using EmpClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Api
{
    public class EmployeesApi
    {
        public static List<Employee> GetEmployees()
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Employees";
            string resStrEmps = resClient.RestRequestAll();
            List<Employee> emps = JsonConvert.DeserializeObject<List<Employee>>(resStrEmps);

            return emps;
        }

        public static List<Employee> GetEmployeesWithOrganization()
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/EmployeesWithOrg";
            string resStrEmps = resClient.RestRequestAll();
            List<Employee> emps = JsonConvert.DeserializeObject<List<Employee>>(resStrEmps);

            return emps;
        }

        public static List<Employee> GetEmployeesWithOrgAndManager()
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/EmployeesWithOrgAndManager";
            string resStrEmps = resClient.RestRequestAll();
            List<Employee> emps = JsonConvert.DeserializeObject<List<Employee>>(resStrEmps);

            return emps;
        }

        public static Employee GetEmployeeById(int id)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Employees?id=" + id;
            string resStrEmp = resClient.RestRequestAll();
            Employee emp = JsonConvert.DeserializeObject<Employee>(resStrEmp);

            return emp;
        }

        public static Employee InsertEmployee(Employee emp)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Employees";
            string resStrEmp = resClient.InsertData(emp);

            if(!resStrEmp.StartsWith("Error:"))
            {
                Employee nEmp = JsonConvert.DeserializeObject<Employee>(resStrEmp);

                return nEmp;
            }

            return null;
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