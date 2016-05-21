using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class TelefoneFornecedor
    {
        public TelefoneFornecedor() { }
        public TelefoneFornecedor(int cod_t)
        {
            CodigoTelefoneFornecedor = cod_t;
        }
        public TelefoneFornecedor(int cod_t, string telefone, int cod_f, int status)
        {
            CodigoTelefoneFornecedor = cod_t;
            Telefone = telefone;
            CodigoFornecedor = cod_f;
            Status = status;
        }

        public int CodigoTelefoneFornecedor { get; set; }
        public string Telefone { get; set; }
        public int CodigoFornecedor { get; set; }
        public int Status { get; set; }
    }
}
