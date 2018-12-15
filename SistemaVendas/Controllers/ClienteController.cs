using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Servicos;
using SistemaVendas.Models.ViewModels;
using System.Diagnostics;

namespace SistemaVendas.Controllers
{
    public class ClienteController : Controller
    {

        SYSTEM_SALES_DBContext conexao = new SYSTEM_SALES_DBContext();
        private readonly EstadosService _estadoService;
        private readonly TipoClienteService _tipoClienteService;
        private readonly ClienteService _clienteService;

        public ClienteController(EstadosService estadosService, TipoClienteService tipoClienteService, ClienteService clienteService) {
            _estadoService = estadosService;
            _tipoClienteService = tipoClienteService;
            _clienteService = clienteService;
        }
        
        #region Index

        public IActionResult Index()
        {
            ViewBag.ListaClientes = conexao.Clientes.ToList();
            return View();
        }

        #endregion

        #region Cadastro

        [HttpGet]
        public IActionResult Cadastro() {
            var estados = _estadoService.FindAll();
            var tipos = _tipoClienteService.FindAll();
            var viewModel = new ClienteFormViewModel { estados = estados, tipo =tipos };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(Clientes cliente) {
            if(ModelState.IsValid){

                cliente.Inserir(cliente);
                return RedirectToAction("Index");
            }

            return View();
        }

        #endregion

        #region Detalhes

        public IActionResult Detalhes(int? id) {
            if (id == null) {
                return RedirectToAction("Index");//RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            var obj = _clienteService.FindPerId(id.Value);

            if (obj == null) {
                return RedirectToAction("Index");//RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            return View(obj);
        }


        #endregion
    }
}