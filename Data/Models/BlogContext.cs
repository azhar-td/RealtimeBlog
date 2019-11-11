using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(new Post
            {
                PostId = 1,
                Author = "Azhar",
                Title = "Tech",
                SubTitle = "Software",
                ImageUrl = "https://picsum.photos/300/300",
                Body = "This is a software post",
                CreateTime = DateTime.Now.AddDays(-1)

            }, new Post
            {
                PostId = 2,
                Author = "Azhar",
                Title = "Tech",
                SubTitle = "Hardware",
                ImageUrl = "https://picsum.photos/300/300",
                Body = "This is a hardware post",
                CreateTime = DateTime.Now.AddDays(-4)
            },
            new Post
            {
                PostId = 3,
                Author = "Asad",
                Title = "Tech",
                SubTitle = "Software",
                ImageUrl = "https://picsum.photos/300/300",
                Body = "This is a software post",
                CreateTime = DateTime.Now.AddDays(-2)

            }, new Post
            {
                PostId = 4,
                Author = "Ali",
                Title = "Tech",
                SubTitle = "Hardware",
                ImageUrl = "https://picsum.photos/300/300",
                Body = "This is a hardware post",
                CreateTime = DateTime.Now.AddDays(-3)
            });
            modelBuilder.Entity<User>().HasData(new User
                {
                    ID = 1,
                    Name = "Azhar",
                    Email = "azhar.teradata@gmail.com",
                    Password = "azhar123"
                }, new User
                {
                    ID = 2,
                    Name = "Ali",
                    Email = "ali.teradata@gmail.com",
                    Password = "ali123"
                });
        }
    }
}
