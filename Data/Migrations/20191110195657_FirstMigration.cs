using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class FirstMigration : Migration
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "Body", "CreateTime", "ImageUrl", "SubTitle", "Title" },
                values: new object[,]
                {
                    { 1, "Azhar", "This is a software post", new DateTime(2019, 11, 10, 0, 56, 57, 112, DateTimeKind.Local).AddTicks(8948), "https://picsum.photos/300/300", "Software", "Tech" },
                    { 2, "Azhar", "This is a hardware post", new DateTime(2019, 11, 11, 0, 56, 57, 113, DateTimeKind.Local).AddTicks(6622), "https://picsum.photos/300/300", "Hardware", "Tech" },
                    { 3, "Asad", "This is a software post", new DateTime(2019, 11, 9, 0, 56, 57, 113, DateTimeKind.Local).AddTicks(6649), "https://picsum.photos/300/300", "Software", "Tech" },
                    { 4, "Ali", "This is a hardware post", new DateTime(2019, 11, 8, 0, 56, 57, 113, DateTimeKind.Local).AddTicks(6655), "https://picsum.photos/300/300", "Hardware", "Tech" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Email", "Name", "Password", "Token" },
                values: new object[,]
                {
                    { 1, "azhar.teradata@gmail.com", "Azhar", "azhar123", null },
                    { 2, "ali.teradata@gmail.com", "Ali", "ali123", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
