using MySql.Data.MySqlClient;
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
                if (new UsuarioService().Inserir("rafael", "44.703.066-8", "446.317.558-57", "rafael", "rafael"))
                    Console.WriteLine("Sucesso!");
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadKey();
        }
    }
}
