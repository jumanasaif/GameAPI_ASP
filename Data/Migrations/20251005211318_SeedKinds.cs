using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp1_GameStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedKinds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kinds",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fighting" },
                    { 2, "RolePlaying" },
                    { 3, "Sports" },
                    { 4, "Kids And Family" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kinds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kinds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kinds",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kinds",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
