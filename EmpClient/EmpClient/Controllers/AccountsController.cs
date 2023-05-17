using EmpClient.Api;
using EmpClient.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpClient.Controllers
{
    public class AccountsController : Controller
    {
        private int deffaultSize = 25;
        public ActionResult Index(int? page)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            int number = (page ?? 1);
            var users = UserApi.GetUsersWithAll();

            if (users == null || users.Count == 0)
            {
                users = new List<User>();
            }

            return View(users.ToPagedList(number, deffaultSize));
        }

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

            return View(UserApi.GetUser((int)id));
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            AddAllViewBagSelectList(new User());

            return View(new User());
        }

        [HttpPost]
        public ActionResult Create(User obj)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            AddAllViewBagSelectList(obj);
            try
            {
                User nUser = UserApi.InsUser(obj);
                if (nUser != null)
                {
                    TempData["SuccessMessage"] = "Add new Material with id: " + nUser.UserID + " successfully!";
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

        public ActionResult Delete(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            return Details(id);
        }

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
                if (UserApi.DelUser((int)id))
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

        private void AddAllViewBagSelectList(User user)
        {
            Employee emp = new Employee();
            emp.FirstName = "Choose employee for this order!";

            var lEmps = EmployeesApi.GetEmployees();
            lEmps.Reverse();
            lEmps.Add(emp);
            lEmps.Reverse();

            var newSelectLEmps = lEmps.AsQueryable().Select(s =>
            new
            {
                Text = s.FirstName + " " + s.LastName,
                Value = s.EmployeeID,
                Selected = s.EmployeeID == user.EmployeeID ? true : false
            }).ToList();
            SelectList empSelectList = new SelectList(newSelectLEmps, "Value", "Text", "Selected");
            ViewBag.Employees = empSelectList;
        }
    }
}