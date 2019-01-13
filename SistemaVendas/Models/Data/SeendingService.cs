using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Models.Data {
    public class SeendingService {


        private SYSTEM_SALES_DBContext conexao;

        public SeendingService(SYSTEM_SALES_DBContext con) {
            conexao = con;
        }


        public void Seed() {
            if (conexao.Estados.Any() || conexao.TipoClientes.Any() || conexao.Medidas.Any()) {
                return; // banco já foi populado
            }

            Estados e1 = new Estados() { Sigla = "AC" };
            Estados e2 = new Estados() { Sigla = "AL" };
            Estados e3 = new Estados() { Sigla = "AP" };
            Estados e4 = new Estados() { Sigla = "AM" };
            Estados e5 = new Estados() { Sigla = "BA" };
            Estados e6 = new Estados() { Sigla = "CE" };
            Estados e7 = new Estados() { Sigla = "DF" };
            Estados e8 = new Estados() { Sigla = "ES" };
            Estados e9 = new Estados() { Sigla = "GO" };
            Estados e10 = new Estados() { Sigla = "MA" };
            Estados e11 = new Estados() { Sigla = "MT" };
            Estados e12 = new Estados() { Sigla = "MS" };
            Estados e13 = new Estados() { Sigla = "MG" };
            Estados e14 = new Estados() { Sigla = "PA" };
            Estados e15 = new Estados() { Sigla = "PB" };
            Estados e16 = new Estados() { Sigla = "PR" };
            Estados e17 = new Estados() { Sigla = "PE" };
            Estados e18 = new Estados() { Sigla = "PI" };
            Estados e19 = new Estados() { Sigla = "RJ" };
            Estados e20 = new Estados() { Sigla = "RN" };
            Estados e21 = new Estados() { Sigla = "RS" };
            Estados e22 = new Estados() { Sigla = "RO" };
            Estados e23 = new Estados() { Sigla = "RR" };
            Estados e24 = new Estados() { Sigla = "SC" };
            Estados e25 = new Estados() { Sigla = "SP" };
            Estados e26 = new Estados() { Sigla = "SE" };
            Estados e27 = new Estados() { Sigla = "TO" };

            TipoCliente t1 = new TipoCliente() { Tipo = "Físico" };
            TipoCliente t2 = new TipoCliente() { Tipo = "Jurídico" };

            Medidas m1 = new Medidas() { medida = "UN" };
            Medidas m2 = new Medidas() { medida = "CX" };
            Medidas m3 = new Medidas() { medida = "KG" };
            Medidas m4 = new Medidas() { medida = "LT" };
            Medidas m5 = new Medidas() { medida = "GR" };
            Medidas m6 = new Medidas() { medida = "SM" };

            conexao.AddRange(e1, e2, e3, e4, e5, e6, e7, e8, e9, e10, e11, e12, e13, e14, e15,
                             e16, e17, e18, e20, e21, e22, e23, e24, e25, e26, e27);
            conexao.AddRange(t1, t2);
            conexao.Medidas.AddRange(m1, m2, m3, m4, m5, m6);

            conexao.SaveChanges();

        }
    }
}
