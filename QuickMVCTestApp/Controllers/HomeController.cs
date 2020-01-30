using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Newtonsoft.Json;
using QuickMVCTestApp.Models;

namespace QuickMVCTestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult GenerateProductReview()
        {
            var productReviewModel = new ProductReview();

            Random rnd = new Random();
            var randomNumber = rnd.Next(1, 100);
            var responseMsg = GenerateReviewAsync(randomNumber).Result;

            //Checking the response is successful or not which is sent using HttpClient  
            if (responseMsg.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var EmpResponse = responseMsg.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                productReviewModel = JsonConvert.DeserializeObject<ProductReview>(EmpResponse);

            }

            return PartialView("_ProductReview", productReviewModel);
        }

        public async Task<HttpResponseMessage> GenerateReviewAsync(int randomNumber)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri("http://localhost/CorneliusTestWebApiService/");

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                //HttpResponseMessage Res = await client.GetAsync("api/ProductReviews/Generate?randomIndex=34");
                HttpResponseMessage Res = await client.GetAsync("CorneliusTestWebApiService/api/ProductReviews/Generate?randomIndex=34");

                return Res;

            }
        }
    }
}
