using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Models {

    [Table(name:"MEDIDAS")]
    public class Medidas {


        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(2)]
        public string medida { get; set; }
    }
}
