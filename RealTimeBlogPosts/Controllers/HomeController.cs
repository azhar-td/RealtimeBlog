using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Pioneer.Pagination;
using RealTimeBlogPosts.DTO;
using Data;

namespace RealTimeBlogPosts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPaginatedMetaService _paginatedMetaService;
        private readonly IDataRepository<Post> _postService;

        public HomeController(ILogger<HomeController> logger, IPaginatedMetaService paginatedMetaService, IDataRepository<Post> postRepository)
        {
            _logger = logger;
            _paginatedMetaService = paginatedMetaService;
            _postService = postRepository;
        }

        public IActionResult Index(int id=1)
        {
            int page = id;
            DTOPost dtoPost = new DTOPost();
            using (var client = new HttpClient())
            {
                var JWToken = HttpContext.Session.GetString("JWToken");
                if (!string.IsNullOrEmpty(JWToken)) 
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWToken);
                }
                var response = client.GetAsync("https://localhost:44300/api/Blog/GetPagedData/"+page).Result;

                
                if (response.IsSuccessStatusCode)
                {
                    dtoPost.Posts = response.Content.ReadAsAsync<IEnumerable<Post>>().Result.ToList();
                }
                else //web api sent error response 
                {
                    dtoPost.Posts = Enumerable.Empty<Post>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }


            var PaginatedMeta = _paginatedMetaService.GetMetaData(_postService.GetAll().Count(), page, 3); ;
            dtoPost.PageCount = PaginatedMeta.Pages.Count;
            dtoPost.Pages = PaginatedMeta.Pages;
            return View(dtoPost);
        }
        public PartialViewResult PostList(int page=1)
        {
            //int page = id;
            DTOPost dtoPost = new DTOPost();
            using (var client = new HttpClient())
            {
                var JWToken = HttpContext.Session.GetString("JWToken");
                if (!string.IsNullOrEmpty(JWToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWToken);
                }
                var response = client.GetAsync("https://localhost:44300/api/Blog/GetPagedData/"+page).Result;

                if (response.IsSuccessStatusCode)
                {
                    dtoPost.Posts = response.Content.ReadAsAsync<IEnumerable<Post>>().Result.ToList();
                }
                else //web api sent error response 
                {
                    dtoPost.Posts = Enumerable.Empty<Post>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            var PaginatedMeta = _paginatedMetaService.GetMetaData(_postService.GetAll().Count(), page, 3); ;
            dtoPost.PageCount = PaginatedMeta.Pages.Count;
            dtoPost.Pages = PaginatedMeta.Pages;
            return PartialView("~/Views/Home/_postsList.cshtml",dtoPost);
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
