using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThienAspWebApi.Migrations
{
    public partial class addTimeCreatedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeCreated",
                table: "Products",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeCreated",
                table: "Products");
        }
    }
}
