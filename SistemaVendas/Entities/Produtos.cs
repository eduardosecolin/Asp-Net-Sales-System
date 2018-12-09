using System;
using System.Collections.Generic;

namespace SistemaVendas.Entities
{
    public partial class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal VlUnitario { get; set; }
        public decimal Quantidade { get; set; }
        public string UnidadeMedida { get; set; }
        public string LinkFoto { get; set; }
    }
}
