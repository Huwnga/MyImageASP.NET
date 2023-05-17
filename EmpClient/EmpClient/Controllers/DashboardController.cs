using EmpClient.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpClient.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            ViewBag.AccNum = UserApi.GetUsers().Count();
            ViewBag.EmpNum = EmployeesApi.GetEmployees().Count();
            ViewBag.OrgNum = OrganizationApi.GetOrganizations().Count();
            ViewBag.CusNum = CustomerApi.GetCustomers().Count();
            ViewBag.CatNum = CategoryApi.GetCategorys().Count();
            ViewBag.MatNum = MaterialApi.GetMaterials().Count();
            ViewBag.PrdNum = ProductApi.GetProducts().Count();
            ViewBag.OrdNum = OrderApi.GetOrders().Count();
            ViewBag.FdbNum = FeedbackApi.GetFeedbacks().Count();

            return View();
        }
    }
}