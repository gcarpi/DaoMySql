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
        public Usuario(int cod_u, int status)
        {
            new Usuario(cod_u, null, null, null, null, null, 0, status);
        }
        public Usuario(string nome = "", string rg = "", string cpf = "", string login = "", string senha = "")
        {
            new Usuario(0,nome,rg,cpf,login,senha);
        }
        public Usuario(int cod_u = 0, string nome = "", string rg = "", string cpf = "", string login = "", string senha = "", int cod_p = 0, int status = 0)
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
