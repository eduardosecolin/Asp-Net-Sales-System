using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaVendas.Migrations
{
    public partial class UoM2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "unidade_medida",
                table: "PRODUTOS");

            migrationBuilder.AddColumn<int>(
                name: "MedidasId",
                table: "PRODUTOS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTOS_MedidasId",
                table: "PRODUTOS",
                column: "MedidasId");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTOS_MEDIDAS_MedidasId",
                table: "PRODUTOS",
                column: "MedidasId",
                principalTable: "MEDIDAS",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTOS_MEDIDAS_MedidasId",
                table: "PRODUTOS");

            migrationBuilder.DropIndex(
                name: "IX_PRODUTOS_MedidasId",
                table: "PRODUTOS");

            migrationBuilder.DropColumn(
                name: "MedidasId",
                table: "PRODUTOS");

            migrationBuilder.AddColumn<string>(
                name: "unidade_medida",
                table: "PRODUTOS",
                unicode: false,
                maxLength: 3,
                nullable: false,
                defaultValue: "");
        }
    }
}
