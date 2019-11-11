using Data.Models;
using Pioneer.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeBlogPosts.DTO
{
    public class DTOPost
    {
        public IEnumerable<Post> Posts { get; set; }

        public List<Page> Pages { get; set; }
        public int PageCount { get; set; }
    }
}
