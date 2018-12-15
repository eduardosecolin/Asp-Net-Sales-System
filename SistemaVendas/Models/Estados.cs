using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Models {

    [Table(name:"ESTADOS")]
    public class Estados {


        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(2)]
        public string Sigla { get; set; }
    }
}
