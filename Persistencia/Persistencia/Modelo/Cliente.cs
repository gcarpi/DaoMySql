using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class Cliente
    {
        public long CodigoCliente{get; set;}
        public string Email { get; set; }
        public long CodigoEndereco { get; set; }
        public int Status { get; set; }
    }
}
