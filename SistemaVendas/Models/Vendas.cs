using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SistemaVendas.Servicos;

namespace SistemaVendas.Models
{
    public partial class Vendas
    {
        private readonly SYSTEM_SALES_DBContext conexao = new SYSTEM_SALES_DBContext();
        private VendaService _vendaService;



      
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        public int VendedoresId { get; set; }
        public int ClientesId { get; set; }

        public virtual Clientes Clientes { get; set; }
        public virtual Vendedores Vendedores { get; set; }

        public virtual string ListaProdutosVenda { get; set; }

        public void Inserir(Vendas venda) {
            _vendaService = new VendaService(conexao);
            venda.Data = DateTime.Now;
            Clientes cli = conexao.Clientes.Find(venda.ClientesId);
            Vendedores vend = conexao.Vendedores.Find(venda.VendedoresId);
            venda.Clientes = cli;
            venda.Vendedores = vend;
            _vendaService.Inserir(venda);

            int id = _vendaService.GetIdVenda(venda);

            // Deserializar JSON
            List<ItensVenda> lista_itens = JsonConvert.DeserializeObject<List<ItensVenda>>(ListaProdutosVenda);
            foreach (var item in lista_itens) {
                VendasDetalhes details = new VendasDetalhes();
                details.VendaId = id;
                details.ProdutoId = int.Parse(item.CodigoProduto);
                details.QtdProdutos = decimal.Parse(item.QtdProduto);
                details.VlProduto = decimal.Parse(item.ValorUnitario);
                _vendaService.Inserir(details);
                //conexao.VendasDetalhes.Add(details);
                //conexao.SaveChanges();
            }
        }

    }
}
