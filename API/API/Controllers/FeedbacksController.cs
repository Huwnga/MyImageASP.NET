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
    public class FeedbacksController : ApiController
    {
        private MyImageEntities db = new MyImageEntities();

        // GET: api/Feedbacks
        public IQueryable<Feedback> GetFeedbacks()
        {
            return db.Feedbacks;
        }

        [Route("api/FeedbacksWithAll")]
        public IQueryable<Feedback> GetFeedbacksWithAll()
        {
            return db.Feedbacks
                .Include(e => e.CustomerID)
                .Include(e => e.ProductID)
                .OrderBy(e => e.CreatedAt);
        }

        [Route("api/Feedbacks/System")]
        public IQueryable<Feedback> GetSystemFeedbacks()
        {
            return db.Feedbacks
                .Include(e => e.CustomerID)
                .Include(e => e.ProductID)
                .OrderBy(e => e.CreatedAt)
                .Where(e => e.ProductID == null);
        }

        [Route("api/Feedbacks/Product")]
        public IQueryable<Feedback> GetProductFeedbacks(int productID)
        {
            return db.Feedbacks
                .Include(e => e.CustomerID)
                .Include(e => e.ProductID)
                .OrderBy(e => e.CreatedAt)
                .Where(e => e.ProductID == productID);
        }

        // GET: api/Feedbacks/5
        [ResponseType(typeof(Feedback))]
        public async Task<IHttpActionResult> GetFeedback(int id)
        {
            Feedback feedback = await db.Feedbacks
                .Include(e => e.CustomerID)
                .Include(e => e.ProductID)
                .SingleOrDefaultAsync(e => e.FeedbackID == id);

            if (feedback == null)
            {
                return NotFound();
            }

            return Ok(feedback);
        }

        // PUT: api/Feedbacks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFeedback(int id, Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feedback.FeedbackID)
            {
                return BadRequest();
            }

            if (!Validated(feedback))
            {
                return BadRequest();
            }

            db.Entry(feedback).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackExists(id))
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

        // POST: api/Feedbacks
        [ResponseType(typeof(Feedback))]
        public async Task<IHttpActionResult> PostFeedback(Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!Validated(feedback))
            {
                return BadRequest();
            }

            feedback.CreatedAt = DateTime.Now;
            db.Feedbacks.Add(feedback);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = feedback.FeedbackID }, feedback);
        }

        // DELETE: api/Feedbacks/5
        [ResponseType(typeof(Feedback))]
        public async Task<IHttpActionResult> DeleteFeedback(int id)
        {
            Feedback feedback = await db.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }

            db.Feedbacks.Remove(feedback);
            await db.SaveChangesAsync();

            return Ok(feedback);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeedbackExists(int id)
        {
            return db.Feedbacks.Count(e => e.FeedbackID == id) > 0;
        }

        private bool Validated (Feedback feedback)
        {
            if (feedback.CustomerID != null)
            {
                feedback.CustomerID = feedback.CustomerID == 0 ? null : feedback.CustomerID;


                if (feedback.CustomerID != null)
                {
                    var cusExists = db.Customers.Where(e => e.CustomerID == feedback.CustomerID).Count();

                    if (cusExists > 0)
                    {
                        return false;
                    }
                }
            }

            if (feedback.ProductID != null)
            {
                feedback.ProductID = feedback.ProductID == 0 ? null : feedback.ProductID;

                if (feedback.ProductID != null)
                {
                    var prdExists = db.Products.Where(e => e.ProductID == feedback.ProductID).Count();

                    if (prdExists > 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}