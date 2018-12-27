using Microsoft.EntityFrameworkCore;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Servicos.Excecoes;


namespace SistemaVendas.Servicos {
    public class ProdutoService {

        #region Atributos

        private readonly SYSTEM_SALES_DBContext conexao;

        #endregion

        #region Construtor

        public ProdutoService(SYSTEM_SALES_DBContext con) {
            conexao = con;
        }

        #endregion

        #region Metodos

        // Listar todos os registros
        public List<Produtos> FindAll() {
            return conexao.Produtos.ToList();
        }

        // Listar um registro pelo id
        public Produtos FindPerId(int? id){
            return conexao.Produtos.Include(x => x.UnidadeMedida).FirstOrDefault(x => x.Id == id);
        }

        // Atuaçizar registro
        public void Update(Produtos produto) {
            if (!conexao.Produtos.Any(x => x.Id == produto.Id)) {
                throw new NaoEncontradoExcecao("Id não encontrado!");
            }

            try {
                conexao.Update(produto);
                conexao.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e) {
                throw new ErroConexao(e.Message);
            }
        }

        // Remover registro
        public void Remove(int id) {
            var obj = conexao.Produtos.Find(id);
            conexao.Produtos.Remove(obj);
            conexao.SaveChanges();
        }

        #endregion
    }
}
