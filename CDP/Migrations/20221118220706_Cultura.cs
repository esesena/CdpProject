using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDP.Migrations
{
    public partial class Cultura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cultura",
                table: "Safras",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cultura",
                table: "Safras");
        }
    }
}
