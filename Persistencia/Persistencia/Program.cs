using MySql.Data.MySqlClient;
using Persistencia.DAO;
using Persistencia.Modelo;
using Persistencia.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Persistencia
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                Usuario user = new Usuario();
                long id;
                user.CodigoPermissao = 0;
                user.Senha = "rrrrr";
                user.Login = "rffffr";
                user.Nome = "ffffff";
                user.CPF = "eeeeeeeee";
                user.RG = "rrrrrrr";
                user.CodigoPermissao = 1;
                UsuarioDAO u = new UsuarioDAO();
                if ((id = u.Inserir(user)) != -1)
                    Console.WriteLine("Sucesso! {0}",id);
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadKey();
        }
    }
}
