using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDP.Migrations
{
    public partial class pantioDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantio_Sementes_SementesId",
                table: "Plantio");

            migrationBuilder.DropIndex(
                name: "IX_Plantio_SementesId",
                table: "Plantio");

            migrationBuilder.DropColumn(
                name: "Cultura",
                table: "Plantio");

            migrationBuilder.DropColumn(
                name: "SementesId",
                table: "Plantio");

            migrationBuilder.RenameColumn(
                name: "IdSemente",
                table: "Plantio",
                newName: "SementeId");

            migrationBuilder.AlterColumn<decimal>(
                name: "UmidadePlantio",
                table: "Plantio",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<decimal>(
                name: "DistSementes",
                table: "Plantio",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<decimal>(
                name: "Chuva",
                table: "Plantio",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.CreateIndex(
                name: "IX_Plantio_SementeId",
                table: "Plantio",
                column: "SementeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantio_Sementes_SementeId",
                table: "Plantio",
                column: "SementeId",
                principalTable: "Sementes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantio_Sementes_SementeId",
                table: "Plantio");

            migrationBuilder.DropIndex(
                name: "IX_Plantio_SementeId",
                table: "Plantio");

            migrationBuilder.RenameColumn(
                name: "SementeId",
                table: "Plantio",
                newName: "IdSemente");

            migrationBuilder.AlterColumn<double>(
                name: "UmidadePlantio",
                table: "Plantio",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<double>(
                name: "DistSementes",
                table: "Plantio",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Chuva",
                table: "Plantio",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AddColumn<int>(
                name: "Cultura",
                table: "Plantio",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SementesId",
                table: "Plantio",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plantio_SementesId",
                table: "Plantio",
                column: "SementesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantio_Sementes_SementesId",
                table: "Plantio",
                column: "SementesId",
                principalTable: "Sementes",
                principalColumn: "Id");
        }
    }
}
