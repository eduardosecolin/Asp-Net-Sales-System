using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Entities;

namespace SistemaVendas.Models {
    public class LoginModel {

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Informe o e-mail")]
        [EmailAddress(ErrorMessage ="O e-mail informado é inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Informe a senha")]
        public string Senha { get; set; }

        #region Metodos

        // pegar a conexão
        private SYSTEM_SALES_DBContext GetConnection(){
            SYSTEM_SALES_DBContext conn = new SYSTEM_SALES_DBContext();
            return conn;
        }

        // validar o ligin
        public bool ValidarLogin(){
            var sql = GetConnection().Vendedores.Select(x => x.Email == Email && x.Senha == Senha);

            if(sql.FirstOrDefault()){
                return true;
            }else{
                return false;
            }

        }

        #endregion

    }
}
