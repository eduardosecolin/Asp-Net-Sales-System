using Microsoft.EntityFrameworkCore;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Servicos.Excecoes;
using Newtonsoft.Json;
using SistemaVendas.Models.ViewModels;

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

        // pegar id da venda
        //public int GetIdVenda(Vendas venda) {
        //    //var ID = $"SELECT id FROM VENDAS WHERE id = {venda.Id} AND Vendedores_id = {venda.VendedoresId} AND Clientes_id = {venda.ClientesId}");
        //    //return ID;
        //}

        // Inserir
        public void Inserir(Vendas venda) {
            conexao.Database.ExecuteSqlCommand($"INSERT INTO VENDAS(data, total, Vendedores_id, Clientes_id) VALUES ({DateTime.Parse(venda.Data.ToShortDateString())}, {venda.Total}, {venda.VendedoresId}, {venda.ClientesId})");
        }

        public void Inserir(VendasDetalhes detalhes) {
            conexao.Database.ExecuteSqlCommand($"INSERT INTO VENDAS_DETALHES(Venda_id, Produto_id, qtd_produtos, vl_produto) VALUES ({detalhes.VendaId}, {detalhes.ProdutoId}, {detalhes.QtdProdutos}, {detalhes.VlProduto})");
        }

        #endregion
    }
}
