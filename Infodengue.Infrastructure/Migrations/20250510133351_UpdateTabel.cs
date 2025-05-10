using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infodengue.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodigoIBGE",
                table: "Relatorios",
                newName: "CodigoIbge");

            migrationBuilder.AlterColumn<int>(
                name: "SemanaInicio",
                table: "Relatorios",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SemanaFim",
                table: "Relatorios",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CodigoIbge",
                table: "Relatorios",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodigoIbge",
                table: "Relatorios",
                newName: "CodigoIBGE");

            migrationBuilder.AlterColumn<string>(
                name: "SemanaInicio",
                table: "Relatorios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "SemanaFim",
                table: "Relatorios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoIBGE",
                table: "Relatorios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
