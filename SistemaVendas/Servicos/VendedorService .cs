using Microsoft.EntityFrameworkCore;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Servicos.Excecoes;


namespace SistemaVendas.Servicos {
    public class VendedorService {

        #region Atributos

        private readonly SYSTEM_SALES_DBContext conexao;

        #endregion

        #region Construtor

        public VendedorService(SYSTEM_SALES_DBContext con) {
            conexao = con;
        }

        #endregion

        #region Metodos

        //Listar todos os registros
        public List<Clientes> FindAll() {
            return conexao.Clientes.ToList();
        }

        // Listar um registro pelo id
        public Vendedores FindPerId(int? id){
            return conexao.Vendedores.Find(id);
        }

        // Atualizar registro
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

        // Remover um registro
        public void Remove(int id) {
            var obj = conexao.Vendedores.Find(id);
            conexao.Vendedores.Remove(obj);
            conexao.SaveChanges();
        }

        #endregion
    }
}
