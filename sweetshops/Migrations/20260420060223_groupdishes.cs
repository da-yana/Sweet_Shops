using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sweetshops.Migrations
{
    /// <inheritdoc />
    public partial class groupdishes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_GroupDish_GroupDishId",
                table: "Dishes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupDish",
                table: "GroupDish");

            migrationBuilder.RenameTable(
                name: "GroupDish",
                newName: "DishsGroup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishsGroup",
                table: "DishsGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_DishsGroup_GroupDishId",
                table: "Dishes",
                column: "GroupDishId",
                principalTable: "DishsGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_DishsGroup_GroupDishId",
                table: "Dishes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishsGroup",
                table: "DishsGroup");

            migrationBuilder.RenameTable(
                name: "DishsGroup",
                newName: "GroupDish");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupDish",
                table: "GroupDish",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_GroupDish_GroupDishId",
                table: "Dishes",
                column: "GroupDishId",
                principalTable: "GroupDish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
