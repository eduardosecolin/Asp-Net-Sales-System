using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Models
{
    public partial class Vendedores
    {
        #region Global Referencias

        readonly SYSTEM_SALES_DBContext conexao = new SYSTEM_SALES_DBContext();

        #endregion

        #region Construtor

        public Vendedores()
        {
            Vendas = new HashSet<Vendas>();
        }

        #endregion

        #region Atributos

        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o E-mail")]
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Vendas> Vendas { get; set; }

        #endregion

        #region Metodos

        public void Inserir(Vendedores vendedor) {
            vendedor.Senha = "1234";
            conexao.Vendedores.Add(vendedor);
            conexao.SaveChanges();
        }

        #endregion
    }
}
