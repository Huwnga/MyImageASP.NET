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
    public class OrganizationsController : Controller
    {
        private int deffaultSize = 25;
        // GET: Organizations
        public ActionResult Index(int? page)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            int number = (page ?? 1);
            var organizations = OrganizationApi.GetOrganizationsWithParentOrg();

            if (organizations == null || organizations.Count == 0)
            {
                organizations = new List<Organization>();
            }

            return View(organizations.ToPagedList(number, deffaultSize));
        }

        public ActionResult IndexChildren(int? page, int? ParentID)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            if (ParentID == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.ParentID = ParentID;

            int number = (page ?? 1);
            var organizations = OrganizationApi.GetChilrensByParentID((int)ParentID);

            if (organizations == null || organizations.Count == 0)
            {
                organizations = new List<Organization>();
            }

            return View(organizations.ToPagedList(number, deffaultSize));
        }

        // GET: Organizations/Details/5
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

            return View(OrganizationApi.GetOrganizationByID((int) id));
        }

        // GET: Organizations/Create
        public ActionResult Create()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            AddAllViewBagSelectList(new Organization(), "");

            return View(new Organization());
        }

        // POST: Organizations/Create
        [HttpPost]
        public ActionResult Create(Organization obj)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

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
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

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
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            return Details(id);
        }

        // POST: Organizations/Delete/5
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