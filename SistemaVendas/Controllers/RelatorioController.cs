using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Utils;

namespace SistemaVendas.Controllers {
    public class RelatorioController : Controller {

        #region Index 

        public IActionResult Index() {
            return View();
        }

        #endregion

        #region Vendas

        [HttpGet]
        public IActionResult Vendas() {
            return View();
        }

        [HttpPost]
        public IActionResult Vendas(Relatorios relatorio) {

            if (relatorio.DataInicial.Year == 1) {

                ViewBag.ListaVendas = new Connection().ListaVendas();

            }
            else {

                ViewBag.ListaVendas = new Connection().ListaVendas(
                    relatorio.DataInicial.ToShortDateString(),
                    relatorio.DataFinal.ToShortDateString()
                );

            }
            return View();
        }

        #endregion

        #region Grafico de Vendas

        public IActionResult Grafico() {

            List<GraficoVendas> lista = new GraficoVendas().Qtd_VendasProdutos();
            
            string valores = string.Empty;
            string labels = string.Empty;
            string cores = string.Empty;

            var random = new Random();
            foreach (var item in lista) {
                int qtd = Convert.ToInt32(item.QtdVendido);
                valores += qtd.ToString() + ",";
                labels += "'" + item.DescricaoProduto + "',";
                cores += "'" + string.Format("#{0:X6}", random.Next(0x1000000)) + "',";
            }

            ViewBag.Valores = valores;
            ViewBag.Labels = labels;
            ViewBag.Cores = cores;

            return View();
        }

        #endregion

        #region Comissao de Vendedore

        public IActionResult Comissao() {
            return View();
        }

        #endregion
    }
}