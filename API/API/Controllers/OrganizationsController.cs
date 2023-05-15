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
    public class OrganizationsController : ApiController
    {
        private MyImageEntities db = new MyImageEntities();

        // GET: api/Organizations
        public IQueryable<Organization> GetOrganizations()
        {
            return db.Organizations;
        }

        [HttpGet]
        [Route("api/OrganizationsWithParentOrg")]
        public IQueryable<Organization> GetChilrensByParentID(int parentID)
        {
            return db.Organizations.Include(e => e.Parent).Where(e => e.ParentID == parentID);
        }

        [HttpGet]
        [Route("api/OrganizationsWithParentOrg")]
        public IQueryable<Organization> GetOrganizationsWithParentOrg()
        {
            return db.Organizations.Include(e => e.Parent);
        }

        // GET: api/Organizations/5
        [ResponseType(typeof(Organization))]
        public async Task<IHttpActionResult> GetOrganization(int id)
        {
            var organization = await db.Organizations
                .Include(e => e.Parent)
                .SingleOrDefaultAsync(e => e.OrganizationID.Equals(id));
            if (organization == null)
            {
                return NotFound();
            }

            return Ok(organization);
        }

        // PUT: api/Organizations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrganization(int id, Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organization.OrganizationID)
            {
                return BadRequest();
            }

            if (!Validated(organization, "edit"))
            {
                return BadRequest();
            }

            organization.ParentID = organization.ParentID == 0 ? null : organization.ParentID;
            db.Entry(organization).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationExists(id))
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

        // POST: api/Organizations
        [ResponseType(typeof(Organization))]
        public async Task<IHttpActionResult> PostOrganization(Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!Validated(organization, ""))
            {
                return BadRequest();
            }

            if (organization.ParentID != null)
            {
                organization.ParentID = organization.ParentID == 0 ? null : organization.ParentID;
            }

            db.Organizations.Add(organization);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = organization.OrganizationID }, organization);
        }

        // DELETE: api/Organizations/5
        [ResponseType(typeof(Organization))]
        public async Task<IHttpActionResult> DeleteOrganization(int id)
        {
            Organization organization = await db.Organizations.FindAsync(id);
            if (organization == null)
            {
                return NotFound();
            }

            var childrens = GetChilrensByParentID(id);
            var employees = db.Employees.Where(e => e.OrganizationID == id);

            if (childrens.Count() > 0)
            {
                return BadRequest();
            }

            if (employees.Count() > 0)
            {
                return BadRequest();
            }

            db.Organizations.Remove(organization);
            await db.SaveChangesAsync();

            return Ok(organization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrganizationExists(int id)
        {
            return db.Organizations.Count(e => e.OrganizationID == id) > 0;
        }

        private bool Validated (Organization organization, string method)
        {
            if (organization.ParentID != null && organization.ParentID != 0)
            {
                var parentExists = db.Organizations.SingleOrDefault(e => e.OrganizationID.Equals((int)organization.ParentID));

                if (parentExists == null)
                {
                    return false;
                }

                if (organization.ParentID == organization.OrganizationID)
                {
                    return false;
                }

                if (organization.OrganizationID == parentExists.ParentID)
                {
                    return false;
                }

                if (method.ToLower() == "edit")
                {
                    var childrens = GetChilrensByParentID(organization.OrganizationID);

                    if (childrens.Count() > 0)
                    {
                        var hasSoChild = childrens.Where(e => e.OrganizationID == parentExists.ParentID);

                        if (hasSoChild.Count() > 0)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}