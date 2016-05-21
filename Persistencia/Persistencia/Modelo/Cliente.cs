using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class Cliente
    {
        public Cliente() { }
        public Cliente(int cod_c, string email, int status)
        {
            CodigoCliente = cod_c;
            Email = email;
            Status = status;
        }
        public int CodigoCliente{get; set;}
        public string Email { get; set; }
        public int Status { get; set; }
    }
}
