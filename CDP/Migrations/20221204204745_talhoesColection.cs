using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDP.Migrations
{
    public partial class talhoesColection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "PlantioTalhoes",
                columns: table => new
                {
                    PlantioId = table.Column<int>(type: "int", nullable: false),
                    TalhaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantioTalhoes", x => new { x.PlantioId, x.TalhaoId });
                    table.ForeignKey(
                        name: "FK_PlantioTalhoes_Plantio_PlantioId",
                        column: x => x.PlantioId,
                        principalTable: "Plantio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantioTalhoes_Talhoes_TalhaoId",
                        column: x => x.TalhaoId,
                        principalTable: "Talhoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PlantioTalhoes_TalhaoId",
                table: "PlantioTalhoes",
                column: "TalhaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantioTalhoes");

            migrationBuilder.AddColumn<int>(
                name: "PlantioId",
                table: "Talhoes",
                type: "int",
                nullable: true);

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
    }
}
