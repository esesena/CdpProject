using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDP.Migrations
{
    public partial class farmCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdFuncionario",
                table: "Funcionarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdFazenda",
                table: "Fazenda",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Funcionarios",
                newName: "IdFuncionario");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Fazenda",
                newName: "IdFazenda");
        }
    }
}
