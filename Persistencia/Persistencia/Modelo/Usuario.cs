using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class Usuario
    {
        public Usuario() { }
        public Usuario(int cod_u, string nome, string rg, string cpf, string login, string senha, int cod_p, int status)
        {
            CodigoUsuario = cod_u;
            Nome = nome;
            RG = rg;
            CPF = cpf;
            Login = login;
            Senha = senha;
            CodigoPermissao = cod_p;
            Status = status;
        }
        public int CodigoUsuario { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int CodigoPermissao { get; set; }
        public int Status { get; set; }
    }
}
