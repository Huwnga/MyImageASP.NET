using EmpClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpClient.Api
{
    public class EmployeesApi
    {
        public static List<Employee> GetAllEmployees()
        {
            ResClient rClient = new ResClient();
            rClient.EndPoint = "api/Employees";
            string KetQua = rClient.RestRequestAll();
            List<Employee> EmpList = JsonConvert.DeserializeObject<List<Employee>>(KetQua);
            return EmpList;
        }


        // GET: Employees/Details/5
        public static Employee GetEmployeesByID(int id)
        {
            ResClient rClient = new ResClient();
            rClient.EndPoint = "api/Employees?EmployeeID=" + id;
            string KetQua = rClient.RestRequestAll();
            List<Employee> EmpId = JsonConvert.DeserializeObject<List<Employee>>(KetQua);
            return EmpId[0];
        }

        // POST: Employees/Create
        
        public static int CreateEmployee(Employee obj)
        {
            ResClient rClient = new ResClient();

            //truyen qua obj
            rClient.EndPoint = "api/Employees";
            int KQ = rClient.InsertData(obj);

            if (KQ == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        // POST: Employees/Edit/5
        
        public static int UpdateEmployee(Employee obj, int id)
        {
            ResClient rClient = new ResClient();
            
            //truyen qua obj
            rClient.EndPoint = "api/Employees/" + id;
            int KQ = rClient.UpdateData(obj);

            if (KQ == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        

        // POST: Employees/Delete/5
        public static int DeleteEmployee(int id)
        {
            ResClient rClient = new ResClient();

            //truyen qua obj
            rClient.EndPoint = "api/Employees/" + id;
            int KQ = rClient.DeleteData();

            if (KQ == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}