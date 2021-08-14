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
            var model = new AddEmployeeModel();
            model.Employee = new EmployeeModel();

            var projectsResponse = EmployeeApiClient.webApiClient.GetAsync("Project").Result;
            var projectList = projectsResponse.Content.ReadAsAsync<IEnumerable<ProjectModel>>().Result;
            model.Projects = projectList.ToList().Select(m => new SelectListItem() { Value = m.Id.ToString(), Text = m.Name });
            IEnumerable<SelectListItem> list = projectList.ToList().Select(m => new SelectListItem() { Value = m.Id.ToString(), Text = m.Name });
            
            var designationsResponse = EmployeeApiClient.webApiClient.GetAsync("Designation").Result;
            var designationList = designationsResponse.Content.ReadAsAsync<IEnumerable<DesignationModel>>().Result;
            model.Designations = designationList.ToList().Select(m => new SelectListItem() { Value = m.Id.ToString(), Text = m.Name });

            return View(model);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(AddEmployeeModel model)
        {
            try
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(model.Employee);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = EmployeeApiClient.webApiClient.PostAsync("Employee", data).Result;
 
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
            var model = new AddEmployeeModel();

            var projectsResponse = EmployeeApiClient.webApiClient.GetAsync("Project").Result;
            var projectList = projectsResponse.Content.ReadAsAsync<IEnumerable<ProjectModel>>().Result;
            model.Projects = projectList.ToList().Select(m => new SelectListItem() { Value = m.Id.ToString(), Text = m.Name });
            IEnumerable<SelectListItem> list = projectList.ToList().Select(m => new SelectListItem() { Value = m.Id.ToString(), Text = m.Name });

            var designationsResponse = EmployeeApiClient.webApiClient.GetAsync("Designation").Result;
            var designationList = designationsResponse.Content.ReadAsAsync<IEnumerable<DesignationModel>>().Result;
            model.Designations = designationList.ToList().Select(m => new SelectListItem() { Value = m.Id.ToString(), Text = m.Name });

            IEnumerable<EmployeeModel> employeeList;
            HttpResponseMessage response = EmployeeApiClient.webApiClient.GetAsync("Employee").Result;
            employeeList = response.Content.ReadAsAsync<IEnumerable<EmployeeModel>>().Result;
            model.Employee = employeeList.FirstOrDefault(m => m.Id == id);
            return View(model);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(AddEmployeeModel model)
        {
            try
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(model.Employee);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = EmployeeApiClient.webApiClient.PutAsync("Employee", data).Result;

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
                HttpResponseMessage result;

                using (var deleteEmployeeTask = EmployeeApiClient.webApiClient.DeleteAsync("Employee/" + id.ToString()))
                {
                    deleteEmployeeTask.Wait();
                    result = deleteEmployeeTask.Result;
                }

                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
