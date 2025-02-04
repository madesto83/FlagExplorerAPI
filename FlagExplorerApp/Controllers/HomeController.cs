using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using FlagExplorerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FlagExplorerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<ActionResult> Index4()
        {
            string baseUrl = "https://localhost:7133/";

       
            HttpResponseMessage request = new HttpResponseMessage();

                HttpClientHandler handler = new HttpClientHandler();
                HttpClient client = new HttpClient(handler);
               
           
                List<Country> countries = new List<Country>();

           
                var res = await client.GetAsync(baseUrl + "api/Countries");
                //Checking the response is successful or not which is sent using HttpClient
                if (res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    countries = JsonConvert.DeserializeObject<List<Country>>(EmpResponse);
                }
             
                return View(countries);
            
        }

        public async Task<ActionResult> Index()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7133/")
            };

            client.DefaultRequestHeaders.Add("x-user-email", "your-email");
            client.DefaultRequestHeaders.Add("x-api-key", "your-key");
            client.DefaultRequestHeaders.Add("x-store-key", "3");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


            var res = await client.GetAsync(client.BaseAddress + "api/Countries");

            //Checking the response is successful or not which is sent using HttpClient
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var EmpResponse = res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Employee list
                var countries = JsonConvert.DeserializeObject<List<Country>>(EmpResponse);

                if(countries != null)
                return View(countries);
            }

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
    }
}
