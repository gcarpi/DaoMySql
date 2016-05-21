using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Util
{
    class Config
    {
        private String sqlconnect;
        public string Nome_BD{ get; set;}
        public string IP { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public string GetStrConnect()
        {
            sqlconnect = String.Format("server={0};database={1};userid={2};password={3};",IP,Nome_BD,Login,Senha);
            return sqlconnect;
        }
    }
}
