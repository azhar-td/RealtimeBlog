using RealTimeBlogPosts.Models;
using RealTimeBlogPosts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeBlogPosts.BusinessLogic
{
    public class PostManager:IDataRepository<Post>
    {
        readonly BlogContext _blogContext;

        public PostManager(BlogContext context)
        {
            _blogContext = context;
        }

        public IEnumerable<Post> GetAll()
        {
            return _blogContext.Posts.ToList();
        }

        public Post Get(int id)
        {
            return _blogContext.Posts
                  .FirstOrDefault(e => e.PostId == id);
        }
        public IEnumerable<Post> GetPageData(int count,int page = 1)
        {
            return _blogContext
            .Posts
            .OrderByDescending(x => x.CreateTime)
            .Skip((page - 1) * count)
            .Take(count)
            .ToList();
        }
        public void Add(Post entity)
        {
            _blogContext.Posts.Add(entity);
            _blogContext.SaveChanges();
        }

        public void Update(Post post, Post entity)
        {
            post.Author = entity.Author;
            post.Title = entity.Title;
            post.SubTitle = entity.SubTitle;
            post.ImageUrl = entity.ImageUrl;
            post.Body = entity.Body;
            post.CreateTime = entity.CreateTime;
            _blogContext.Posts.Update(post);
            _blogContext.SaveChanges();
        }

        public void Delete(Post post)
        {
            _blogContext.Posts.Remove(post);
            _blogContext.SaveChanges();
        }
    }
}
