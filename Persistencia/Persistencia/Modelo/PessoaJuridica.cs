﻿using System;
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
        public PessoaJuridica(int cod_pj, string nome, string razao, string cnpj, string insc_et, int cod_c, int cod_f, int status)
        {
            CodigoPessoaJuridica = cod_pj;
            NomeFantasia = nome;
            RazaoSocial = razao;
            CNPJ = cnpj;
            InscricaoEstadual = insc_et;
            CodigoCliente = cod_c;
            CodigoFornecedor = cod_f;
            Status = status;
        }

        public int CodigoPessoaJuridica { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public int CodigoCliente { get; set; }
        public int CodigoFornecedor { get; set; }
        public int Status { get; set; }
    }
}
