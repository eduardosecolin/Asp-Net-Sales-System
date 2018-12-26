using Microsoft.EntityFrameworkCore;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Servicos.Excecoes;


namespace SistemaVendas.Servicos {
    public class ProdutoService {

        private readonly SYSTEM_SALES_DBContext conexao;

        public ProdutoService(SYSTEM_SALES_DBContext con) {
            conexao = con;
        }

        public List<Produtos> FindAll() {
            return conexao.Produtos.ToList();
        }

        public Produtos FindPerId(int? id){
            return conexao.Produtos.Find(id);
        }

        public void Update(Produtos produto) {
            if (!conexao.Produtos.Any(x => x.Id == produto.Id)) {
                throw new NaoEncontradoExcecao("Id não encontrado!");
            }

            try {
                produto.UnidadeMedida = "";
                conexao.Update(produto);
                conexao.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e) {
                throw new ErroConexao(e.Message);
            }
        }

        public void Remove(int id) {
            var obj = conexao.Produtos.Find(id);
            conexao.Produtos.Remove(obj);
            conexao.SaveChanges();
        }
    }
}
