using Microsoft.EntityFrameworkCore;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SistemaVendas.Servicos {
    public class ClienteService {

        private readonly SYSTEM_SALES_DBContext conexao;

        public ClienteService(SYSTEM_SALES_DBContext con) {
            conexao = con;
        }

        public List<Clientes> FindAll() {
            return conexao.Clientes.ToList();
        }

        public Clientes FindPerId(int id){
            return conexao.Clientes.Include(x => x.Tipo).FirstOrDefault(x => x.Id == id);
        }
    }
}
