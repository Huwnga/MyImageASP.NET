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
    public class CartDetailsController : ApiController
    {
        private MyImageEntities db = new MyImageEntities();

        // GET: api/CartDetails
        public IQueryable<CartDetail> GetCartDetails()
        {
            return db.CartDetails;
        }

        // GET: api/CartDetails/5
        [ResponseType(typeof(CartDetail))]
        public async Task<IHttpActionResult> GetCartDetail(int id)
        {
            CartDetail cartDetail = await db.CartDetails.FindAsync(id);
            if (cartDetail == null)
            {
                return NotFound();
            }

            return Ok(cartDetail);
        }

        // PUT: api/CartDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCartDetail(int id, CartDetail cartDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cartDetail.CartDetailID)
            {
                return BadRequest();
            }

            db.Entry(cartDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartDetailExists(id))
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

        // POST: api/CartDetails
        [ResponseType(typeof(CartDetail))]
        public async Task<IHttpActionResult> PostCartDetail(CartDetail cartDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CartDetails.Add(cartDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cartDetail.CartDetailID }, cartDetail);
        }

        // DELETE: api/CartDetails/5
        [ResponseType(typeof(CartDetail))]
        public async Task<IHttpActionResult> DeleteCartDetail(int id)
        {
            CartDetail cartDetail = await db.CartDetails.FindAsync(id);
            if (cartDetail == null)
            {
                return NotFound();
            }

            db.CartDetails.Remove(cartDetail);
            await db.SaveChangesAsync();

            return Ok(cartDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartDetailExists(int id)
        {
            return db.CartDetails.Count(e => e.CartDetailID == id) > 0;
        }
    }
}