using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Models;

namespace SistemaVendas.Servicos {
    public class TipoClienteService {

        private readonly SYSTEM_SALES_DBContext conexao;

        public TipoClienteService(SYSTEM_SALES_DBContext con) {
            conexao = con;
        }

        public List<TipoCliente> FindAll() {
            return conexao.TipoClientes.ToList();
        }
    }
}
