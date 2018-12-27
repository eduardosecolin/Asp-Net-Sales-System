﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaVendas.Models;

namespace SistemaVendas.Migrations
{
    [DbContext(typeof(SYSTEM_SALES_DBContext))]
    partial class SYSTEM_SALES_DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaVendas.Models.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnName("bairro")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnName("celular")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnName("cidade")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasColumnName("cpf_cnpj")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnName("endereco")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("EstadosId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("Numero")
                        .HasColumnName("numero");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnName("pais")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("senha")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnName("telefone")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<int>("TipoClienteId");

                    b.HasKey("Id");

                    b.HasIndex("EstadosId");

                    b.HasIndex("TipoClienteId");

                    b.ToTable("CLIENTES");
                });

            modelBuilder.Entity("SistemaVendas.Models.Estados", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnName("Sigla")
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.HasKey("id");

                    b.ToTable("ESTADOS");
                });

            modelBuilder.Entity("SistemaVendas.Models.Medidas", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("medida")
                        .IsRequired()
                        .HasColumnName("medida")
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.HasKey("id");

                    b.ToTable("MEDIDAS");
                });

            modelBuilder.Entity("SistemaVendas.Models.Produtos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("descricao")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("LinkFoto")
                        .HasColumnName("link_foto")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int>("MedidasId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<decimal?>("Quantidade")
                        .IsRequired()
                        .HasColumnName("quantidade")
                        .HasColumnType("decimal(9, 2)");

                    b.Property<decimal?>("VlUnitario")
                        .IsRequired()
                        .HasColumnName("vl_unitario")
                        .HasColumnType("decimal(9, 2)");

                    b.HasKey("Id");

                    b.HasIndex("MedidasId");

                    b.ToTable("PRODUTOS");
                });

            modelBuilder.Entity("SistemaVendas.Models.TipoCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnName("Tipo")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("TIPO_CLIENTES");
                });

            modelBuilder.Entity("SistemaVendas.Models.Vendas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientesId")
                        .HasColumnName("Clientes_id");

                    b.Property<DateTime>("Data")
                        .HasColumnName("data")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Total")
                        .HasColumnName("total")
                        .HasColumnType("decimal(9, 2)");

                    b.Property<int>("VendedoresId")
                        .HasColumnName("Vendedores_id");

                    b.HasKey("Id");

                    b.HasIndex("ClientesId");

                    b.HasIndex("VendedoresId");

                    b.ToTable("VENDAS");
                });

            modelBuilder.Entity("SistemaVendas.Models.VendasDetalhes", b =>
                {
                    b.Property<int>("VendaId")
                        .HasColumnName("Venda_id");

                    b.Property<int>("ProdutoId")
                        .HasColumnName("Produto_id");

                    b.Property<decimal>("QtdProdutos")
                        .HasColumnName("qtd_produtos")
                        .HasColumnType("decimal(9, 2)");

                    b.Property<decimal>("VlProduto")
                        .HasColumnName("vl_produto")
                        .HasColumnType("decimal(9, 2)");

                    b.HasKey("VendaId", "ProdutoId")
                        .HasName("PK_VENDAS")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("VENDAS_DETALHES");
                });

            modelBuilder.Entity("SistemaVendas.Models.Vendedores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Senha")
                        .HasColumnName("senha")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("VENDEDORES");
                });

            modelBuilder.Entity("SistemaVendas.Models.Clientes", b =>
                {
                    b.HasOne("SistemaVendas.Models.Estados", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadosId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SistemaVendas.Models.TipoCliente", "Tipo")
                        .WithMany()
                        .HasForeignKey("TipoClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaVendas.Models.Produtos", b =>
                {
                    b.HasOne("SistemaVendas.Models.Medidas", "UnidadeMedida")
                        .WithMany()
                        .HasForeignKey("MedidasId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaVendas.Models.Vendas", b =>
                {
                    b.HasOne("SistemaVendas.Models.Clientes", "Clientes")
                        .WithMany("Vendas")
                        .HasForeignKey("ClientesId")
                        .HasConstraintName("FK_CLIENTES");

                    b.HasOne("SistemaVendas.Models.Vendedores", "Vendedores")
                        .WithMany("Vendas")
                        .HasForeignKey("VendedoresId")
                        .HasConstraintName("FK_VENDEDORES");
                });
#pragma warning restore 612, 618
        }
    }
}
