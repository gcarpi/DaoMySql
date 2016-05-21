using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class VeiculoTemCheckList
    {
        public VeiculoTemCheckList() { }
        public VeiculoTemCheckList(int cod_vck)
        {
            CodigoVeiculoTemCheckList = cod_vck;
        }
        public VeiculoTemCheckList(int cod_vck, string data, int cod_v, int cod_ch, int status)
        {
            CodigoVeiculoTemCheckList = cod_vck;
            DataChecagem = data;
            CodigoVeiculo = cod_v;
            CodigoCheckList = cod_ch;
            Status = status;
        }
        public int CodigoVeiculoTemCheckList { get; set; }
        public string DataChecagem { get; set; }
        public int CodigoVeiculo { get; set; }
        public int CodigoCheckList { get; set; }
        public int Status { get; set; }
    }
}
