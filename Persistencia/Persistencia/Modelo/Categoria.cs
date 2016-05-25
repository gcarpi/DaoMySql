using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class Categoria
    {
        public long CodigoCategoria { get; set; }
        public String Nome { get; set; }
        public Decimal Valor { get; set; }
        public int Status { get; set; }

    }
}
