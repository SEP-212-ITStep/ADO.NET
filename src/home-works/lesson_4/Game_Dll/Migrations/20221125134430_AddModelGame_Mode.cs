using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameDll.Migrations
{
    /// <inheritdoc />
    public partial class AddModelGameMode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperName = table.Column<string>(name: "Developer_Name", type: "nvarchar(max)", nullable: false),
                    GameName = table.Column<string>(name: "Game_Name", type: "nvarchar(max)", nullable: false),
                    GameStyle = table.Column<string>(name: "Game_Style", type: "nvarchar(max)", nullable: false),
                    PublishingYear = table.Column<int>(name: "Publishing_Year", type: "int", nullable: false),
                    GameMode = table.Column<string>(name: "Game_Mode", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Developer_Name", "Game_Mode", "Game_Name", "Game_Style", "Publishing_Year" },
                values: new object[] { 1, "Naughty Dog", "SingleUserMode", "Uncharted 4: A Thief’s End", "action-adventure", 2016 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
