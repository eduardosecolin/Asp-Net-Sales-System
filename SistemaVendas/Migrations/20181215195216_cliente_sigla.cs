using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaVendas.Migrations
{
    public partial class cliente_sigla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sigla",
                table: "ESTADOS",
                unicode: false,
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Sigla",
                table: "ESTADOS",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 2);
        }
    }
}
