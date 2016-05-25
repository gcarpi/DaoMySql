using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class VeiculoTemFornecedor
    {
        public long CodigoVeiculoTemFornecedor { get; set; }
        public long CodigoVeiculo { get; set; }
        public long CodigoFornecedor { get; set; }
        public int Status { get; set; }
    }
}
