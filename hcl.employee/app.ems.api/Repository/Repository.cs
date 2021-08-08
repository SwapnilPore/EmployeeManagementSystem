using app.ems.api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace app.ems.api.Repository
{
    public class Repository : IRepository
    {
        private EmployeeManagementSystemEntities db = new EmployeeManagementSystemEntities();

        public IQueryable<Employee> GetEmployees()
        {
            return db.Employees;
        }

        public void AddEmployee(Employee model)
        {
            db.Employees.Add(model);
            db.SaveChangesAsync();
        }

        public void AmendEmployee(Employee model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChangesAsync();
        }

        public void RemoveEmployee(int id)
        {
            var employee = db.Employees.FirstOrDefault(m => m.Id == id);
            db.Employees.Remove(employee);
            db.SaveChangesAsync();
        }

        public bool EmployeeExists(int id)
        {
            var employee = db.Employees.FirstOrDefault(m => m.Id == id);
            return employee == null;
        }
    }
}