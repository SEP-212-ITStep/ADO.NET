using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gamesDz.Migrations
{
    /// <inheritdoc />
    public partial class GameCopiesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CopiesSold",
                table: "games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "games",
                keyColumn: "Id",
                keyValue: 1,
                column: "CopiesSold",
                value: 20000);

            migrationBuilder.UpdateData(
                table: "games",
                keyColumn: "Id",
                keyValue: 2,
                column: "CopiesSold",
                value: 25000);

            migrationBuilder.UpdateData(
                table: "games",
                keyColumn: "Id",
                keyValue: 3,
                column: "CopiesSold",
                value: 10000);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CopiesSold",
                table: "games");
        }
    }
}
