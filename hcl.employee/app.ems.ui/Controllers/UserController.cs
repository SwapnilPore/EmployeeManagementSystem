using app.ems.ui.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace app.ems.ui.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Validate(string userId, string password)
        {
            try
            {
                var pwd = EncryptDecrypt.Decrypt(password);

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(new { userId = userId, password = pwd });
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                // handle [FromBody] argument passing and call to api

                //HttpResponseMessage response = EmployeeApiClient.webApiClient.PostAsync("User/Validate", data).Result;

                //if (response.IsSuccessStatusCode)
                //{
                // if result ok then HttpContext.Current.Session["UserId"] == userId;

                //    HttpContext.Current.Session["UserId"] == userId;
                //}


                return RedirectToAction("Index");
            }
            catch (Exception exc)
            {
                return View();
            }
        }
    }
}