using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    class VeiculoTemManutencao
    {
        public VeiculoTemManutencao() { }
        public VeiculoTemManutencao(int cod_vm)
        {
            CodigoVeiculoTemManutencao= cod_vm;
        }
        public VeiculoTemManutencao(int cod_vm, string data_p, string data_e, string data_s, int cod_v, int cod_m)
        {
            CodigoVeiculoTemManutencao = cod_vm;
            DataPrevista = data_p;
            DataEntrega = data_e;
            DataSaida = data_s;
            CodigoVeiculo = cod_v;
            CodigoManutencao = cod_m;
        }
        public int CodigoVeiculoTemManutencao { get; set; }
        public string DataPrevista { get; set; }
        public string DataEntrega { get; set; }
        public string DataSaida { get; set; }
        public int CodigoVeiculo { get; set; }
        public int CodigoManutencao { get; set; }
    }
}
