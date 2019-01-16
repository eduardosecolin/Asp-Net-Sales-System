using System;
using Xunit;
using SistemaVendas.Models;
using SistemaVendas.Servicos;
using System.Collections.Generic;

namespace TestesUnitarios {
    public class UnitTestModels {


        private readonly SYSTEM_SALES_DBContext conexao = new SYSTEM_SALES_DBContext();

       
        [Fact]
        public void TestLoginOk() {

            LoginModel loginModel = new LoginModel();
            loginModel.Email = "eduardo@email.com";
            loginModel.Senha = "1108";
            bool result = loginModel.ValidarLogin();
            Assert.True(result);          
        }

        [Fact]
        public void TestLoginFail() {

            LoginModel loginModel = new LoginModel();
            loginModel.Email = "eduardo@email.com";
            loginModel.Senha = "teste";
            bool result = loginModel.ValidarLogin();
            Assert.False(result);
        }

        [Fact]
        public void CheckListProdutos() {

            ProdutoService produtoService = new ProdutoService(conexao);
            var list = produtoService.FindAll();
            Assert.IsType<List<Produtos>>(list);
        }
    }
}
