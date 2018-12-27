using System;
using System.Collections.Generic;

namespace SistemaVendas.Models
{
    public partial class ItensVenda
    {
        public string CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string QtdProduto { get; set; }
        public string ValorUnitario { get; set; }
        public string Total { get; set; }
    }
}
