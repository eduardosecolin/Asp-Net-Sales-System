using Microsoft.EntityFrameworkCore;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Servicos.Excecoes;


namespace SistemaVendas.Servicos {
    public class VendedorService {

        private readonly SYSTEM_SALES_DBContext conexao;

        public VendedorService(SYSTEM_SALES_DBContext con) {
            conexao = con;
        }

        public List<Clientes> FindAll() {
            return conexao.Clientes.ToList();
        }

        public Vendedores FindPerId(int? id){
            return conexao.Vendedores.Find(id);
        }

        public void Update(Vendedores vendedor) {
            if (!conexao.Vendedores.Any(x => x.Id == vendedor.Id)) {
                throw new NaoEncontradoExcecao("Id não encontrado!");
            }

            try {
                conexao.Update(vendedor);
                conexao.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e) {
                throw new ErroConexao(e.Message);
            }
        }

        public void Remove(int id) {
            var obj = conexao.Vendedores.Find(id);
            conexao.Vendedores.Remove(obj);
            conexao.SaveChanges();
        }
    }
}
