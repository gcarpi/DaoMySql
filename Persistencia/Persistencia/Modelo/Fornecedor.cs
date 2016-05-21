using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class Fornecedor
    {
        public Fornecedor() { }
        public Fornecedor(int cod_f)
        {
            CodigoFornecedor = cod_f;
        }
        public Fornecedor(int cod_f, int status, int cod_pj)
        {
            CodigoFornecedor = cod_f;
            CodigoPessoaJuridica = cod_pj;
            Status = status;
        }

        public int CodigoFornecedor { get; set; }
        public int CodigoPessoaJuridica { get; set; }
        public int Status { get; set; }
    }
}
