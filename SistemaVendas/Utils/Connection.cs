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

        public static SqlConnection GetConnection() {
            string connection = @"Server=.\SQLEXPRESS;Database=SYSTEM_SALES_DB;Trusted_Connection=True;Integrated Security=False;User ID=sa;Password=pa$$w0rd3";

            SqlConnection con = new SqlConnection(connection);
            return con;
        }

        public static int GetIdVenda(Vendas venda) {
           
            string sql = $"SELECT id FROM VENDAS WHERE data = '{DateTime.Parse(venda.Data.ToShortDateString())}' AND Clientes_id = {venda.ClientesId} AND Vendedores_id = {venda.VendedoresId}";
            int id = 0;
            try {
                string connection = @"Server=.\SQLEXPRESS;Database=SYSTEM_SALES_DB;Trusted_Connection=True;Integrated Security=False;User ID=sa;Password=pa$$w0rd3";

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
    }
}
