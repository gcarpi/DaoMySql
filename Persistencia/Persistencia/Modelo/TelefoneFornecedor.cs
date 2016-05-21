using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    class TelefoneFornecedor
    {
        public TelefoneFornecedor() { }
        public TelefoneFornecedor(int cod_t)
        {
            CodigoTelefoneFornecedor = cod_t;
        }
        public TelefoneFornecedor(int cod_t, string telefone, int cod_f)
        {
            CodigoTelefoneFornecedor = cod_t;
            Telefone = telefone;
            CodigoFornecedor = cod_f;
        }

        public int CodigoTelefoneFornecedor { get; set; }
        public string Telefone { get; set; }
        public int CodigoFornecedor { get; set; }
    }
}
