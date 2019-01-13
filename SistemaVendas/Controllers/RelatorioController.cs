using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Utils;

namespace SistemaVendas.Controllers {
    public class RelatorioController : Controller {
        public IActionResult Index() {
            return View();
        }

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

        public IActionResult Grafico() {
            return View();
        }

        public IActionResult Comissao() {
            return View();
        }
    }
}