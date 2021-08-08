using app.ems.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ems.api.Repository
{
    interface IEmployeeRepository
    {
        IQueryable<Employee> GetEmployees();

        void AddEmployee(Employee model);

        void AmendEmployee(Employee model);

        void RemoveEmployee(int id);

        bool EmployeeExists(int id);
    }
}
