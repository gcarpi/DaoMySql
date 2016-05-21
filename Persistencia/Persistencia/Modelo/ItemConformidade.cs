using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class ItemConformidade
    {
        public ItemConformidade() { }
        public ItemConformidade(int cod_i)
        {
            CodigoItem = cod_i;
        }
        public ItemConformidade(int cod_i, string item, int cod_c)
        {
            CodigoItem = cod_i;
            Item = item;
            CodigoCheckList = cod_c;
        }

        public int CodigoItem { get; set; }
        public string Item { get; set; }
        public int CodigoCheckList { get; set; }
        public int Status { get; set; }
    }
}
