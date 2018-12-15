using System;
using System.Collections.Generic;

namespace SistemaVendas.Models
{
    public partial class Vendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        public int VendedoresId { get; set; }
        public int ClientesId { get; set; }

        public virtual Clientes Clientes { get; set; }
        public virtual Vendedores Vendedores { get; set; }
    }
}
