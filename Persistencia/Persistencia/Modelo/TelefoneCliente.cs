using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class TelefoneCliente
    {
        public TelefoneCliente() { }
        public TelefoneCliente(int cod_t)
        {
            CodigoTelefoneCliente = cod_t;
        }
        public TelefoneCliente(int cod_t, string telefone, int cod_c, int status)
        {
            CodigoTelefoneCliente = cod_t;
            Telefone = telefone;
            CodigoCliente = cod_c;
            Status = status;
        }

        public int CodigoTelefoneCliente { get; set; }
        public string Telefone { get; set; }
        public int CodigoCliente { get; set; }
        public int Status { get; set; }
    }
}
