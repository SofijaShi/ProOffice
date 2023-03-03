using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProOffice.ResourceAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedResources : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, "Resource1", 10 },
                    { 2, "Resource2", 3 },
                    { 3, "Resource3", 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
