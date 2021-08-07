using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace app.ems.ui.Models
{
    public class AddEmployeeModel
    {
        public EmployeeModel Employee { get; set; }

        public IEnumerable<SelectListItem> Projects { get; set; }

        public IEnumerable<SelectListItem> Designations { get; set; }
    }
}