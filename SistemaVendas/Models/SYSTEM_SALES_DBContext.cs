using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SistemaVendas.Models
{
    public partial class SYSTEM_SALES_DBContext : DbContext
    {
        public SYSTEM_SALES_DBContext()
        {
        }

        public SYSTEM_SALES_DBContext(DbContextOptions<SYSTEM_SALES_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }
        public virtual DbSet<Vendas> Vendas { get; set; }
        public virtual DbSet<VendasDetalhes> VendasDetalhes { get; set; }
        public virtual DbSet<Vendedores> Vendedores { get; set; }
        public virtual DbSet<TipoCliente> TipoClientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=SYSTEM_SALES_DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Clientes>(entity => {
                entity.ToTable("CLIENTES");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasColumnName("celular")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CpfCnpj)
                    .IsRequired()
                    .HasColumnName("cpf_cnpj")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasColumnName("endereco")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasColumnName("pais")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("telefone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                .IsRequired()
                .HasColumnName("senha")
                .HasMaxLength(15)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Produtos>(entity => {
                entity.ToTable("PRODUTOS");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LinkFoto)
                    .HasColumnName("link_foto")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quantidade)
                    .HasColumnName("quantidade")
                    .HasColumnType("decimal(9, 2)");

                entity.Property(e => e.UnidadeMedida)
                    .IsRequired()
                    .HasColumnName("unidade_medida")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.VlUnitario)
                    .HasColumnName("vl_unitario")
                    .HasColumnType("decimal(9, 2)");
            });

            modelBuilder.Entity<Vendas>(entity => {
                entity.ToTable("VENDAS");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientesId).HasColumnName("Clientes_id");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("datetime");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(9, 2)");

                entity.Property(e => e.VendedoresId).HasColumnName("Vendedores_id");

                entity.HasOne(d => d.Clientes)
                    .WithMany(p => p.Vendas)
                    .HasForeignKey(d => d.ClientesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENTES");

                entity.HasOne(d => d.Vendedores)
                    .WithMany(p => p.Vendas)
                    .HasForeignKey(d => d.VendedoresId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VENDEDORES");
            });

            modelBuilder.Entity<VendasDetalhes>(entity => {
                entity.HasKey(e => new { e.VendaId, e.ProdutoId })
                    .HasName("PK_VENDAS")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("VENDAS_DETALHES");

                entity.Property(e => e.VendaId).HasColumnName("Venda_id");

                entity.Property(e => e.ProdutoId).HasColumnName("Produto_id");

                entity.Property(e => e.QtdProdutos)
                    .HasColumnName("qtd_produtos")
                    .HasColumnType("decimal(9, 2)");

                entity.Property(e => e.VlProduto)
                    .HasColumnName("vl_produto")
                    .HasColumnType("decimal(9, 2)");
            });

            modelBuilder.Entity<Vendedores>(entity => {
                entity.ToTable("VENDEDORES");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasMaxLength(15)
                    .IsUnicode(false);


            });

            modelBuilder.Entity<Estados>(entity => {
                entity.ToTable("ESTADOS");


                entity.Property(e => e.Sigla)
                    .IsRequired()
                    .HasColumnName("Sigla")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoCliente>(entity => {
                entity.ToTable("TIPO_CLIENTES");


                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("Tipo")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
