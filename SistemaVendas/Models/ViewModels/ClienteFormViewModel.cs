using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Models;

namespace SistemaVendas.Models.ViewModels {
    public class ClienteFormViewModel {

        public Clientes cliente { get; set; }
        public ICollection<Estados> estados { get; set; }

        public ICollection<TipoCliente> tipo { get; set; }
    }
}
