using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class VeiculoTemManutencao
    {
        public long CodigoVeiculoTemManutencao { get; set; }
        public string DataPrevista { get; set; }
        public string DataEntrega { get; set; }
        public string DataSaida { get; set; }
        public long CodigoVeiculo { get; set; }
        public long CodigoManutencao { get; set; }
        public int Status { get; set; }
    }
}
