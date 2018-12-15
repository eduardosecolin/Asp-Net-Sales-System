using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Models;

namespace SistemaVendas.Servicos {
    public class EstadosService {


        private readonly SYSTEM_SALES_DBContext conexao;

        public EstadosService(SYSTEM_SALES_DBContext con){
            conexao = con;
        }

        public List<Estados> FindAll(){
            return conexao.Estados.ToList();
        }
    }
}
