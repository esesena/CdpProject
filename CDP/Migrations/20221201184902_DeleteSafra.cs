using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDP.Migrations
{
    public partial class DeleteSafra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Safras_SafraId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantio_Safras_SafraId",
                table: "Plantio");

            migrationBuilder.DropForeignKey(
                name: "FK_Talhoes_Safras_SafraId",
                table: "Talhoes");

            migrationBuilder.DropTable(
                name: "Safras");

            migrationBuilder.DropIndex(
                name: "IX_Talhoes_SafraId",
                table: "Talhoes");

            migrationBuilder.DropIndex(
                name: "IX_Plantio_SafraId",
                table: "Plantio");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_SafraId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "SafraId",
                table: "Talhoes");

            migrationBuilder.DropColumn(
                name: "SafraId",
                table: "Plantio");

            migrationBuilder.DropColumn(
                name: "SafraId",
                table: "Funcionarios");

            migrationBuilder.AddColumn<int>(
                name: "Cultura",
                table: "Plantio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Safra",
                table: "Plantio",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cultura",
                table: "Plantio");

            migrationBuilder.DropColumn(
                name: "Safra",
                table: "Plantio");

            migrationBuilder.AddColumn<int>(
                name: "SafraId",
                table: "Talhoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SafraId",
                table: "Plantio",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SafraId",
                table: "Funcionarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Safras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cultura = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TalhaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Safras", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Talhoes_SafraId",
                table: "Talhoes",
                column: "SafraId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantio_SafraId",
                table: "Plantio",
                column: "SafraId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_SafraId",
                table: "Funcionarios",
                column: "SafraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Safras_SafraId",
                table: "Funcionarios",
                column: "SafraId",
                principalTable: "Safras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantio_Safras_SafraId",
                table: "Plantio",
                column: "SafraId",
                principalTable: "Safras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Talhoes_Safras_SafraId",
                table: "Talhoes",
                column: "SafraId",
                principalTable: "Safras",
                principalColumn: "Id");
        }
    }
}
