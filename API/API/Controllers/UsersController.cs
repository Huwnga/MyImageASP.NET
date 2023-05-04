using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Description;
using Api.Models;

namespace Api.Controllers
{
    public class UsersController : ApiController
    {
        private MyImageEntities db = new MyImageEntities();

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserID)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = user.UserID }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost]
        [Route("api/User/Login")]
        [ResponseType(typeof(int))]
        public async Task<IHttpActionResult> Login(User user)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState);
            }

            User userExists = await db.Users.SingleOrDefaultAsync(e => e.UserName == user.UserName);

            if (userExists == null)
            {
                return Ok(0);
            }

            bool verified = BCrypt.Net.BCrypt.Verify(user.Password, userExists.Password);

            if (!verified)
            {
                return Ok(0);
            }

            return Ok(userExists.UserID);
        }

        [HttpPost]
        [Route("api/User/CheckFunction")]
        public async Task<IHttpActionResult> CheckFunctionByUser(int functionID, int userID)
        {
            User userExists = await db.Users.SingleOrDefaultAsync(e => e.UserID == userID);

            if (userExists == null)
            {
                return Ok(false);
            }

            Function funcExists = await db.Functions.SingleOrDefaultAsync(e => e.FunctionID == functionID);

            if (funcExists == null)
            {
                return Ok(false);
            }

            UserFunction userFuncExists = await db.UserFunctions.SingleOrDefaultAsync(e => e.UserID == userID && e.FunctionID == functionID);

            if (userFuncExists != null)
            {
                return Ok(true);
            }

            List<UserGroup> userGroups = db.UserGroups.Where(e => e.UserID == userID).ToList();

            bool hadFunctionByGroup = false;
            userGroups.ForEach(userGroup =>
            {
                bool groupFunctionExists = db.FunctionGroups.Count(e => e.FunctionID == functionID && e.GroupID == userGroup.GroupID) > 0;

                if (groupFunctionExists)
                {
                    hadFunctionByGroup = true;

                    return;
                }
            });

            if (!hadFunctionByGroup)
            {
                return Ok(false);
            }

            return Ok(true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserID == id) > 0;
        }
    }
}