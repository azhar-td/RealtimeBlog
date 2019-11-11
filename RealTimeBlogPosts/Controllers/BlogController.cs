using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealTimeBlogPosts.Hubs;

namespace RealTimeBlogPosts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IDataRepository<Post> _postService;
        private IHubContext<PostsHub> HubContext{ get; set; }
        public BlogController(IDataRepository<Post> postRepository, IHubContext<PostsHub> hubcontext)
        {
            _postService = postRepository;
            HubContext= hubcontext;
        }
        // GET: api/Blog
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Post> posts = _postService.GetAll();
            return Json(posts);
        }
        // GET: api/Blog/1
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            Post post = _postService.Get(id);

            if (post == null)
            {
                return StatusCode(404);
            }

            return Json(post);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("GetPagedData/{page}")]
        public JsonResult GetPageData(int page = 1)
        {
            return Json(_postService.GetPageData(3, page));
        }
        // POST: api/Blog
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Post post)
        {
            if (post == null)
            {
                return StatusCode(400);//Validation failed
            }

            _postService.Add(post);
            await HubContext.Clients.All.SendAsync("NewPostCreated", post);
            return Json(post);
        }
        // PUT: api/Blog/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Post post)
        {
            if (post == null)
            {
                return StatusCode(400);//Validation failed
            }

            Post postToUpdate = _postService.Get(id);
            if (postToUpdate == null)
            {
                return StatusCode(404);
            }

            _postService.Update(postToUpdate, post);
            return NoContent();
        }
        // DELETE: api/Post/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Post post = _postService.Get(id);
            if (post == null)
            {
                return StatusCode(404);
            }

            _postService.Delete(post);
            return NoContent();
        }
    }
}