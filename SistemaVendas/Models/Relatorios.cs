using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Models {
    public class Relatorios {

        #region Atributos

        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }

        #endregion
    }

    public class GraficoVendas {

        #region Atributos Globais

        private readonly SYSTEM_SALES_DBContext conexao = new SYSTEM_SALES_DBContext();

        #endregion

        #region Atributos Locais

        public decimal QtdVendido { get; set; }
        public int CodProduto { get; set; }
        public string DescricaoProduto { get; set; }

        #endregion

        #region Metodos Grafico

        public List<GraficoVendas> Qtd_VendasProdutos() {

            var result = from vd in conexao.VendasDetalhes
                         join p in conexao.Produtos on vd.ProdutoId equals p.Id
                         group new { vd , p } by new { vd.ProdutoId, p.Nome } into g
                         select new {total = g.Sum(x => x.vd.QtdProdutos), nome = g.Key.Nome };


            List<GraficoVendas> listaGV = new List<GraficoVendas>();
            GraficoVendas gv;
            foreach (var item in result.ToList()) {
                gv = new GraficoVendas();
                gv.DescricaoProduto = item.nome;
                gv.QtdVendido = item.total;

                listaGV.Add(gv);
            }

            return listaGV;
        }

        #endregion

    }
}
