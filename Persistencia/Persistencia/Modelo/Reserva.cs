using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class Reserva
    {
        public Reserva() { }

        public Reserva(int cod_r)
        {
            CodigoReserva = cod_r;
        }

        public Reserva(int cod_r, string data_r, int forma_p, int tipo, string data_e, string data_rt, int situacao, int cod_c, int cod_u, int cod_v)
        {
            CodigoReserva = cod_r;
            DataReserva = data_r;
            FormaPagamento = forma_p;
            DataEntrega = data_e;
            DataRetirada = data_rt;
            Situacao = situacao;
            CodigoCliente = cod_c;
            CodigoUsuario = cod_u;
            CodigoVeiculo = cod_v;
        }

        public int CodigoReserva { get; set; }
        public string DataReserva { get; set; }
        public int FormaPagamento { get; set; }
        public int TipoRetirada { get; set; }
        public string DataEntrega { get; set; }
        public string DataRetirada { get; set; }
        public int Situacao { get; set; }
        public int CodigoCliente { get; set; }
        public int CodigoUsuario { get; set; }
        public int CodigoVeiculo { get; set; }
    }
}
