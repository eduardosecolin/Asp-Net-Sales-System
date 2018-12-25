using Microsoft.EntityFrameworkCore;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Servicos.Excecoes;


namespace SistemaVendas.Servicos {
    public class ClienteService {

        private readonly SYSTEM_SALES_DBContext conexao;

        public ClienteService(SYSTEM_SALES_DBContext con) {
            conexao = con;
        }

        public List<Clientes> FindAll() {
            return conexao.Clientes.ToList();
        }

        public Clientes FindPerId(int? id){
            return conexao.Clientes.Include(x => x.Tipo).Include(x => x.Estado).FirstOrDefault(x => x.Id == id);
        }

        public void Update(Clientes cliente) {
            if (!conexao.Clientes.Any(x => x.Id == cliente.Id)) {
                throw new NaoEncontradoExcecao("Id não encontrado!");
            }

            try {
                conexao.Update(cliente);
                conexao.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e) {
                throw new ErroConexao(e.Message);
            }
        }

        public void Remove(int id) {
            var obj = conexao.Clientes.Find(id);
            conexao.Clientes.Remove(obj);
            conexao.SaveChanges();
        }
    }
}
