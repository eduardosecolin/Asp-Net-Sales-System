using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models.ViewModels;
using SistemaVendas.Models;
using SistemaVendas.Servicos;
using SistemaVendas.Utils;

namespace SistemaVendas.Controllers
{
    public class VendaController : Controller
    {

        #region Atributos Globais

        private readonly VendaService _vendaService;
        private readonly SYSTEM_SALES_DBContext conexao = new SYSTEM_SALES_DBContext();

        #endregion

        #region Construtor

        public VendaController(VendaService vendaService) {
            _vendaService = vendaService;
        }

        #endregion

        #region Index

        [HttpGet]
        public IActionResult Index(){
            ViewBag.ListaVendas = new Connection().ListaVendas();
            return View();
        }

        #endregion

        #region Registrar Venda

        [HttpGet]
        public IActionResult Registrar()
        {
            ViewBag.ListaProdutos = conexao.Produtos.ToList();
            var clientes = _vendaService.ListaClientes();
            var vendedores = _vendaService.ListaVendedores();
            var viewModel = new VendaFormViewModel { clientes = clientes, vendedores = vendedores };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Registrar(Vendas venda) {
            try {
                if (ModelState.IsValid) {

                    venda.Inserir(venda);
                    ViewBag.ListaProdutos = conexao.Produtos.ToList();
                    return RedirectToAction("Index");
                }

                return View();
            }catch{
                return RedirectToAction("Duplicado");
            }
        }

        #endregion

        #region Registros Duplicados

        public IActionResult Duplicado(){

            return View();
        }

        #endregion
    }
}