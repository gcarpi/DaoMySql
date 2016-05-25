using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class Permissao
    {
        public long CodigoPermissao { get; set; }
        public int Tipo { get; set; }
        public string Descricao { get; set; }
        public int Status { get; set; }
    }
}
