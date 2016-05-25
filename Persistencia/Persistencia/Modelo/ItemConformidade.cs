using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class ItemConformidade
    {
        public long CodigoItem { get; set; }
        public string Item { get; set; }
        public long CodigoCheckList { get; set; }
        public int Status { get; set; }
    }
}
