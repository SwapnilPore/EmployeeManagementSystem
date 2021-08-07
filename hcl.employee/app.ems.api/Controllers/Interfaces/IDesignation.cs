using app.ems.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace app.ems.api.Controllers.Interfaces
{
    public interface IDesignation
    {
        IQueryable<Designation> GetDesignations();
        Task<IHttpActionResult> GetDesignation(int id);
    }
}
