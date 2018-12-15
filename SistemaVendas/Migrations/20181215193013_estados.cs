using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaVendas.Migrations
{
    public partial class estados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTES",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    cpf_cnpj = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    endereco = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    numero = table.Column<int>(nullable: false),
                    bairro = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    cidade = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    estado = table.Column<string>(unicode: false, maxLength: 2, nullable: false),
                    EstadosId = table.Column<int>(nullable: false),
                    pais = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    telefone = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    celular = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    tipo = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ESTADOS",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sigla = table.Column<int>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADOS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTOS",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    descricao = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    vl_unitario = table.Column<decimal>(type: "decimal(9, 2)", nullable: false),
                    quantidade = table.Column<decimal>(type: "decimal(9, 2)", nullable: false),
                    unidade_medida = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    link_foto = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTOS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "VENDAS_DETALHES",
                columns: table => new
                {
                    Venda_id = table.Column<int>(nullable: false),
                    Produto_id = table.Column<int>(nullable: false),
                    qtd_produtos = table.Column<decimal>(type: "decimal(9, 2)", nullable: false),
                    vl_produto = table.Column<decimal>(type: "decimal(9, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDASDETALHES", x => new { x.Venda_id, x.Produto_id })
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "VENDEDORES",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    senha = table.Column<string>(unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDEDORES", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "VENDAS",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    data = table.Column<DateTime>(type: "datetime", nullable: false),
                    total = table.Column<decimal>(type: "decimal(9, 2)", nullable: false),
                    Vendedores_id = table.Column<int>(nullable: false),
                    Clientes_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDAS", x => x.id);
                    table.ForeignKey(
                        name: "FK_CLIENTES",
                        column: x => x.Clientes_id,
                        principalTable: "CLIENTES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VENDEDORES",
                        column: x => x.Vendedores_id,
                        principalTable: "VENDEDORES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VENDAS_Clientes_id",
                table: "VENDAS",
                column: "Clientes_id");

            migrationBuilder.CreateIndex(
                name: "IX_VENDAS_Vendedores_id",
                table: "VENDAS",
                column: "Vendedores_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ESTADOS");

            migrationBuilder.DropTable(
                name: "PRODUTOS");

            migrationBuilder.DropTable(
                name: "VENDAS");

            migrationBuilder.DropTable(
                name: "VENDAS_DETALHES");

            migrationBuilder.DropTable(
                name: "CLIENTES");

            migrationBuilder.DropTable(
                name: "VENDEDORES");
        }
    }
}
