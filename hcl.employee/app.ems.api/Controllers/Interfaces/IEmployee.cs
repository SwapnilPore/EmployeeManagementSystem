using app.ems.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace app.ems.api.Controllers.Interfaces
{
    public interface IEmployee
    {
        IQueryable<Employee> GetEmployees();
        Task<IHttpActionResult> PutEmployee(int Id, Employee employee);
        Task<IHttpActionResult> PostEmployee(Employee employee);
        Task<IHttpActionResult> DeleteEmployee(int id);
    }
}
