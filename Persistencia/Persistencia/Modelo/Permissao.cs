using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class Permissao
    {
        public Permissao() { }
        public Permissao(int cod_p)
        {
            CodigoPermissao = cod_p;
        }

        public Permissao(int cod_p, int tipo, int nivel, string descricao)
        {
            CodigoPermissao = cod_p;
            Tipo = tipo;
            NivelPermissao = nivel;
            Descricao = descricao;
        }
        public int CodigoPermissao { get; set; }
        public int Tipo { get; set; }
        public int NivelPermissao { get; set; }
        public string Descricao { get; set; }
    }
}
