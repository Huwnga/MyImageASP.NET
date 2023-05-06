﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Api.Models;
using Microsoft.Ajax.Utilities;
using PagedList;

namespace Api.Controllers
{
    public class ProductsController : ApiController
    {
        private int pageSizeDeffault = 10;
        private MyImageEntities db = new MyImageEntities();

        // GET: api/Products
        public IPagedList<Product> GetProducts(int? pageNumber, int? pageSize)
        {
            int number = (pageNumber ?? 1);
            int size = (pageSize ?? pageSizeDeffault);

            return db.Products.ToPagedList(number, size);
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // GET: api/Products/Category
        [Route("api/Products/Category")]
        public IPagedList<ProductSize> GetProductsByCategoryID(int categoryID, int? pageNumber, int? pageSize)
        {
            var productSizes = db.ProductSizes
                .Include(e => e.Product)
                .OrderBy(e => e.ProductID)
                .Where(e => e.Product.CategoryID == categoryID);

            int number = (pageNumber ?? 1);
            int size = (pageSize ?? pageSizeDeffault);
            return productSizes.ToPagedList(number, size);
        }

        // GET: api/Products/BestSealer
        [Route("api/Products/BestSealer")]
        public IPagedList<ProductSize> GetProductsBestSealer(int? pageNumber, int? pageSize)
        {

            List<ProductSize> lowerPriceProducts = new List<ProductSize>();
            var productSizes = db.ProductSizes
                .Include(e => e.Product)
                .OrderByDescending(e => e.Product.ReoderLevel)
                .ToList();

            foreach (ProductSize productSize in productSizes)
            {
                if (!lowerPriceProducts.Contains(productSize))
                {
                    lowerPriceProducts.Add(productSize);
                }
            }

            int number = (pageNumber ?? 1);
            int size = (pageSize ?? pageSizeDeffault);
            return lowerPriceProducts.ToPagedList(number, size);
        }

        // GET: api/Products/LowerPrice
        [Route("api/Products/LowerPrice")]
        public IPagedList<ProductSize> GetProductsLowerPrice(int? pageNumber, int? pageSize)
        {
            List<ProductSize> lowerPriceProducts = new List<ProductSize>();
            var productSizes = db.ProductSizes
                .Include(e => e.Product)
                .OrderBy(e => e.UnitPrice)
                .ToList();

            foreach (ProductSize productSize in productSizes)
            {
                if (!lowerPriceProducts.Contains(productSize))
                {
                    lowerPriceProducts.Add(productSize);
                }
            }

            int number = (pageNumber ?? 1);
            int size = (pageSize ?? pageSizeDeffault);
            return lowerPriceProducts.ToPagedList(number, size);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductID)
            {
                return BadRequest();
            }

            product.UpdatedAt = DateTime.Now;

            db.Entry(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            product.CreatedAt = DateTime.Now;
            product.UpdatedAt = DateTime.Now;

            db.Products.Add(product);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}