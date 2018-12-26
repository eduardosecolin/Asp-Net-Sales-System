using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendas.Models
{   
    public partial class Clientes
    {
        #region Global Referencias

        SYSTEM_SALES_DBContext conexao = new SYSTEM_SALES_DBContext();

        #endregion

        #region Construtor

        public Clientes()
        {
            Vendas = new HashSet<Vendas>();
        }

        #endregion

        #region Atributos

        public int Id { get; set; }

        [Required(ErrorMessage ="Informe o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o CPF ou CNPJ")]
        public string CpfCnpj { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Informe o e-mail")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Informe o número")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Informe o bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe a cidade")]
        public string Cidade { get; set; }
        public Estados Estado { get; set; }
        public int EstadosId { get; set; }
        public string Pais { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        public string Celular { get; set; }
        public TipoCliente Tipo { get; set; }
        public int TipoClienteId { get; set; }
        
        [StringLength(15)]
        public string Senha { get; set; }

        public virtual ICollection<Vendas> Vendas { get; set; }

        #endregion

        #region Metodos

        public void Inserir(Clientes clientes){
            clientes.Senha = "1234";
            conexao.Clientes.Add(clientes);
            conexao.SaveChanges();
        }
    
        #endregion
    }
}
