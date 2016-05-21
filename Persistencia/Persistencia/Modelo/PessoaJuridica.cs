using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class PessoaJuridica
    {
        public PessoaJuridica() { }
        public PessoaJuridica(int cod_pj)
        {
            CodigoPessoaJuridica = cod_pj;
        }
        public PessoaJuridica(int cod_pj, string nome, string razao, string cnpj, string insc_et)
        {
            CodigoPessoaJuridica = cod_pj;
            NomeFantasia = nome;
            RazaoSocial = razao;
            CNPJ = cnpj;
            InscricaoEstadual = insc_et;
        }

        public int CodigoPessoaJuridica { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
    }
}
