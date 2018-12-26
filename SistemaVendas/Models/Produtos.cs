using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Models
{
    public partial class Produtos
    {

        #region Global Referencias

        private readonly SYSTEM_SALES_DBContext conexao = new SYSTEM_SALES_DBContext();

        #endregion

        #region Atributos

        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o valor unitário")]
        public decimal VlUnitario { get; set; }

        public decimal Quantidade { get; set; }

        public string UnidadeMedida { get; set; }

        public string LinkFoto { get; set; }

        #endregion

        #region Metodos

        public void Inserir(Produtos produto) {
            produto.UnidadeMedida = "";
            conexao.Produtos.Add(produto);
            conexao.SaveChanges();
        }

        #endregion
    }
}
