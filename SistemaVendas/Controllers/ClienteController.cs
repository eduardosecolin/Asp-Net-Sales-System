using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Servicos;
using SistemaVendas.Models.ViewModels;
using System.Diagnostics;

namespace SistemaVendas.Controllers {
    public class ClienteController : Controller {

        #region Atributos

        SYSTEM_SALES_DBContext conexao = new SYSTEM_SALES_DBContext();
        private readonly EstadoService _estadoService;
        private readonly TipoClienteService _tipoClienteService;
        private readonly ClienteService _clienteService;

        #endregion

        #region Construtor

        public ClienteController(EstadoService estadosService, TipoClienteService tipoClienteService, ClienteService clienteService) {
            _estadoService = estadosService;
            _tipoClienteService = tipoClienteService;
            _clienteService = clienteService;
        }

        #endregion

        #region Index

        public IActionResult Index() {
            ViewBag.ListaClientes = conexao.Clientes.ToList();
            return View();
        }

        #endregion

        #region Cadastro

        [HttpGet]
        public IActionResult Cadastro() {
            var estados = _estadoService.FindAll();
            var tipos = _tipoClienteService.FindAll();
            var viewModel = new ClienteFormViewModel { estados = estados, tipo = tipos };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(Clientes cliente) {
            if (ModelState.IsValid) {

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

        #region Editar

        public IActionResult Editar(int? id) {

            if (id == null) {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            var obj = _clienteService.FindPerId(id.Value);

            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            List<Estados> estados = _estadoService.FindAll();
            List<TipoCliente> tipo = _tipoClienteService.FindAll();
            ClienteFormViewModel viewModel = new ClienteFormViewModel { cliente = obj, estados = estados, tipo = tipo };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int? id, Clientes cliente) {

            if (id != cliente.Id) {
                return BadRequest();
            }
            try {
                _clienteService.Update(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e) {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }

        #endregion

        #region Excluir

        public IActionResult Excluir(int? id) {

            if (id == null) {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            var obj = _clienteService.FindPerId(id.Value);

            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(int id) {

            _clienteService.Remove(id);
            return RedirectToAction(nameof(Index));

        }

        #endregion

        #region Error

        public IActionResult Error(string message) {
            var viewModel = new Models.ViewModels.ErrorViewModel {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

        #endregion
    }
}