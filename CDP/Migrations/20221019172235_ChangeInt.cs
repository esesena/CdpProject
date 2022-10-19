using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDP.Migrations
{
    public partial class ChangeInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Safras_SafraIdSafra",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantio_Sementes_SementesIdSemente",
                table: "Plantio");

            migrationBuilder.DropForeignKey(
                name: "FK_Talhoes_Fazenda_FazendaIdFazenda",
                table: "Talhoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Talhoes_Safras_SafraIdSafra",
                table: "Talhoes");

            migrationBuilder.DropIndex(
                name: "IX_Talhoes_FazendaIdFazenda",
                table: "Talhoes");

            migrationBuilder.DropColumn(
                name: "CultivarAnterior",
                table: "Talhoes");

            migrationBuilder.DropColumn(
                name: "FazendaIdFazenda",
                table: "Talhoes");

            migrationBuilder.RenameColumn(
                name: "SafraIdSafra",
                table: "Talhoes",
                newName: "SafraId");

            migrationBuilder.RenameColumn(
                name: "IdFazenda",
                table: "Talhoes",
                newName: "FazendaId");

            migrationBuilder.RenameColumn(
                name: "IdTalhao",
                table: "Talhoes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Talhoes_SafraIdSafra",
                table: "Talhoes",
                newName: "IX_Talhoes_SafraId");

            migrationBuilder.RenameColumn(
                name: "IdSemente",
                table: "Sementes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdTalhao",
                table: "Safras",
                newName: "TalhaoId");

            migrationBuilder.RenameColumn(
                name: "IdSafra",
                table: "Safras",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SementesIdSemente",
                table: "Plantio",
                newName: "SementesId");

            migrationBuilder.RenameColumn(
                name: "IdPlantio",
                table: "Plantio",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Plantio_SementesIdSemente",
                table: "Plantio",
                newName: "IX_Plantio_SementesId");

            migrationBuilder.RenameColumn(
                name: "SafraIdSafra",
                table: "Funcionarios",
                newName: "SafraId");

            migrationBuilder.RenameIndex(
                name: "IX_Funcionarios_SafraIdSafra",
                table: "Funcionarios",
                newName: "IX_Funcionarios_SafraId");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Usuarios",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Usuarios",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TipoSolo",
                table: "Talhoes",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Talhoes",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Localizacao",
                table: "Talhoes",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "Area",
                table: "Talhoes",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "UmidadePlantio",
                table: "Plantio",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TipoPlantio",
                table: "Plantio",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TempoPlantio",
                table: "Plantio",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "QtdSementes",
                table: "Plantio",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "DistSementes",
                table: "Plantio",
                type: "double",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Cultura",
                table: "Plantio",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "Chuva",
                table: "Plantio",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Adubacao",
                table: "Plantio",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionarios",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "Funcionarios",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Funcionarios",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "Funcionarios",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Fazenda",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Localizacao",
                table: "Fazenda",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "Area",
                table: "Fazenda",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Talhoes_FazendaId",
                table: "Talhoes",
                column: "FazendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Safras_SafraId",
                table: "Funcionarios",
                column: "SafraId",
                principalTable: "Safras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantio_Sementes_SementesId",
                table: "Plantio",
                column: "SementesId",
                principalTable: "Sementes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Talhoes_Fazenda_FazendaId",
                table: "Talhoes",
                column: "FazendaId",
                principalTable: "Fazenda",
                principalColumn: "IdFazenda",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Talhoes_Safras_SafraId",
                table: "Talhoes",
                column: "SafraId",
                principalTable: "Safras",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Safras_SafraId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantio_Sementes_SementesId",
                table: "Plantio");

            migrationBuilder.DropForeignKey(
                name: "FK_Talhoes_Fazenda_FazendaId",
                table: "Talhoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Talhoes_Safras_SafraId",
                table: "Talhoes");

            migrationBuilder.DropIndex(
                name: "IX_Talhoes_FazendaId",
                table: "Talhoes");

            migrationBuilder.RenameColumn(
                name: "SafraId",
                table: "Talhoes",
                newName: "SafraIdSafra");

            migrationBuilder.RenameColumn(
                name: "FazendaId",
                table: "Talhoes",
                newName: "IdFazenda");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Talhoes",
                newName: "IdTalhao");

            migrationBuilder.RenameIndex(
                name: "IX_Talhoes_SafraId",
                table: "Talhoes",
                newName: "IX_Talhoes_SafraIdSafra");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sementes",
                newName: "IdSemente");

            migrationBuilder.RenameColumn(
                name: "TalhaoId",
                table: "Safras",
                newName: "IdTalhao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Safras",
                newName: "IdSafra");

            migrationBuilder.RenameColumn(
                name: "SementesId",
                table: "Plantio",
                newName: "SementesIdSemente");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Plantio",
                newName: "IdPlantio");

            migrationBuilder.RenameIndex(
                name: "IX_Plantio_SementesId",
                table: "Plantio",
                newName: "IX_Plantio_SementesIdSemente");

            migrationBuilder.RenameColumn(
                name: "SafraId",
                table: "Funcionarios",
                newName: "SafraIdSafra");

            migrationBuilder.RenameIndex(
                name: "IX_Funcionarios_SafraId",
                table: "Funcionarios",
                newName: "IX_Funcionarios_SafraIdSafra");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Usuarios",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Usuarios",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TipoSolo",
                table: "Talhoes",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Talhoes",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Localizacao",
                table: "Talhoes",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Area",
                table: "Talhoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AddColumn<string>(
                name: "CultivarAnterior",
                table: "Talhoes",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "FazendaIdFazenda",
                table: "Talhoes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UmidadePlantio",
                table: "Plantio",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<string>(
                name: "TipoPlantio",
                table: "Plantio",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TempoPlantio",
                table: "Plantio",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "QtdSementes",
                table: "Plantio",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DistSementes",
                table: "Plantio",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Cultura",
                table: "Plantio",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Chuva",
                table: "Plantio",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<string>(
                name: "Adubacao",
                table: "Plantio",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionarios",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "Funcionarios",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Funcionarios",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "Funcionarios",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Fazenda",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Localizacao",
                table: "Fazenda",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Area",
                table: "Fazenda",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.CreateIndex(
                name: "IX_Talhoes_FazendaIdFazenda",
                table: "Talhoes",
                column: "FazendaIdFazenda");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Safras_SafraIdSafra",
                table: "Funcionarios",
                column: "SafraIdSafra",
                principalTable: "Safras",
                principalColumn: "IdSafra");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantio_Sementes_SementesIdSemente",
                table: "Plantio",
                column: "SementesIdSemente",
                principalTable: "Sementes",
                principalColumn: "IdSemente");

            migrationBuilder.AddForeignKey(
                name: "FK_Talhoes_Fazenda_FazendaIdFazenda",
                table: "Talhoes",
                column: "FazendaIdFazenda",
                principalTable: "Fazenda",
                principalColumn: "IdFazenda");

            migrationBuilder.AddForeignKey(
                name: "FK_Talhoes_Safras_SafraIdSafra",
                table: "Talhoes",
                column: "SafraIdSafra",
                principalTable: "Safras",
                principalColumn: "IdSafra");
        }
    }
}
