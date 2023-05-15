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
using Api.Models;

namespace Api.Controllers
{
    public class OrdersController : ApiController
    {
        private MyImageEntities db = new MyImageEntities();

        // GET: api/Orders
        public IQueryable<Order> GetOrders()
        {
            return db.Orders;
        }

        [Route("api/OrdersWithAll")]
        public IQueryable<Order> GetOrdersWithAll()
        {
            var orders = db.Orders
                .Include(e => e.Customer)
                .Include(e => e.Employee)
                .Include(e => e.Payment)
                .Include(e => e.StatusOrder);

            return orders;
        }

        [Route("api/OrdersWithAll")]
        public IQueryable<Order> GetOrdersWithAllByCustomerID(int customerID)
        {
            var orders = db.Orders
                .Include(e => e.Customer)
                .Include(e => e.Employee)
                .Include(e => e.Payment)
                .Include(e => e.StatusOrder)
                .Where(e => e.CustomerID == customerID);

            return orders;
        }

        [Route("api/OrdersWithAll")]
        public IQueryable<Order> GetOrdersWithAllByEmployeeID(int employeeID)
        {
            var orders = db.Orders
                .Include(e => e.Customer)
                .Include(e => e.Employee)
                .Include(e => e.Payment)
                .Include(e => e.StatusOrder)
                .Where(e => e.EmployeeID == employeeID);

            return orders;
        }

        // GET: api/Orders/5
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> GetOrder(int id)
        {
            Order order = await db.Orders
                .Include(e => e.Customer)
                .Include(e => e.Employee)
                .Include(e => e.Payment)
                .Include(e => e.StatusOrder)
                .SingleOrDefaultAsync(e => e.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.OrderID)
            {
                return BadRequest();
            }

            if (!Validated(order))
            {
                return BadRequest();
            }

            db.Entry(order).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!Validated(order))
            {
                return BadRequest();
            }

            order.OrderAt = DateTime.Now;

            db.Orders.Add(order);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = order.OrderID }, order);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> DeleteOrder(int id)
        {
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            db.Orders.Remove(order);
            await db.SaveChangesAsync();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(int id)
        {
            return db.Orders.Count(e => e.OrderID == id) > 0;
        }

        private bool Validated (Order order)
        {
            if (order.EmployeeID == null)
            {
                return false;
            }

            var empExists = db.Employees.SingleOrDefault(e => e.EmployeeID == order.EmployeeID);

            if (empExists == null)
            {
                return false;
            }

            if (order.CustomerID == null)
            {
                return false;
            }

            var cusExists = db.Customers.SingleOrDefault(e => e.CustomerID == order.CustomerID);

            if (cusExists == null)
            {
                return false;
            }

            if (order.StatusOrderID == null)
            {
                return false;
            }

            var sOrdExists = db.StatusOrders.SingleOrDefault(e => e.StatusOrderID == order.StatusOrderID);

            if (sOrdExists == null)
            {
                return false;
            }

            if (order.PaymentID == null)
            {
                return false;
            }

            var pmExists = db.Payments.SingleOrDefault(e => e.PaymentID == order.PaymentID);

            if (pmExists== null)
            {
                return false;
            }

            return true;
        }
    }
}