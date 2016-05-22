using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Persistencia.Util
{
    class Util
    {

        public static Config GetConfigs()
        {
            XElement xml = XElement.Load("config.xml").Element("acesso");
            Config conf = new Config()
            {
                Nome_BD = xml.Attribute("nome").Value,
                IP = xml.Attribute("ip").Value,
                Login = xml.Attribute("login").Value,
                Senha = xml.Attribute("senha").Value,
            };

            return conf;
        }
    }
}
