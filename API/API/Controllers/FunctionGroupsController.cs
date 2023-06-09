﻿using System;
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

            if (id != functionGroup.FunctionID)
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

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FunctionGroupExists(functionGroup.FunctionID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = functionGroup.FunctionID }, functionGroup);
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
            return db.FunctionGroups.Count(e => e.FunctionID == id) > 0;
        }
    }
}