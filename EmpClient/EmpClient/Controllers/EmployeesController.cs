using EmpClient.Api;
using EmpClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpClient.Controllers
{
    public class EmployeesController : Controller
    {
        
        // GET: Employees
        
        public ActionResult Index()
        {
            return View(EmployeesApi.GetAllEmployees());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            return View(EmployeesApi.GetEmployeesByID(id));
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee obj)
        {
            try
            {

                if (EmployeesApi.CreateEmployee(obj) == 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }

        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            return View(EmployeesApi.GetEmployeesByID(id));
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee obj, int id)
        {
            try
            {
                if (EmployeesApi.UpdateEmployee(obj , id) == 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
               
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            return View(EmployeesApi.GetEmployeesByID(id));
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (EmployeesApi.DeleteEmployee(id) == 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }
    }
}
