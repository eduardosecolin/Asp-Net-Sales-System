using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaVendas.Migrations
{
    public partial class cliente_tipo_cs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipo",
                table: "CLIENTES");

            migrationBuilder.AddColumn<int>(
                name: "TipoClienteId",
                table: "CLIENTES",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTES_TipoClienteId",
                table: "CLIENTES",
                column: "TipoClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTES_TIPO_CLIENTES_TipoClienteId",
                table: "CLIENTES",
                column: "TipoClienteId",
                principalTable: "TIPO_CLIENTES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTES_TIPO_CLIENTES_TipoClienteId",
                table: "CLIENTES");

            migrationBuilder.DropIndex(
                name: "IX_CLIENTES_TipoClienteId",
                table: "CLIENTES");

            migrationBuilder.DropColumn(
                name: "TipoClienteId",
                table: "CLIENTES");

            migrationBuilder.AddColumn<string>(
                name: "tipo",
                table: "CLIENTES",
                unicode: false,
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
