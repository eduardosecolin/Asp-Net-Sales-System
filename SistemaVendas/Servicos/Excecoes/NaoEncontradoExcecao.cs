using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Servicos.Excecoes {
    public class NaoEncontradoExcecao : ApplicationException{

        public NaoEncontradoExcecao(string message) : base(message){

        }
    }
}
