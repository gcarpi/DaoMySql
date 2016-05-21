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

        public Reserva(int num_r)
        {
            NumeroReserva = num_r;
        }

        public Reserva(int num_r, string data_r, int forma_p, int tipo, string data_e, string data_rt, int situacao, int status, int cod_c, int cod_u, int cod_v)
        {
            NumeroReserva = num_r;
            DataReserva = data_r;
            FormaPagamento = forma_p;
            DataEntrega = data_e;
            DataRetirada = data_rt;
            Situacao = situacao;
            Status = status;
            CodigoCliente = cod_c;
            CodigoUsuario = cod_u;
            CodigoVeiculo = cod_v;
        }

        public int NumeroReserva { get; set; }
        public string DataReserva { get; set; }
        public int FormaPagamento { get; set; }
        public int TipoRetirada { get; set; }
        public string DataEntrega { get; set; }
        public string DataRetirada { get; set; }
        public int Situacao { get; set; }
        public int Status { get; set; }
        public int CodigoCliente { get; set; }
        public int CodigoUsuario { get; set; }
        public int CodigoVeiculo { get; set; }
    }
}
