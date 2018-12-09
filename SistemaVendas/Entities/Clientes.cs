using System;
using System.Collections.Generic;

namespace SistemaVendas.Entities
{
    public partial class Clientes
    {
        public Clientes()
        {
            Vendas = new HashSet<Vendas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Vendas> Vendas { get; set; }
    }
}
