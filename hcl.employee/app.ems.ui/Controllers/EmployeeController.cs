using app.ems.ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace app.ems.ui.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<EmployeeModel> employeeList;
            HttpResponseMessage response = EmployeeApiClient.webApiClient.GetAsync("Employee").Result;
            employeeList = response.Content.ReadAsAsync<IEnumerable<EmployeeModel>>().Result;
            return View(employeeList);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            try
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = EmployeeApiClient.webApiClient.PostAsync("Employee", data).Result;
                var result = response.Content.ReadAsAsync<IEnumerable<EmployeeModel>>().Result;

                return RedirectToAction("Index");
            }
            catch(Exception exc)
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
