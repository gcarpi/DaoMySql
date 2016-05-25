using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class Reserva
    {
        public long NumeroReserva { get; set; }
        public string DataReserva { get; set; }
        public int FormaPagamento { get; set; }
        public int TipoRetirada { get; set; }
        public string DataEntrega { get; set; }
        public string DataRetirada { get; set; }
        public int Situacao { get; set; }
        public long CodigoCliente { get; set; }
        public long CodigoUsuario { get; set; }
        public long CodigoVeiculo { get; set; }
        public int Status { get; set; }
    }
}
