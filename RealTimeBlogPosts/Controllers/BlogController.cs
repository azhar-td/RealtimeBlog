using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealTimeBlogPosts.Hubs;
using RealTimeBlogPosts.Models;
using RealTimeBlogPosts.Repository;

namespace RealTimeBlogPosts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : Controller
    {
        private readonly IDataRepository<Post> _postRepository;
        private IHubContext<PostsHub> HubContext
        { get; set; }
        public BlogController(IDataRepository<Post> postRepository, IHubContext<PostsHub> hubcontext)
        {
            _postRepository = postRepository;
            HubContext= hubcontext;
        }
        // GET: api/Blog
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Post> posts = _postRepository.GetAll();
            return Json(posts);
        }
        // GET: api/Blog/1
        [HttpGet("{id}", Name = "Get")]
        public JsonResult Get(int id)
        {
            Post post = _postRepository.Get(id);

            if (post == null)
            {
                return Json("The post record couldn't be found.");
            }

            return Json(post);
        }
        [HttpGet("{page}",Name = "GetPagedData")]
        [Route("GetPagedData/{page}")]
        public JsonResult GetPageData(int page = 1)
        {
            return Json(_postRepository.GetPageData(2, page));
        }
        // POST: api/Blog
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Post post)
        {
            if (post == null)
            {
                return Json("Post is null.");
            }

            _postRepository.Add(post);
            await HubContext.Clients.All.SendAsync("NewPostCreated", post);
            return Json(post);
        }
        // PUT: api/Blog/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Post post)
        {
            if (post == null)
            {
                return BadRequest("Post is null.");
            }

            Post postToUpdate = _postRepository.Get(id);
            if (postToUpdate == null)
            {
                return NotFound("The Post record couldn't be found.");
            }

            _postRepository.Update(postToUpdate, post);
            return NoContent();
        }
        // DELETE: api/Post/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Post post = _postRepository.Get(id);
            if (post == null)
            {
                return NotFound("The Post record couldn't be found.");
            }

            _postRepository.Delete(post);
            return NoContent();
        }
    }
}