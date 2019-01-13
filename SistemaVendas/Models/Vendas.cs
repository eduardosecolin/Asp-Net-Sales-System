using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SistemaVendas.Servicos;
using SistemaVendas.Utils;
using SistemaVendas.Servicos.Excecoes;
using System.Linq;

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

            int id = Connection.GetIdVenda(venda);

            // Deserializar JSON
            List<ItensVenda> lista_itens = JsonConvert.DeserializeObject<List<ItensVenda>>(ListaProdutosVenda);
            List<VendasDetalhes> vd = new List<VendasDetalhes>();
            var distintos = new HashSet<int>();
            var duplicado = new HashSet<int>();
            foreach (var item in lista_itens) {
                try {
                    VendasDetalhes details = new VendasDetalhes();
                    details.VendaId = id;
                    details.ProdutoId = int.Parse(item.CodigoProduto);
                    details.QtdProdutos = decimal.Parse(item.QtdProduto);
                    details.VlProduto = decimal.Parse(item.ValorUnitario);
                    
                    vd.Add(details);

                    var dup = vd.GroupBy(x => x.ProdutoId).Where(x => x.Count() > 1).Select(x => x.Key);
                    if (dup.Count() != 0) {
                        throw new Exception();
                    }else{
                        _vendaService.Inserir(details);
                    }

                }
                catch(Exception){
                    throw;
                }
            }
        }

    }
}
