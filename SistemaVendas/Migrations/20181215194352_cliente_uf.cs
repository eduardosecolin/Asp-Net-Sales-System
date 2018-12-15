using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaVendas.Migrations
{
    public partial class cliente_uf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estado",
                table: "CLIENTES");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTES_EstadosId",
                table: "CLIENTES",
                column: "EstadosId");

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTES_ESTADOS_EstadosId",
                table: "CLIENTES",
                column: "EstadosId",
                principalTable: "ESTADOS",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTES_ESTADOS_EstadosId",
                table: "CLIENTES");

            migrationBuilder.DropIndex(
                name: "IX_CLIENTES_EstadosId",
                table: "CLIENTES");

            migrationBuilder.AddColumn<string>(
                name: "estado",
                table: "CLIENTES",
                unicode: false,
                maxLength: 2,
                nullable: false,
                defaultValue: "");
        }
    }
}
