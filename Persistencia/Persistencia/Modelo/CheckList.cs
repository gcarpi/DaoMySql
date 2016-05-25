using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class CheckList
    {
        public long CodigoCheckList { get; set; }
        public string Observacao { get; set; }
        public int Status_CheckList { get; set; }
        public int Status { get; set; }
    }
}
