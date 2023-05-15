using EmpClient.Api;
using EmpClient.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace EmpClient.Controllers
{
    public class OrdersController : Controller
    {
        private int deffaultSize = 1;
        // GET: Orders
        public ActionResult Index(int? page)
        {
            int number = (page ?? 1);

            List<Order> orders = OrderApi.GetOrdersWithAll();

            if (orders == null || orders.Count == 0)
            {
                orders = new List<Order>();
            }
            
            return View(orders.ToPagedList(number, deffaultSize));
        }
        // GET: Orders
        public ActionResult EmployeeOrder(int? page)
        {
            int number = (page ?? 1);
            int employeeID = ViewBag.userID;
            List<Order> orders = OrderApi.GetOrdersWithAllByEmployeeID(employeeID);

            if (orders == null || orders.Count == 0)
            {
                orders = new List<Order>();
            }

            return View(orders.ToPagedList(number, deffaultSize));
        }

        public ActionResult Details (int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            return View(OrderApi.GetOrder((int) id));
        }

        public ActionResult Edit (int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var order = OrderApi.GetOrder( (int)id );
            AddAllViewBagSelectList(order);
            return View(order);
        }

        public ActionResult EditOrderStatus(int? id)
        {
            return Edit(id);
        }

        [HttpPost]
        public ActionResult Edit(int? id, Order obj)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            AddAllViewBagSelectList(obj);

            try
            {
                if (OrderApi.UpdOrd((int)id, obj))
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

        [HttpPost]
        public ActionResult EditOrderStatus(int? id, Order obj)
        {
            return Edit(id, obj);
        }

        private void AddAllViewBagSelectList(Order order)
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
                Selected = s.EmployeeID == order.EmployeeID ? true : false
            }).ToList();
            SelectList empSelectList = new SelectList(newSelectLEmps, "Value", "Text", "Selected");
            ViewBag.Employees = empSelectList;

            StatusOrder sto = new StatusOrder();
            sto.StatusOrderName = "Choose status for this order!";

            List<StatusOrder> lStos = StatusOrderApi.GetStatusOrders();
            lStos.Reverse();
            lStos.Add(sto);
            lStos.Reverse();

            var newSelectLSto = lStos.AsQueryable().Select(s =>
            new
            {
                Text = s.StatusOrderName,
                Value = s.StatusOrderID,
                Selected = s.StatusOrderID == order.StatusOrderID ? true : false
            }).ToList();
            SelectList stoSelectList = new SelectList(newSelectLSto, "Value", "Text", "Selected");
            ViewBag.StatusOrders = stoSelectList;
        }
    }
}