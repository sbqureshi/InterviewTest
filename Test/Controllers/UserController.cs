using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Test.Models;

namespace Test.Controllers
{
    public class UserController : Controller
    {

        public UserController()
        {
        }

    

        public async Task<IActionResult> IndexAsync()
        {
            string apiUrl = "https://localhost:5001/api/userapi";

            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            HttpClient http = new HttpClient(handler);
            HttpResponseMessage response = await http.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                var user = JsonConvert.DeserializeObject<IEnumerable< User>>(responseBody);

                return View("User",user);
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }
    }
}
