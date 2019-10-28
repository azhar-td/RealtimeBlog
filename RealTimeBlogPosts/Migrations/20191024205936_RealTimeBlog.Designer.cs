﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealTimeBlogPosts.Models;

namespace RealTimeBlogPosts.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20191024205936_RealTimeBlog")]
    partial class RealTimeBlog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RealTimeBlogPosts.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            Author = "Azhar",
                            Body = "This is a first post",
                            CreateTime = new DateTime(2019, 10, 24, 1, 59, 36, 63, DateTimeKind.Local).AddTicks(4978),
                            ImageUrl = "",
                            SubTitle = "Tech",
                            Title = "Tech"
                        },
                        new
                        {
                            PostId = 2,
                            Author = "Azhar",
                            Body = "This is a first post",
                            CreateTime = new DateTime(2019, 10, 25, 1, 59, 36, 64, DateTimeKind.Local).AddTicks(2086),
                            ImageUrl = "",
                            SubTitle = "Tech",
                            Title = "Tech"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
