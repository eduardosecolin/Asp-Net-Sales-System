using System;
using System.Collections.Generic;

namespace SistemaVendas.Models
{
    public partial class Vendedores
    {
        public Vendedores()
        {
            Vendas = new HashSet<Vendas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Vendas> Vendas { get; set; }
    }
}
