using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class NivelPermissaoUsuario
    {
        public NivelPermissaoUsuario() { }
        public NivelPermissaoUsuario(int cod_p)
        {
            CodigoNivelPermissaoUsuario = cod_p;
        }
        public NivelPermissaoUsuario(int cod_p, string nivelpermissao, int status, int cod_u)
        {
            CodigoNivelPermissaoUsuario = cod_p;
            NivelPermissao = nivelpermissao;
            CodigoUsuario = cod_u;
            Status = status;
        }

        public int CodigoNivelPermissaoUsuario { get; set; }
        public string NivelPermissao { get; set; }
        public int CodigoUsuario { get; set; }
        public int Status { get; set; }
    }
}
