using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class Documento
    {
        public long CodigoDocumento{ get; set; }
        public string Renavam { get; set; }
        public string Chassi { get; set; }
        public string Placa { get; set; }
        public string DataLicenciamento { get; set; }
        public long CodigoVeiculo { get; set; }
        public int Status { get; set; }
    }
}
