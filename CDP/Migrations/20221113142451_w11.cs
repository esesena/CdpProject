using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDP.Migrations
{
    public partial class w11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Cultura",
                table: "Plantio",
                type: "int",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "SafraId",
                table: "Plantio",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Plantio_SafraId",
                table: "Plantio",
                column: "SafraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantio_Safras_SafraId",
                table: "Plantio",
                column: "SafraId",
                principalTable: "Safras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantio_Safras_SafraId",
                table: "Plantio");

            migrationBuilder.DropIndex(
                name: "IX_Plantio_SafraId",
                table: "Plantio");

            migrationBuilder.DropColumn(
                name: "SafraId",
                table: "Plantio");

            migrationBuilder.AlterColumn<string>(
                name: "Cultura",
                table: "Plantio",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
