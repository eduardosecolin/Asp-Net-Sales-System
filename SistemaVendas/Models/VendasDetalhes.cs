using System;
using System.Collections.Generic;

namespace SistemaVendas.Models
{
    public partial class VendasDetalhes
    {
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public decimal QtdProdutos { get; set; }
        public decimal VlProduto { get; set; }
    }
}
