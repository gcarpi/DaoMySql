using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class NivelPermissaoUsuario
    {
        public long CodigoNivelPermissaoUsuario { get; set; }
        public string NivelPermissao { get; set; }
        public long CodigoUsuario { get; set; }
        public int Status { get; set; }
    }
}
