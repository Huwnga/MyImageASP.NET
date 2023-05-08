using EmpClient.Api;
using EmpClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpClient.Controllers
{
    public class OrganizationsController : Controller
    {
        // GET: Organizations
        public ActionResult Index()
        {
            return View(OrganizationApi.GetAllOrganization());
        }

        // GET: Organizations/Details/5
        public ActionResult Details(int id)
        {
            return View(OrganizationApi.GetOrganizationByID(id));
        }

        // GET: Organizations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organizations/Create
        [HttpPost]
        public ActionResult Create(Organization obj)
        {
            try
            {

                if (OrganizationApi.CreateOrganization(obj) == 1)
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

        // GET: Organizations/Edit/5
        public ActionResult Edit(int id)
        {
            return View(OrganizationApi.GetOrganizationByID(id));
        }

        // POST: Organizations/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Organization obj)
        {
            try
            {
                if (OrganizationApi.UpdateOrganization(obj, id) == 1)
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

        // GET: Organizations/Delete/5
        public ActionResult Delete(int id)
        {
            return View(OrganizationApi.GetOrganizationByID(id));
        }

        // POST: Organizations/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (OrganizationApi.DeleteOrganization(id) == 1)
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
