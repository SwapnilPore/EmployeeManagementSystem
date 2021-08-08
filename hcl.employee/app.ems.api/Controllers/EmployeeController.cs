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
using app.ems.api.Controllers.Interfaces;
using app.ems.api.Models;
using app.ems.api.Repository;

namespace app.ems.api.Controllers
{
    public class EmployeeController : ApiController , IEmployee
    {
        private EmployeeRepository repository = new EmployeeRepository();

        // GET: api/Employee
        public IQueryable<Employee> GetEmployees()
        {
            return repository.GetEmployees();
        }

        //// GET: api/Employee/5
       /* [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> GetEmployee(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
       */

        // PUT: api/Employee/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (employee.Id == 0)
            {
                return BadRequest();
            }

            try
            {
                repository.AmendEmployee(employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!repository.EmployeeExists(employee.Id))
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

        // POST: api/Employee
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.AddEmployee(employee);

            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employee/5
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> DeleteEmployee(int id)
        {
            if (!repository.EmployeeExists(id))
            {
                return NotFound();
            }

            repository.RemoveEmployee(id);
            return Ok(id);
        }
       
    }
}