using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDP.Migrations
{
    public partial class AllModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SafraIdSafra",
                table: "Funcionarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Safras",
                columns: table => new
                {
                    IdSafra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdTalhao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Safras", x => x.IdSafra);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sementes",
                columns: table => new
                {
                    IdSemente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sementes", x => x.IdSemente);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Talhoes",
                columns: table => new
                {
                    IdTalhao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Localizacao = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Area = table.Column<int>(type: "int", nullable: false),
                    TipoSolo = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CultivarAnterior = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdFazenda = table.Column<int>(type: "int", nullable: false),
                    FazendaIdFazenda = table.Column<int>(type: "int", nullable: true),
                    SafraIdSafra = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talhoes", x => x.IdTalhao);
                    table.ForeignKey(
                        name: "FK_Talhoes_Fazenda_FazendaIdFazenda",
                        column: x => x.FazendaIdFazenda,
                        principalTable: "Fazenda",
                        principalColumn: "IdFazenda");
                    table.ForeignKey(
                        name: "FK_Talhoes_Safras_SafraIdSafra",
                        column: x => x.SafraIdSafra,
                        principalTable: "Safras",
                        principalColumn: "IdSafra");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Plantio",
                columns: table => new
                {
                    IdPlantio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataPlantio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Chuva = table.Column<int>(type: "int", nullable: false),
                    TipoPlantio = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cultura = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TempoPlantio = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UmidadePlantio = table.Column<int>(type: "int", nullable: false),
                    IdSemente = table.Column<int>(type: "int", nullable: false),
                    SementesIdSemente = table.Column<int>(type: "int", nullable: true),
                    QtdSementes = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DistSementes = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adubacao = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantio", x => x.IdPlantio);
                    table.ForeignKey(
                        name: "FK_Plantio_Sementes_SementesIdSemente",
                        column: x => x.SementesIdSemente,
                        principalTable: "Sementes",
                        principalColumn: "IdSemente");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_SafraIdSafra",
                table: "Funcionarios",
                column: "SafraIdSafra");

            migrationBuilder.CreateIndex(
                name: "IX_Plantio_SementesIdSemente",
                table: "Plantio",
                column: "SementesIdSemente");

            migrationBuilder.CreateIndex(
                name: "IX_Talhoes_FazendaIdFazenda",
                table: "Talhoes",
                column: "FazendaIdFazenda");

            migrationBuilder.CreateIndex(
                name: "IX_Talhoes_SafraIdSafra",
                table: "Talhoes",
                column: "SafraIdSafra");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Safras_SafraIdSafra",
                table: "Funcionarios",
                column: "SafraIdSafra",
                principalTable: "Safras",
                principalColumn: "IdSafra");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Safras_SafraIdSafra",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Plantio");

            migrationBuilder.DropTable(
                name: "Talhoes");

            migrationBuilder.DropTable(
                name: "Sementes");

            migrationBuilder.DropTable(
                name: "Safras");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_SafraIdSafra",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "SafraIdSafra",
                table: "Funcionarios");
        }
    }
}
