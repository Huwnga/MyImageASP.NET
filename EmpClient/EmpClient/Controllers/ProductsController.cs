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
        // GET: Products
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

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            return View(ProductApi.GetProductByID((int)id));
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            AddAllViewBagSelectList(new Product());

            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Product obj)
        {
            AddAllViewBagSelectList(obj);
            try
            {
                Product nOrg = ProductApi.InsertProduct(obj);
                if (nOrg != null)
                {
                    TempData["SuccessMessage"] = "Add new Product with id: " + nOrg.ProductID + " successfully!";
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
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var product = ProductApi.GetProductByID((int)id);
            AddAllViewBagSelectList(product);

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Product obj, int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            AddAllViewBagSelectList(obj);

            try
            {
                if (ProductApi.UpdateProduct((int)id, obj))
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

        private void AddAllViewBagSelectList(Product product)
        {
            Category cat = new Category();
            cat.CategoryName = "Choose category for this product!";

            List<Category> lCats = CategoryApi.GetCategorys();
            lCats.Reverse();
            lCats.Add(cat);
            lCats.Reverse();

            var newSelectLCats = lCats.AsQueryable().Select(s =>
            new
            {
                Text = s.CategoryName,
                Value = cat.CategoryID,
                Selected = cat.CategoryID == product.CategoryID ? true : false
            }).ToList();

            SelectList catSelectList = new SelectList(newSelectLCats, "Value", "Text", "Selected");
            ViewBag.Categories = catSelectList;
        }
    }
}