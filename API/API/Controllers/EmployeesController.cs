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
    public class EmployeesController : ApiController
    {
        private MyImageEntities db = new MyImageEntities();

        // GET: api/Employees
        public IQueryable<Employee> GetEmployees()
        {
            return db.Employees;
        }

        // GET: api/EmployeesWithOrg
        [HttpGet]
        [Route("api/EmployeesWithOrg")]
        public IQueryable<Employee> GetEmployeesWithOrganization()
        {
            return db.Employees.Include(e => e.Organization);
        }

        // GET: api/EmployeesWithOrgAndManager
        [HttpGet]
        [Route("api/EmployeesWithOrgAndManager")]
        public IQueryable<Employee> GetEmployeesWithOrgAndManager()
        {
            return db.Employees.Include(e => e.Manager).Include(e => e.Organization);
        }

        // GET: api/Employees/5
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> GetEmployee(int id)
        {
            var employee = await db.Employees
                .Include(e => e.Manager)
                .Include(e => e.Organization)
                .SingleOrDefaultAsync(e => e.EmployeeID.Equals(id));

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeID)
            {
                return BadRequest();
            }

            if (employee.ManagerID != null &&
                employee.ManagerID.Equals(id))
            {
                return BadRequest();
            }

            if (!RelationshipEmployee(employee))
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!RelationshipEmployee(employee))
            {
                return BadRequest();
            }

            db.Employees.Add(employee);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeID }, employee);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> DeleteEmployee(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            if (RelationshipEmployee(employee))
            {
                return BadRequest();
            }

            db.Employees.Remove(employee);
            await db.SaveChangesAsync();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.EmployeeID == id) > 0;
        }

        private bool OrganizationExists(int id)
        {
            return db.Organizations.Count(e => e.OrganizationID == id) > 0;
        }

        private bool RelationshipEmployee(Employee employee)
        {

            if (employee.ManagerID != null)
            {
                var managerExists = EmployeeExists((int)employee.ManagerID);

                if (!managerExists)
                {
                    return false;
                }
            }

            if (employee.OrganizationID != null)
            {
                var orgExists = OrganizationExists((int)employee.OrganizationID);

                if (!orgExists)
                {
                    return false;
                }
            }

            return true;
        }
    }
}