using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealTimeBlogPosts.Migrations
{
    public partial class RealTimeBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    SubTitle = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "Body", "CreateTime", "ImageUrl", "SubTitle", "Title" },
                values: new object[] { 1, "Azhar", "This is a first post", new DateTime(2019, 10, 24, 1, 59, 36, 63, DateTimeKind.Local).AddTicks(4978), "", "Tech", "Tech" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "Body", "CreateTime", "ImageUrl", "SubTitle", "Title" },
                values: new object[] { 2, "Azhar", "This is a first post", new DateTime(2019, 10, 25, 1, 59, 36, 64, DateTimeKind.Local).AddTicks(2086), "", "Tech", "Tech" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
