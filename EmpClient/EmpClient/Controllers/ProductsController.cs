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
    public class ProductsController : Controller
    {
        private int deffaultSize = 25;
        // GET: Organizations
        public ActionResult Index(int? page)
        {
            int number = (page ?? 1);
            var products = ProductApi.GetProductsWithAll();

            if (products == null || products.Count == 0)
            {
                products = new List<Product>();
            }

            return View(products.ToPagedList(number, deffaultSize));
        }

        public ActionResult IndexChildren(int? ParentID)
        {
            if (ParentID == null)
            {
                return RedirectToAction("Index");
            }

            return View(OrganizationApi.GetChilrensByParentID((int)ParentID));
        }

        // GET: Organizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            return View(OrganizationApi.GetOrganizationByID((int)id));
        }

        // GET: Organizations/Create
        public ActionResult Create()
        {
            AddAllViewBagSelectList(new Organization(), "");

            return View();
        }

        // POST: Organizations/Create
        [HttpPost]
        public ActionResult Create(Organization obj)
        {
            AddAllViewBagSelectList(obj, "");
            try
            {
                Organization nOrg = OrganizationApi.InsertOrganization(obj);
                if (nOrg != null)
                {
                    TempData["SuccessMessage"] = "Add new Organization with id: " + nOrg.OrganizationID + " successfully!";
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

        // GET: Organizations/Edit/5
        public ActionResult Edit(int? id)
        {
            var emloyee = OrganizationApi.GetOrganizationByID((int)id);
            AddAllViewBagSelectList(emloyee, "edit");

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            return View(emloyee);
        }

        // POST: Organizations/Edit/5
        [HttpPost]
        public ActionResult Edit(Organization obj, int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            AddAllViewBagSelectList(obj, "edit");

            try
            {
                if (OrganizationApi.UpdateOrganization((int)id, obj))
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

        // GET: Organizations/Delete/5
        public ActionResult Delete(int? id)
        {
            return Details(id);
        }

        // POST: Organizations/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            try
            {
                if (OrganizationApi.DeleteOrganization((int)id))
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

        private void AddAllViewBagSelectList(Organization organization, string method)
        {
            Organization org = new Organization();
            org.OrganizationName = "Choose parent organization for this organization!";

            List<Organization> lOrgs = OrganizationApi.GetOrganizations();
            lOrgs.Reverse();
            lOrgs.Add(org);
            lOrgs.Reverse();

            var newSelectLOrgs = lOrgs.AsQueryable().Select(s =>
            new
            {
                Text = s.OrganizationName,
                Value = s.OrganizationID,
                Selected = s.OrganizationID == organization.OrganizationID ? true : false
            }).ToList();

            if (method == "edit")
            {
                newSelectLOrgs = lOrgs.AsQueryable().Where(w => w.OrganizationID != organization.OrganizationID && w.ParentID != organization.OrganizationID).Select(s =>
                new
                {
                    Text = s.OrganizationName,
                    Value = s.OrganizationID,
                    Selected = s.OrganizationID == organization.OrganizationID ? true : false
                }).ToList();
            }

            SelectList orgSelectList = new SelectList(newSelectLOrgs, "Value", "Text", "Selected");
            ViewBag.Organizations = orgSelectList;
        }
    }
}