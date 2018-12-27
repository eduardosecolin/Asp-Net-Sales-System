using Microsoft.EntityFrameworkCore;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Servicos.Excecoes;


namespace SistemaVendas.Servicos {
    public class VendaService {

        #region Atributos

        private readonly SYSTEM_SALES_DBContext conexao;

        #endregion

        #region Construtor

        public VendaService(SYSTEM_SALES_DBContext con) {
            conexao = con;
        }

        #endregion

        #region Metodos

        //Listar todos os registros
        public List<Vendas> FindAll() {
            return conexao.Vendas.ToList();
        }

        // Listar um registro pelo id
        public Vendas FindPerId(int? id){
            return conexao.Vendas.Include(x => x.Clientes).Include(x => x.Vendedores).FirstOrDefault(x => x.Id == id);
        }

        // Atualizar registro
        public void Update(Vendas venda) {
            if (!conexao.Vendas.Any(x => x.Id == venda.Id)) {
                throw new NaoEncontradoExcecao("Id não encontrado!");
            }

            try {
                conexao.Update(venda);
                conexao.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e) {
                throw new ErroConexao(e.Message);
            }
        }

        // Remover um registro
        public void Remove(int id) {
            var obj = conexao.Vendas.Find(id);
            conexao.Vendas.Remove(obj);
            conexao.SaveChanges();
        }

        // Listar Clientes
        public List<Clientes> ListaClientes() {
            return conexao.Clientes.ToList();
        }

        // Listar vendedores
        public List<Vendedores> ListaVendedores() {
            return conexao.Vendedores.ToList();
        }

        #endregion
    }
}
