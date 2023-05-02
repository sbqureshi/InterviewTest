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
    public class OrderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //    public IActionResult Users(int? page)
        //    {
        //        int pageSize = 10;
        //        int pageNumber = (page ?? 1);
        //        IEnumerable<User> users; = // get list of users from database or API
        //return View(users.ToPagedList(pageNumber, pageSize));
        //    }

        public async Task<IActionResult> IndexAsync()
        {
            string apiUrl = "https://localhost:5001/api/orderapi";

            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            HttpClient http = new HttpClient(handler);
            HttpResponseMessage response = await http.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                // Do something with the response data, e.g. deserialize it into a model object
                var order = JsonConvert.DeserializeObject<IEnumerable<Order>>(responseBody);

                return View("Order", order);
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }
    }
}
