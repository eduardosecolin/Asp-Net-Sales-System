using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendas.Models {

    [Table(name:"TIPO_CLIENTES")]
    public class TipoCliente {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Tipo { get; set; }
    }
}
