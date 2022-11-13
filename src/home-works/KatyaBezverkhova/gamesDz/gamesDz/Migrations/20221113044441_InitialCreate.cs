using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gamesDz.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayStyle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealiseDate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "games",
                columns: new[] { "Id", "Creator", "Name", "PlayStyle", "RealiseDate" },
                values: new object[,]
                {
                    { 1, "Blizzard", "Overwatch", "Shooter", 2016 },
                    { 2, "Blizzard", "WoW", "MM", 2002 },
                    { 3, "Ubisoft", "For Honor", "CCC", 2017 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "games");
        }
    }
}
