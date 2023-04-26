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
    public class StatusOrdersController : ApiController
    {
        private MyImageEntities db = new MyImageEntities();

        // GET: api/StatusOrders
        public IQueryable<StatusOrder> GetStatusOrders()
        {
            return db.StatusOrders;
        }

        // GET: api/StatusOrders/5
        [ResponseType(typeof(StatusOrder))]
        public async Task<IHttpActionResult> GetStatusOrder(int id)
        {
            StatusOrder statusOrder = await db.StatusOrders.FindAsync(id);
            if (statusOrder == null)
            {
                return NotFound();
            }

            return Ok(statusOrder);
        }

        // PUT: api/StatusOrders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStatusOrder(int id, StatusOrder statusOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusOrder.StatusOrderID)
            {
                return BadRequest();
            }

            db.Entry(statusOrder).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusOrderExists(id))
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

        // POST: api/StatusOrders
        [ResponseType(typeof(StatusOrder))]
        public async Task<IHttpActionResult> PostStatusOrder(StatusOrder statusOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatusOrders.Add(statusOrder);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = statusOrder.StatusOrderID }, statusOrder);
        }

        // DELETE: api/StatusOrders/5
        [ResponseType(typeof(StatusOrder))]
        public async Task<IHttpActionResult> DeleteStatusOrder(int id)
        {
            StatusOrder statusOrder = await db.StatusOrders.FindAsync(id);
            if (statusOrder == null)
            {
                return NotFound();
            }

            db.StatusOrders.Remove(statusOrder);
            await db.SaveChangesAsync();

            return Ok(statusOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusOrderExists(int id)
        {
            return db.StatusOrders.Count(e => e.StatusOrderID == id) > 0;
        }
    }
}