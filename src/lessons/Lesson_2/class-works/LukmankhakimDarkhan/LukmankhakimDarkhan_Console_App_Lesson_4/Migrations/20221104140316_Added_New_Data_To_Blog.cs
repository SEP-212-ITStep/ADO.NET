using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LukmankhakimDarkhan_Console_App_Lesson_4.Migrations
{
    public partial class Added_New_Data_To_Blog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogId", "AuthorName", "Content", "LikeCount", "Url" },
                values: new object[] { 1, "Nurik", "I'm Mickelangelo.", 10000000, "cartoonnetwork.com" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogId", "AuthorName", "Content", "LikeCount", "Url" },
                values: new object[] { 2, "Katiya", "I'm Batman.", 10000000, "tiktok.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2);
        }
    }
}
