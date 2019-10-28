using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealTimeBlogPosts.Models;

namespace RealTimeBlogPosts.Controllers
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
            IEnumerable<Post> posts = null;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://localhost:44300/api/Blog/GetPagedData/1").Result;

                if (response.IsSuccessStatusCode)
                {
                    posts= response.Content.ReadAsAsync<IEnumerable<Post>>().Result.ToList();
                }
                else //web api sent error response 
                {
                    posts = Enumerable.Empty<Post>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(posts);
        }
        public PartialViewResult PostList(int page=1)
        {
            IEnumerable<Post> posts = null;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://localhost:44300/api/Blog/GetPagedData/"+page).Result;

                if (response.IsSuccessStatusCode)
                {
                    posts = response.Content.ReadAsAsync<IEnumerable<Post>>().Result.ToList();
                }
                else //web api sent error response 
                {
                    posts = Enumerable.Empty<Post>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return PartialView("~/Views/Home/_postsList.cshtml",posts);
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
