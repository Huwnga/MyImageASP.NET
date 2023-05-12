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
            return View(EmployeesApi.GetEmployeesWithOrgAndManager());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            return View(EmployeesApi.GetEmployeeById((int) id));
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            List<Organization> lOrgs = OrganizationApi.GetOrganizations();
            ViewBag.Organization = new SelectList(lOrgs, "OrganizationID", "OrganizationName");

            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee obj)
        {
            try
            {
                Employee nEmp = EmployeesApi.InsertEmployee(obj);
                if (nEmp != null)
                {
                    TempData["SuccessMessage"] = "Add new employee with id: " + nEmp.EmployeeID + " successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Added faild!";
                    return View(obj);
                }
            }
            catch
            {
                return View(obj);
            }

        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            List<Organization> lOrgs = OrganizationApi.GetOrganizations();
            ViewBag.Organization = new SelectList(lOrgs, "OrganizationID", "OrganizationName");

            return Details(id);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee obj, int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            try
            {
                if (EmployeesApi.UpdateEmployee((int) id, obj))
                {
                    TempData["SuccessMessage"] = "Updated successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Updated faild!";
                    return View(obj);
                }
               
            }
            catch
            {
                return View(obj);
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            return Details(id);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            try
            {
                if (EmployeesApi.DeleteEmployee((int) id))
                {
                    TempData["SuccessMessage"] = "Deleted successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Deleted faild!";
                    return RedirectToAction("Delete", id);
                }

            }
            catch
            {
                return RedirectToAction("Delete", id);
            }
        }
    }
}
