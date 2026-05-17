using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sweetshops.Migrations
{
    /// <inheritdoc />
    public partial class DBCON : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DishsGroup",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DishsGroup",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DishsGroup",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DishsGroup",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DishsId",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_DishsId",
                table: "Dishes",
                column: "DishsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Dishes_DishsId",
                table: "Dishes",
                column: "DishsId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Dishes_DishsId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_DishsId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "DishsId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Dishes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DishsGroup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "DishsGroup",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Мучное" },
                    { 2, "Сладкое" },
                    { 3, "Мясное" }
                });
        }
    }
}
