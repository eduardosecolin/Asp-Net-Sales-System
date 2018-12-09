using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Entities;

namespace SistemaVendas.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {

            SYSTEM_SALES_DBContext conn = new SYSTEM_SALES_DBContext();
            Vendedores vendedores = new Vendedores();
            vendedores.Nome = "Eduardo";
            vendedores.Email = "eduardo@email.com";
            vendedores.Senha = "1108";
            conn.Vendedores.Add(vendedores);
            conn.SaveChanges();
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
