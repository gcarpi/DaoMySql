using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class TelefoneCliente
    {
        public long CodigoTelefoneCliente { get; set; }
        public string Telefone { get; set; }
        public long CodigoCliente { get; set; }
        public int Status { get; set; }
    }
}
