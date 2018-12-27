using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SistemaVendas.Models;

namespace SistemaVendas.Models.ViewModels {
    public class VendaFormViewModel {

        public Vendas venda { get; set; }
        public ICollection<Clientes> clientes { get; set; }
        public ICollection<Vendedores> vendedores { get; set; }

    }
}
