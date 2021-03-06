﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Models;

namespace SistemaVendas.Servicos {
    public class TipoClienteService {

        #region Atributos

        private readonly SYSTEM_SALES_DBContext conexao;

        #endregion

        #region Construtor

        public TipoClienteService(SYSTEM_SALES_DBContext con) {
            conexao = con;
        }

        #endregion

        #region Metodos

        // Listar todos os registros
        public List<TipoCliente> FindAll() {
            return conexao.TipoClientes.ToList();
        }

        #endregion
    }
}
