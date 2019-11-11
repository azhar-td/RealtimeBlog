﻿// <auto-generated />
using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20191110195657_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Models.Post", b =>
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
                            Body = "This is a software post",
                            CreateTime = new DateTime(2019, 11, 10, 0, 56, 57, 112, DateTimeKind.Local).AddTicks(8948),
                            ImageUrl = "https://picsum.photos/300/300",
                            SubTitle = "Software",
                            Title = "Tech"
                        },
                        new
                        {
                            PostId = 2,
                            Author = "Azhar",
                            Body = "This is a hardware post",
                            CreateTime = new DateTime(2019, 11, 11, 0, 56, 57, 113, DateTimeKind.Local).AddTicks(6622),
                            ImageUrl = "https://picsum.photos/300/300",
                            SubTitle = "Hardware",
                            Title = "Tech"
                        },
                        new
                        {
                            PostId = 3,
                            Author = "Asad",
                            Body = "This is a software post",
                            CreateTime = new DateTime(2019, 11, 9, 0, 56, 57, 113, DateTimeKind.Local).AddTicks(6649),
                            ImageUrl = "https://picsum.photos/300/300",
                            SubTitle = "Software",
                            Title = "Tech"
                        },
                        new
                        {
                            PostId = 4,
                            Author = "Ali",
                            Body = "This is a hardware post",
                            CreateTime = new DateTime(2019, 11, 8, 0, 56, 57, 113, DateTimeKind.Local).AddTicks(6655),
                            ImageUrl = "https://picsum.photos/300/300",
                            SubTitle = "Hardware",
                            Title = "Tech"
                        });
                });

            modelBuilder.Entity("Data.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Email = "azhar.teradata@gmail.com",
                            Name = "Azhar",
                            Password = "azhar123"
                        },
                        new
                        {
                            ID = 2,
                            Email = "ali.teradata@gmail.com",
                            Name = "Ali",
                            Password = "ali123"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}