using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sweetshops.Migrations
{
    /// <inheritdoc />
    public partial class Pages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriesDish",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "CookingTime",
                table: "Dishes",
                newName: "GroupDishId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Dishes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CookingTimeMinutes",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionDish",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DishName",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "GroupDish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupDish", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_GroupDishId",
                table: "Dishes",
                column: "GroupDishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_GroupDish_GroupDishId",
                table: "Dishes",
                column: "GroupDishId",
                principalTable: "GroupDish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_GroupDish_GroupDishId",
                table: "Dishes");

            migrationBuilder.DropTable(
                name: "GroupDish");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_GroupDishId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "CookingTimeMinutes",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "DescriptionDish",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "DishName",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "GroupDishId",
                table: "Dishes",
                newName: "CookingTime");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Dishes",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "CategoriesDish",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
