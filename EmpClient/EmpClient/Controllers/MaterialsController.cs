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
    public class MaterialsController : Controller
    {
        private int deffaultSize = 25;
        public ActionResult Index(int? page)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            int number = (page ?? 1);
            var materials = MaterialApi.GetMaterialsWithAll();

            if (materials == null || materials.Count == 0)
            {
                materials = new List<Material>();
            }

            return View(materials.ToPagedList(number, deffaultSize));
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

            return View(MaterialApi.GetMaterialByID((int)id));
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            AddAllViewBagSelectList(new Material());

            return View(new Material());
        }

        [HttpPost]
        public ActionResult Create(Material obj)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            AddAllViewBagSelectList(obj);
            try
            {
                Material nMat = MaterialApi.InsMat(obj);
                if (nMat != null)
                {
                    TempData["SuccessMessage"] = "Add new Material with id: " + nMat.MaterialID + " successfully!";
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

        public ActionResult Edit(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var material = MaterialApi.GetMaterialByID((int)id);
            AddAllViewBagSelectList(material);

            return View(material);
        }

        [HttpPost]
        public ActionResult Edit(Material obj, int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            if (id == null)
            {
                return RedirectToAction("Index");
            }
            AddAllViewBagSelectList(obj);

            try
            {
                if (MaterialApi.UpdMat((int)id, obj))
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
                if (MaterialApi.DelMat((int)id))
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

        private void AddAllViewBagSelectList(Material material)
        {
            Product prd = new Product();
            prd.ProductName = "Choose product for this material!";

            var lPrds = ProductApi.GetProducts();
            lPrds.Reverse();
            lPrds.Add(prd);
            lPrds.Reverse();

            var newSelectLPrds = lPrds.AsQueryable().Select(s =>
            new
            {
                Text = s.ProductName,
                Value = s.ProductID,
                Selected = s.ProductID == material.ProductID ? true : false
            }).ToList();
            SelectList prdSelectList = new SelectList(newSelectLPrds, "Value", "Text", "Selected");
            ViewBag.Products = prdSelectList;
        }
    }
}