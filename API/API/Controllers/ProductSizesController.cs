using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class ProductSizesController : ApiController
    {
        private MyImageEntities db = new MyImageEntities();

        // GET: api/ProductSizes
        public IQueryable<ProductSize> GetProductSizes()
        {
            return db.ProductSizes;
        }

        // GET: api/ProductSizes/5
        [ResponseType(typeof(ProductSize))]
        public async Task<IHttpActionResult> GetProductSize(int id)
        {
            ProductSize productSize = await db.ProductSizes.FindAsync(id);
            if (productSize == null)
            {
                return NotFound();
            }

            return Ok(productSize);
        }

        // PUT: api/ProductSizes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductSize(int id, ProductSize productSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productSize.ProductID)
            {
                return BadRequest();
            }

            db.Entry(productSize).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductSizeExists(id))
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

        // POST: api/ProductSizes
        [ResponseType(typeof(ProductSize))]
        public async Task<IHttpActionResult> PostProductSize(ProductSize productSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductSizes.Add(productSize);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductSizeExists(productSize.ProductID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = productSize.ProductID }, productSize);
        }

        // DELETE: api/ProductSizes/5
        [ResponseType(typeof(ProductSize))]
        public async Task<IHttpActionResult> DeleteProductSize(int id)
        {
            ProductSize productSize = await db.ProductSizes.FindAsync(id);
            if (productSize == null)
            {
                return NotFound();
            }

            db.ProductSizes.Remove(productSize);
            await db.SaveChangesAsync();

            return Ok(productSize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductSizeExists(int id)
        {
            return db.ProductSizes.Count(e => e.ProductID == id) > 0;
        }
    }
}