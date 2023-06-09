﻿using EmpClient.Api;
using EmpClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using static System.Net.Mime.MediaTypeNames;

namespace EmpClient.Controllers
{
    public class EmployeesController : Controller
    {
        private int deffaultSize = 1;
        // GET: Employees

        public ActionResult Index(int? page)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            int number = (page ?? 1);
            var emps = EmployeesApi.GetEmployeesWithOrgAndManager();

            if (emps == null || emps.Count == 0)
            {
                emps = new List<Employee>();
            }

            return View(emps.ToPagedList(number, deffaultSize));
        }

        public ActionResult IndexChildren(int? page, int? ManagerID)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            if (ManagerID == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.ManagerID = ManagerID;

            int number = (page ?? 1);
            var emps = EmployeesApi.GetChilrensByManagerID((int)ManagerID);

            if (emps == null || emps.Count == 0)
            {
                emps = new List<Employee>();
            }

            return View(emps.ToPagedList(number, deffaultSize));
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            return View(EmployeesApi.GetEmployeeById((int) id));
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            AddAllViewBagSelectList(new Employee(), "");

            return View(new Employee());
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee obj)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            AddAllViewBagSelectList(obj, "");
            try
            {
                Employee nEmp = EmployeesApi.InsertEmployee(obj);
                if (!nEmp.Equals(new Employee()))
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
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var emloyee = EmployeesApi.GetEmployeeById((int)id);
            AddAllViewBagSelectList(emloyee, "");

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            return View(emloyee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee obj, int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            if (id == null)
            {
                return RedirectToAction("Index");
            }
            AddAllViewBagSelectList(obj, "edit");

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
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            return Details(id);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

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

        private void AddAllViewBagSelectList (Employee employee, string method)
        {
            Employee emp = new Employee();
            emp.FirstName = "Choose manager for this employee!";

            var lEmps = EmployeesApi.GetEmployees();
            lEmps.Reverse();
            lEmps.Add(emp);
            lEmps.Reverse();

            var newSelectLEmps = lEmps.AsQueryable().Select(s =>
            new
            {
                Text = s.FirstName + " " + s.LastName,
                Value = s.EmployeeID,
                Selected = s.EmployeeID == employee.EmployeeID ? true : false
            }).ToList();

            if (method == "edit")
            {
                newSelectLEmps = lEmps.AsQueryable().Where(w => w.EmployeeID != employee.EmployeeID && w.ManagerID != employee.EmployeeID).Select(s =>
                new
                {
                    Text = s.FirstName + " " + s.LastName,
                    Value = s.EmployeeID,
                    Selected = s.EmployeeID == employee.EmployeeID ? true : false
                }).ToList();
            }

            SelectList empSelectList = new SelectList(newSelectLEmps, "Value", "Text", "Selected");
            ViewBag.Employees = empSelectList;

            Organization org = new Organization();
            org.OrganizationName = "Choose organization for this employee!";

            List<Organization> lOrgs = OrganizationApi.GetOrganizations();
            lOrgs.Reverse();
            lOrgs.Add(org);
            lOrgs.Reverse();

            var newSelectLOrgs = lOrgs.AsQueryable().Select(s =>
            new
            {
                Text = s.OrganizationName,
                Value = s.OrganizationID,
                Selected = s.OrganizationID == employee.OrganizationID ? true : false
            }).ToList();

            SelectList orgSelectList = new SelectList(newSelectLOrgs, "Value", "Text", "Selected");
            ViewBag.Organizations = orgSelectList;
        }
    }
}
