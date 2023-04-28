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
    public class UserFunctionsController : ApiController
    {
        private MyImageEntities db = new MyImageEntities();

        // GET: api/UserFunctions
        public IQueryable<UserFunction> GetUserFunctions()
        {
            return db.UserFunctions;
        }

        // GET: api/UserFunctions/5
        [ResponseType(typeof(UserFunction))]
        public async Task<IHttpActionResult> GetUserFunction(int id)
        {
            UserFunction userFunction = await db.UserFunctions.FindAsync(id);
            if (userFunction == null)
            {
                return NotFound();
            }

            return Ok(userFunction);
        }

        // PUT: api/UserFunctions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserFunction(int id, UserFunction userFunction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userFunction.UserID)
            {
                return BadRequest();
            }

            db.Entry(userFunction).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserFunctionExists(id))
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

        // POST: api/UserFunctions
        [ResponseType(typeof(UserFunction))]
        public async Task<IHttpActionResult> PostUserFunction(UserFunction userFunction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserFunctions.Add(userFunction);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserFunctionExists(userFunction.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userFunction.UserID }, userFunction);
        }

        // DELETE: api/UserFunctions/5
        [ResponseType(typeof(UserFunction))]
        public async Task<IHttpActionResult> DeleteUserFunction(int id)
        {
            UserFunction userFunction = await db.UserFunctions.FindAsync(id);
            if (userFunction == null)
            {
                return NotFound();
            }

            db.UserFunctions.Remove(userFunction);
            await db.SaveChangesAsync();

            return Ok(userFunction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserFunctionExists(int id)
        {
            return db.UserFunctions.Count(e => e.UserID == id) > 0;
        }
    }
}