using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SistemaVendas.Models;

namespace SistemaVendas.Utils {
    public class Connection {

        #region GetConnection

        public SqlConnection GetConnection() {
            string connection = @"Server=.\SQLEXPRESS;Database=SYSTEM_SALES_DB;Trusted_Connection=True;Integrated Security=SSPI;";

            SqlConnection con = new SqlConnection(connection);
            return con;
        }

        #endregion

        #region Pegar Id Venda

        public static int GetIdVenda(Vendas venda) {
           
            string sql = $"SELECT id FROM VENDAS WHERE data = '{DateTime.Parse(venda.Data.ToShortDateString())}' AND Clientes_id = {venda.ClientesId} AND Vendedores_id = {venda.VendedoresId}";
            int id = 0;
            try {
                string connection = @"Server=.\SQLEXPRESS;Database=SYSTEM_SALES_DB;Trusted_Connection=True";

                SqlConnection con = new SqlConnection(connection);
                //GetConnection().Open();
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    reader.Read();
                    id = Convert.ToInt32(reader["id"]);
                }
                con.Close();
                return id;
            }
            catch (Exception) {

                throw;
            }

        }

        #endregion

        #region Lista de Vendas

        public List<Vendas> ListaVendas(){
            
            return RetornaListaVendas("1900/01/01","2200/01/01");
        }

        public List<Vendas> ListaVendas(string dataInicial, string dataFinal) {

            return RetornaListaVendas(dataInicial, dataFinal);
        }

        private List<Vendas> RetornaListaVendas(string dataInicial, string dataFinal) {
            List<Vendas> listaVendas = new List<Vendas>();
            string sql =  "SELECT "                   +
                              "v.id, "                +
                              "v.data, "              +
                              "v.total, "             +
                              "vd.nome as Vendedor, " +
                              "c.nome as Cliente "    +
                            "FROM "     +
                              "VENDAS v "                                              +
                              "INNER JOIN VENDEDORES vd on (v.Vendedores_id = vd.id) " +
                              "INNER JOIN CLIENTES c on (v.Clientes_id = c.id) "       +
                            "WHERE "    +
                             $"v.data >= '{dataInicial}' "   +
                             $"AND v.data <= '{dataFinal}' " +
                            "ORDER BY " +
                              "data, "  +
                              "total";

            try {
                string connection = @"Server=.\SQLEXPRESS;Database=SYSTEM_SALES_DB;Trusted_Connection=True;Integrated Security=SSPI;";
                using (SqlConnection con = new SqlConnection(connection)) {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read()) {
                        Vendas item = new Vendas();
                        item.Clientes = new Clientes();
                        item.Vendedores = new Vendedores();
                        item.Id = Convert.ToInt16(reader["id"]);
                        item.Data = Convert.ToDateTime(reader["data"]);
                        item.Total = Convert.ToDecimal(reader["total"]);
                        item.Clientes.Nome = reader["Cliente"].ToString();
                        item.Vendedores.Nome = reader["Vendedor"].ToString();
                        listaVendas.Add(item);
                    }
                }


                return listaVendas;
            }
            catch (Exception ex) {

                string msg = ex.Message;
                throw;
            }
        }

        #endregion

        #region Listar Grafico de Vendas

        public List<GraficoVendas> ListaGrafico(){

            string sql = @"select sum(vd.qtd_produtos) as qtd, p.nome as produto
                            from VENDAS_DETALHES vd
                            inner join PRODUTOS p on vd.Produto_id = p.id 
                            group by 
                            p.nome";

            List<GraficoVendas> listaGV = new List<GraficoVendas>();
            try {
                string connection = @"Server=.\SQLEXPRESS;Database=SYSTEM_SALES_DB;Trusted_Connection=True;Integrated Security=SSPI;";
                using (SqlConnection con = new SqlConnection(connection)) {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    
                    GraficoVendas item;
                    while (reader.Read()) {
                         item = new GraficoVendas();
                        item.QtdVendido = Convert.ToDecimal(reader["qtd"]);
                        item.DescricaoProduto = reader["produto"].ToString();
                        listaGV.Add(item);
                    }
                }


                return listaGV;
            }
            catch (Exception ex) {

                string msg = ex.Message;
                throw;
            }

        }

        #endregion

        #region Update Quantidade de produtos

        public static void UpdateQtdVendas(decimal qtd, int id){
            var sql = $" UPDATE PRODUTOS SET quantidade = (quantidade - {qtd})" +
                                  $" WHERE id = {id}";

            try {
                string connection = @"Server=.\SQLEXPRESS;Database=SYSTEM_SALES_DB;Trusted_Connection=True;Integrated Security=SSPI;";
                using (SqlConnection con = new SqlConnection(connection)) {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }
            }catch(Exception){
                throw;
            }
        }

        #endregion

    }
}
