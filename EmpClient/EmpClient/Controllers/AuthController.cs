using EmpClient.Api;
using EmpClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpClient.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            User userVerified = UserApi.Login(user);

            if (userVerified == null)
            {
                TempData["ErrorMessage"] = "Username or password is wrong!";
                return View(user);
            }

            Session["UserID"] = userVerified.UserID;

            return RedirectToAction("Index", "Dashboard");
        }
    }
}