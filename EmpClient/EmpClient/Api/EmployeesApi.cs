using EmpClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace EmpClient.Api
{
    public class EmployeesApi
    {
        public static List<Employee> GetEmployees()
        {
            string endPoint = "api/Employees";
            List<Employee> emps = ApiTemplate.GetByEndPoint<List<Employee>>(endPoint);

            return emps;
        }

        public static List<Employee> GetEmployeesWithManager()
        {
            string endPoint = "api/EmployeesWithManager";
            List<Employee> emps = ApiTemplate.GetByEndPoint<List<Employee>>(endPoint);

            return emps;
        }

        public static List<Employee> GetEmployeesWithOrganization()
        {
            string endPoint = "api/EmployeesWithOrg";
            List<Employee> emps = ApiTemplate.GetByEndPoint<List<Employee>>(endPoint);

            return emps;
        }

        public static List<Employee> GetEmployeesWithOrgAndManager()
        {
            string endPoint = "api/EmployeesWithOrgAndManager";
            List<Employee> emps = ApiTemplate.GetByEndPoint<List<Employee>>(endPoint);

            return emps;
        }

        public static List<Employee> GetChilrensByManagerID(int ManagerID)
        {
            string endPoint = "api/EmployeesWithManager?managerID=" + ManagerID;
            List<Employee> emps = ApiTemplate.GetByEndPoint<List<Employee>>(endPoint);

            return emps;
        }

        public static Employee GetEmployeeById(int id)
        {
            string endPoint = "api/Employees?id=" + id;
            Employee emp = ApiTemplate.GetByEndPoint<Employee>(endPoint);

            return emp;
        }

        public static Employee InsertEmployee(Employee emp)
        {
            string endPoint = "api/Employees";
            Employee employee = ApiTemplate.InserObjByEndPoint<Employee>(endPoint, emp);

            return employee;
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