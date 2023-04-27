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
    public class FunctionGroupsController : ApiController
    {
        private MyImageEntities db = new MyImageEntities();

        // GET: api/FunctionGroups
        public IQueryable<FunctionGroup> GetFunctionGroups()
        {
            return db.FunctionGroups;
        }

        // GET: api/FunctionGroups/5
        [ResponseType(typeof(FunctionGroup))]
        public async Task<IHttpActionResult> GetFunctionGroup(int id)
        {
            FunctionGroup functionGroup = await db.FunctionGroups.FindAsync(id);
            if (functionGroup == null)
            {
                return NotFound();
            }

            return Ok(functionGroup);
        }

        // PUT: api/FunctionGroups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFunctionGroup(int id, FunctionGroup functionGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != functionGroup.FunctionGroupID)
            {
                return BadRequest();
            }

            db.Entry(functionGroup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FunctionGroupExists(id))
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

        // POST: api/FunctionGroups
        [ResponseType(typeof(FunctionGroup))]
        public async Task<IHttpActionResult> PostFunctionGroup(FunctionGroup functionGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FunctionGroups.Add(functionGroup);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = functionGroup.FunctionGroupID }, functionGroup);
        }

        // DELETE: api/FunctionGroups/5
        [ResponseType(typeof(FunctionGroup))]
        public async Task<IHttpActionResult> DeleteFunctionGroup(int id)
        {
            FunctionGroup functionGroup = await db.FunctionGroups.FindAsync(id);
            if (functionGroup == null)
            {
                return NotFound();
            }

            db.FunctionGroups.Remove(functionGroup);
            await db.SaveChangesAsync();

            return Ok(functionGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FunctionGroupExists(int id)
        {
            return db.FunctionGroups.Count(e => e.FunctionGroupID == id) > 0;
        }
    }
}