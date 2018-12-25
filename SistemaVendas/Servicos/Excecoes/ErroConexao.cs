using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Servicos.Excecoes {
    public class ErroConexao : ApplicationException{
      
       public ErroConexao(string message) : base(message){
         
       }

    }
}
