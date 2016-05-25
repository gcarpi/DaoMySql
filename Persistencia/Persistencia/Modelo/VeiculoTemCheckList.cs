using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class VeiculoTemCheckList
    {
        public long CodigoVeiculoTemCheckList { get; set; }
        public string DataChecagem { get; set; }
        public long CodigoVeiculo { get; set; }
        public long CodigoCheckList { get; set; }
        public int Status { get; set; }
    }
}
