using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Servicos;

namespace SistemaVendas.Controllers
{
    public class VendedorController : Controller
    {
        #region Atributos

        readonly SYSTEM_SALES_DBContext conexao = new SYSTEM_SALES_DBContext();
        private readonly VendedorService _vendedorService;

        #endregion

        #region Construtor

        public VendedorController(VendedorService vendedorService) {
            _vendedorService = vendedorService;
        }

        #endregion

        #region Index

        public IActionResult Index()
        {
            ViewBag.Vendedores = conexao.Vendedores.ToList();
            return View();
        }

        #endregion

        #region Cadastro

        [HttpGet]
        public IActionResult Cadastro() {

            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Vendedores vendedor) {
            if (ModelState.IsValid) {

                vendedor.Inserir(vendedor);
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

            var obj = _vendedorService.FindPerId(id.Value);

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

            var obj = _vendedorService.FindPerId(id.Value);

            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int? id, Vendedores vendedor) {

            if (id != vendedor.Id) {
                return BadRequest();
            }
            try {
                _vendedorService.Update(vendedor);
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

            var obj = _vendedorService.FindPerId(id.Value);

            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(int id) {

            _vendedorService.Remove(id);
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