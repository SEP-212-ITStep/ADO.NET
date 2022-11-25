using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameDll.Migrations
{
    /// <inheritdoc />
    public partial class AddModelSales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sales",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Developer_Name", "Game_Mode", "Game_Name", "Game_Style", "Publishing_Year", "Sales" },
                values: new object[] { "Naughty Dog", "SingleUserMode", "Uncharted 4: A Thief’s End", "action-adventure", 2016, 15000000 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sales",
                table: "Games");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Developer_Name", "Game_Mode", "Game_Name", "Game_Style", "Publishing_Year" },
                values: new object[] { null, null, null, null, 0 });
        }
    }
}
