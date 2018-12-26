﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Servicos;

namespace SistemaVendas.Controllers
{
    public class ProdutoController : Controller
    {
        #region Atributos

        readonly SYSTEM_SALES_DBContext conexao = new SYSTEM_SALES_DBContext();
        private readonly ProdutoService _produtoService;

        #endregion

        #region Construtor

        public ProdutoController(ProdutoService produtoService) {
            _produtoService = produtoService;
        }

        #endregion

        #region Index

        public IActionResult Index() {
            ViewBag.Produtos = conexao.Produtos.ToList();
            return View();
        }

        #endregion

        #region Cadastro

        [HttpGet]
        public IActionResult Cadastro() {

            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Produtos produto) {
            if (ModelState.IsValid) {

                produto.Inserir(produto);
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

            var obj = _produtoService.FindPerId(id.Value);

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

            var obj = _produtoService.FindPerId(id.Value);

            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int? id, Produtos produto) {

            if (id != produto.Id) {
                return BadRequest();
            }
            try {
                _produtoService.Update(produto);
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

            var obj = _produtoService.FindPerId(id.Value);

            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(int id) {

            _produtoService.Remove(id);
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