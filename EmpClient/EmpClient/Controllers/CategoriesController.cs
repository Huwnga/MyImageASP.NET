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
    public class CategoriesController : Controller
    {
        private int deffaultSize = 25;
        public ActionResult Index(int? page)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            int number = (page ?? 1);
            var categories = CategoryApi.GetCategorys();

            if (categories == null || categories.Count == 0)
            {
                categories = new List<Category>();
            }

            return View(categories.ToPagedList(number, deffaultSize));
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

            return View(CategoryApi.GetCategoryById((int)id));
        }

        public ActionResult Create()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            return View(new Category());
        }

        [HttpPost]
        public ActionResult Create(Category obj)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            try
            {
                Category ncat = CategoryApi.InsCat(obj);
                if (ncat != null)
                {
                    TempData["SuccessMessage"] = "Add new Category with id: " + ncat.CategoryID + " successfully!";
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

        public ActionResult Edit(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            return Details(id);
        }

        [HttpPost]
        public ActionResult Edit(Category obj, int? id)
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
                if (CategoryApi.UpdCat((int)id, obj))
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

        public ActionResult Delete(int id)
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
                if (CategoryApi.DelCat((int)id))
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