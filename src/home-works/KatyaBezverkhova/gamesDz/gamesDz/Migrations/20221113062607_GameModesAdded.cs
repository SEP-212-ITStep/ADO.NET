using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gamesDz.Migrations
{
    /// <inheritdoc />
    public partial class GameModesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GameMode",
                table: "games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "games",
                keyColumn: "Id",
                keyValue: 1,
                column: "GameMode",
                value: "Multiplayer");

            migrationBuilder.UpdateData(
                table: "games",
                keyColumn: "Id",
                keyValue: 2,
                column: "GameMode",
                value: "Multiplayer");

            migrationBuilder.UpdateData(
                table: "games",
                keyColumn: "Id",
                keyValue: 3,
                column: "GameMode",
                value: "Multiplayer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameMode",
                table: "games");
        }
    }
}
