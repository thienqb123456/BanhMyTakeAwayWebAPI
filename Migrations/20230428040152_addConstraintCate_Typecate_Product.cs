using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThienAspWebApi.Migrations
{
    public partial class addConstraintCate_Typecate_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TypeCates_TypeCateId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeCates_Categories_CategoryId",
                table: "TypeCates");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TypeCates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeCateId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TypeCates_TypeCateId",
                table: "Products",
                column: "TypeCateId",
                principalTable: "TypeCates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeCates_Categories_CategoryId",
                table: "TypeCates",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TypeCates_TypeCateId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeCates_Categories_CategoryId",
                table: "TypeCates");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TypeCates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TypeCateId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TypeCates_TypeCateId",
                table: "Products",
                column: "TypeCateId",
                principalTable: "TypeCates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeCates_Categories_CategoryId",
                table: "TypeCates",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
