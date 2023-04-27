using Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class SizesController : Controller
    {
        // GET: Sizes
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sizes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sizes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sizes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sizes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sizes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sizes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sizes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public List<Size> GetSizes ()
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Sizes";
            string resStrSizes = resClient.RestRequestAll();
            List<Size> sizes = JsonConvert.DeserializeObject<List<Size>>(resStrSizes);

            return sizes;
        }


        public List<Size> GetSizesByMaterialID(int materialID)
        {
            ResClient resClient = new ResClient();
            resClient.EndPoint = "api/Sizes/Material?materialID" + materialID;
            string resStrSizesByMaterial = resClient.RestRequestAll();
            List<Size> sizesByMaterial = JsonConvert.DeserializeObject<List<Size>>(resStrSizesByMaterial);

            return sizesByMaterial;
        }
    }
}
