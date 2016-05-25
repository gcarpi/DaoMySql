using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class PessoaFisica
    {
        public long CodigoPessoaFisica { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string DataNascimento { get; set; }
        public string CNH { get; set; }
        public string Passaporte { get; set; }
        public string Naturalidade { get; set; }
        public long CodigoCliente { get; set; }
        public int Status { get; set; }
    }
}
