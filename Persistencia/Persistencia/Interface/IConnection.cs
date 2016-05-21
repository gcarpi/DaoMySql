using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Interface
{
    interface IConnection: IDisposable
    {
        MySqlConnection Abrir();
        MySqlConnection Buscar();
        ConnectionState Status();
        void Fechar();
    }
}
