using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDP.Migrations
{
    public partial class PlantioTalhoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlantioId",
                table: "Talhoes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Maturacao",
                table: "Sementes",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Talhoes_PlantioId",
                table: "Talhoes",
                column: "PlantioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Talhoes_Plantio_PlantioId",
                table: "Talhoes",
                column: "PlantioId",
                principalTable: "Plantio",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Talhoes_Plantio_PlantioId",
                table: "Talhoes");

            migrationBuilder.DropIndex(
                name: "IX_Talhoes_PlantioId",
                table: "Talhoes");

            migrationBuilder.DropColumn(
                name: "PlantioId",
                table: "Talhoes");

            migrationBuilder.AlterColumn<string>(
                name: "Maturacao",
                table: "Sementes",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
