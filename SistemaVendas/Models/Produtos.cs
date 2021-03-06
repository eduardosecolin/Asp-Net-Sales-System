﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Models {
    public partial class Produtos {

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
        public decimal? VlUnitario { get; set; }

        [Required(ErrorMessage = "Informe o valor unitário")]
        public decimal? Quantidade { get; set; }

        public Medidas UnidadeMedida { get; set; }
        public int MedidasId { get; set; }

        [StringLength(1000)]
        public string LinkFoto { get; set; }

        #endregion

        #region Metodos

        public void Inserir(Produtos produto) {
            conexao.Produtos.Add(produto);
            conexao.SaveChanges();
        }

        #endregion
    }
}
