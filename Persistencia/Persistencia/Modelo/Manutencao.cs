using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class Manutencao
    {
        public Manutencao() { }

        public Manutencao(int cod_m)
        {
            CodigoManutencao = cod_m;
        }

        public Manutencao(int cod_m, int tipo, string obeservacao, int status)
        {
            CodigoManutencao = cod_m;
            TipoManutencao = tipo;
            Observacao = obeservacao;
            Status = status;
        }

        public int CodigoManutencao { get; set; }
        public int TipoManutencao { get; set; }
        public string Observacao { get; set; }
        public int Status { get; set; }
    }
}
