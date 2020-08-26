using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsStore.Migrations
{
    public partial class Init_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Watersports", "A boat for one person", "Kayak", 275m },
                    { 2, "Watersports", "Protective and fashionable", "LifeJacket", 48.95m },
                    { 3, "Soccer", "FIFA-approved size and weight", "Soccer Ball", 19.50m },
                    { 4, "Soccer", "Give your field a proffesional touch", "Corner Flags", 34.95m },
                    { 5, "Soccer", "Flat-packed 35,000-seat stadium", "Stadium", 79500m },
                    { 6, "Chess", "Improve brain efficiency by 75%", "Thinking Cap", 16m },
                    { 7, "Chess", "Secretly give your opponent a disadvantage", "Unsteadly Chair", 29.95m },
                    { 8, "Chess", "A fun game for the family", "Human Chess Board", 75m },
                    { 9, "Chess", "Gold-plated, diamond-stuffed King", "Bling-Bling Board", 1200m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);
        }
    }
}
