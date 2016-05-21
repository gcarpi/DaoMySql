using MySql.Data.MySqlClient;
using Persistencia.DAO;
using Persistencia.Modelo;
using Persistencia.Util;
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
            UsuarioDAO connect = new UsuarioDAO();
            Usuario user = new Usuario();
            user.Nome = "Raffa";
            user.CPF = "fffff";
            user.Login = "lllll";
            user.Senha = "hhhhh";
            user.Status = 1;
            try
            {
                connect.Inserir(user);
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadKey();
        }
    }
}
