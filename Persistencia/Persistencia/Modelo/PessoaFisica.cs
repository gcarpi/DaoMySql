using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class PessoaFisica
    {
        public PessoaFisica() { }
        public PessoaFisica(int cod_pf)
        {
            CodigoPessoaFisica = cod_pf;
        }
        public PessoaFisica(int cod_pf, string nome, string rg, string cpf, string data_n, string cnh, string passaporte, string naturalidade, int status)
        {
            CodigoPessoaFisica = cod_pf;
            Nome = nome;
            RG = rg;
            CPF = cpf;
            DataNascimento = data_n;
            CNH = cnh;
            Passaporte = passaporte;
            Naturalidade = naturalidade;
            Status = status;
        }

        public int CodigoPessoaFisica { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string DataNascimento { get; set; }
        public string CNH { get; set; }
        public string Passaporte { get; set; }
        public string Naturalidade { get; set; }
        public int Status { get; set; }
    }
}
