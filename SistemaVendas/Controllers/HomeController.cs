﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Entities;
using Microsoft.AspNetCore.Http;

namespace SistemaVendas.Controllers {
    public class HomeController : Controller {

        public IActionResult Menu() {

            return View();
        }

        [HttpGet]
        public IActionResult Login(int? id) {

            if (id != null) {
                // para realizar o logout
                if (id == 0) {
                    HttpContext.Session.SetString("IdUsuarioLogado", string.Empty);
                    HttpContext.Session.SetString("NomeUsuarioLogado", string.Empty);
                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel login) {

            if (ModelState.IsValid) {

                bool loginOk = login.ValidarLogin();

                if (loginOk) {
                    // guardando informações do usuario logado na sessão
                    HttpContext.Session.SetString("IdUsuarioLogado", login.Id.ToString());
                    HttpContext.Session.SetString("NomeUsuarioLogado", login.Nome);
                    return RedirectToAction("Menu", "Home");
                }
                else {
                    TempData["ErrorLogin"] = "E-mail ou senha inválidos!";
                }
            }

            return View();
        }

        public IActionResult Index() {

            return View();
        }

        public IActionResult About() {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
