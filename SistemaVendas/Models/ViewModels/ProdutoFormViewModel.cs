using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Models;

namespace SistemaVendas.Models.ViewModels {
    public class ProdutoFormViewModel {

        public Produtos produto { get; set; }
        public ICollection<Medidas> medidas { get; set; }
    }
}
