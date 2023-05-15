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

        // GET: api/EmployeesWithManager
        [HttpGet]
        [Route("api/EmployeesWithManager")]
        public IQueryable<Employee> GetEmployeesWithManager()
        {
            var lEmps = db.Employees.Include(e => e.Manager);

            return lEmps;
        }

        // GET: api/EmployeesWithOrg
        [HttpGet]
        [Route("api/EmployeesWithOrg")]
        public IQueryable<Employee> GetEmployeesWithOrganization()
        {
            var lEmps = db.Employees.Include(e => e.Organization);

            return lEmps;
        }

        // GET: api/EmployeesWithOrgAndManager
        [HttpGet]
        [Route("api/EmployeesWithOrgAndManager")]
        public IQueryable<Employee> GetEmployeesWithOrgAndManager()
        {
            var lEmps = db.Employees.Include(e => e.Manager).Include(e => e.Organization);

            return lEmps;
        }

        // GET: api/EmployeesWithOrgAndManager
        [HttpGet]
        [Route("api/EmployeesWithManager")]
        public IQueryable<Employee> GetChilrensByManagerID(int managerID)
        {
            var lEmps = db.Employees.Include(e => e.Manager).Where(e => e.ManagerID == managerID);

            return lEmps;
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

            if (!Validated(employee, "edit"))
            {
                return BadRequest();
            }

            if (employee.ManagerID != null)
            {
                employee.ManagerID = employee.ManagerID == 0 ? null : employee.ManagerID;
            }

            if (employee.OrganizationID != null)
            {
                employee.OrganizationID = employee.OrganizationID == 0 ? null : employee.OrganizationID;
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

            if (!Validated(employee, ""))
            {
                return BadRequest();
            }

            employee.ManagerID = employee.ManagerID == 0 ? null : employee.ManagerID;
            employee.OrganizationID = employee.OrganizationID == 0 ? null : employee.OrganizationID;

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

            var childrens = GetChilrensByManagerID(id);
            var user = await db.Users.SingleOrDefaultAsync(e => e.EmployeeID == id);
            var orders = db.Orders.Where(e => e.EmployeeID == id);

            if (childrens.Count() > 0)
            {
                return BadRequest();
            }

            if (user != null)
            {
                return BadRequest();
            }

            if (orders.Count() > 0)
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

        private bool Validated (Employee employee, string method)
        {

            if (employee.ManagerID != null && employee.ManagerID != 0)
            {
                var managerExists = db.Employees.SingleOrDefault(e => e.EmployeeID.Equals((int)employee.ManagerID));

                if (managerExists == null)
                {
                    return false;
                }

                if (employee.ManagerID == employee.EmployeeID)
                {
                    return false;
                }

                if (employee.EmployeeID == managerExists.ManagerID)
                {
                    return false;
                }

                if (method.ToLower() == "edit")
                {
                    var childrensEmployee = GetChilrensByManagerID(employee.EmployeeID);

                    if (childrensEmployee.Count() > 0)
                    {
                        var hasSoChild = childrensEmployee.Where(e => e.EmployeeID == managerExists.ManagerID);

                        if (hasSoChild.Count() > 0)
                        {
                            return false;
                        }
                    }
                }
            }

            if (employee.OrganizationID != null && employee.ManagerID != 0)
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