using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class Manutencao
    {
        public long CodigoManutencao { get; set; }
        public int TipoManutencao { get; set; }
        public string Observacao { get; set; }
        public int Status { get; set; }
    }
}
