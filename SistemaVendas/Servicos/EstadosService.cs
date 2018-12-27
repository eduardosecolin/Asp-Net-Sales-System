using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Models;

namespace SistemaVendas.Servicos {
    public class EstadoService {

        #region Atributos

        private readonly SYSTEM_SALES_DBContext conexao;

        #endregion

        #region Construtor

        public EstadoService(SYSTEM_SALES_DBContext con){
            conexao = con;
        }

        #endregion

        #region Metodos

        // Listar todos os registros
        public List<Estados> FindAll(){
            return conexao.Estados.ToList();
        }

        #endregion
    }
}
