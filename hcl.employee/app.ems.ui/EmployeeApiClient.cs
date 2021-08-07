using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;


namespace app.ems.ui
{
    public static class EmployeeApiClient
    {
        public static HttpClient webApiClient = new HttpClient();

        static EmployeeApiClient()
        {
            webApiClient.BaseAddress = new Uri("http://localhost:58525/api/");
            webApiClient.DefaultRequestHeaders.Clear();
            webApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}