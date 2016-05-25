using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class TelefoneFornecedor
    {
        public long CodigoTelefoneFornecedor { get; set; }
        public string Telefone { get; set; }
        public long CodigoFornecedor { get; set; }
        public int Status { get; set; }
    }
}
