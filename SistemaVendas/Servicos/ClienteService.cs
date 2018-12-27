using Microsoft.EntityFrameworkCore;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Servicos.Excecoes;


namespace SistemaVendas.Servicos {
    public class ClienteService {

        #region Atributos

        private readonly SYSTEM_SALES_DBContext conexao;

        #endregion

        #region Construtor

        public ClienteService(SYSTEM_SALES_DBContext con) {
            conexao = con;
        }

        #endregion

        #region Metodos

        // Listar todos os registros
        public List<Clientes> FindAll() {
            return conexao.Clientes.ToList();
        }

        // Listar um registro pelo id
        public Clientes FindPerId(int? id){
            return conexao.Clientes.Include(x => x.Tipo).Include(x => x.Estado).FirstOrDefault(x => x.Id == id);
        }

        // Atualizar registro
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

        // Remover um registro
        public void Remove(int id) {
            var obj = conexao.Clientes.Find(id);
            conexao.Clientes.Remove(obj);
            conexao.SaveChanges();
        }

        #endregion
    }
}
