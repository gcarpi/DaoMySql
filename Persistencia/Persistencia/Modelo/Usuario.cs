using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class Usuario
    {
        public long CodigoUsuario { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public long CodigoPermissao { get; set; }
        public int Status { get; set; }
    }
}
