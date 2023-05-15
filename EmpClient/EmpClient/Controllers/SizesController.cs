using Client.Api;
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
    public class SizesController : Controller
    {
        private int deffaultSize = 25;
        // GET: Products
        public ActionResult Index(int? page)
        {
            int number = (page ?? 1);
            var list = SizeApi.GetSizes();

            if (list == null || list.Count == 0)
            {
                list = new List<Size>();
            }

            return View(list.ToPagedList(number, deffaultSize));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var size = SizeApi.GetSize((int)id);

            return View(size);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Size obj)
        {
            try
            {
                Size nSize = SizeApi.InsSize(obj);
                if (nSize != null)
                {
                    TempData["SuccessMessage"] = "Add new Size with id: " + nSize.SizeID + " successfully!";
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

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            return Details(id);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Size obj, int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            try
            {
                if (SizeApi.UpdSize((int)id, obj))
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

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            return Details(id);
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            try
            {
                if (ProductApi.DeleteProduct((int)id))
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