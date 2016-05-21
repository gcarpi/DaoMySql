﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class CheckList
    {
        public CheckList() { }

        public CheckList(int cod_c)
        {
            CodigoCheckList = cod_c;
        }

        public CheckList(int cod_c, string observacao, int status)
        {
            CodigoCheckList = cod_c;
            Observacao = observacao;
            Status = status;
        }

        public int CodigoCheckList { get; set; }
        public string Observacao { get; set; }
        public int Status { get; set; }
    }
}