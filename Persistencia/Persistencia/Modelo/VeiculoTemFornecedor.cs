using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class VeiculoTemFornecedor
    {
        public VeiculoTemFornecedor() { }
        public VeiculoTemFornecedor(int cod_vf)
        {
            CodigoVeiculoTemFornecedor= cod_vf;
        }
        public VeiculoTemFornecedor(int cod_vf, int cod_v, int cod_f)
        {
            CodigoVeiculoTemFornecedor = cod_vf;
            CodigoVeiculo = cod_v;
            CodigoFornecedor = cod_f;
        }
        public int CodigoVeiculoTemFornecedor { get; set; }
        public int CodigoVeiculo { get; set; }
        public int CodigoFornecedor { get; set; }
    }
}
