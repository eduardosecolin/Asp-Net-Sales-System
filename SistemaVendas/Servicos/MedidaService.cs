using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Models;

namespace SistemaVendas.Servicos {
    public class MedidaService {

        #region Atributos

        private readonly SYSTEM_SALES_DBContext conexao;

        #endregion

        #region Construtor

        public MedidaService(SYSTEM_SALES_DBContext con){
            conexao = con;
        }

        #endregion

        #region Metodos

        //Listar todos os registros
        public List<Medidas> FindAll() {
            return conexao.Medidas.ToList();
        }

        #endregion
    }
}
