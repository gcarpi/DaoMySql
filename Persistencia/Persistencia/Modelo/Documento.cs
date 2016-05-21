using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class Documento
    {
        public Documento() { }
        public Documento(int cod_d)
        {
            CodigoDocumento = cod_d;
        }
        public Documento(int cod_d, string renavam, string chassi, string placa, string data, int status, int cod_v)
        {
            CodigoDocumento = cod_d;
            Renavam = renavam;
            Chassi = chassi;
            Placa = placa;
            DataLicenciamento = data;
            Status = status;
            CodigoVeiculo = cod_v;
        }

        public int CodigoDocumento{ get; set; }
        public string Renavam { get; set; }
        public string Chassi { get; set; }
        public string Placa { get; set; }
        public string DataLicenciamento { get; set; }
        public int CodigoVeiculo { get; set; }
        public int Status { get; set; }
    }
}
