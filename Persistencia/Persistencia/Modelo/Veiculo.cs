using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class Veiculo
    {
        public Veiculo() { }
        public Veiculo(int cod_v, string marca, string modelo, string ano_f, string condicao, bool v_e, bool t_e, bool aut, int q_p, bool d_h, string cor, bool ar, int cod_c, int status)
        {
            CodigoVeiculo = cod_v;
            Marca = marca;
            Modelo = modelo;
            AnoFabricação = ano_f;
            Condicao = condicao;
            VidroEletrico = v_e;
            TravaEletrica = t_e;
            Automatico = aut;
            QuantidadePortas = q_p;
            DirecaoHidraulica = d_h;
            Cor = cor;
            ArCondicionado = ar;
            CodigoCategoria = cod_c;
            Status = status;
        }
        public int CodigoVeiculo {get; set;} 
        public string Marca {get; set;} 
        public string Modelo {get; set;} 
        public string AnoFabricação {get; set;} 
        public string Condicao {get; set;} 
        public bool VidroEletrico {get; set;} 
        public bool TravaEletrica {get; set;} 
        public bool Automatico {get; set;} 
        public int QuantidadePortas {get; set;} 
        public bool DirecaoHidraulica {get; set;} 
        public string Cor {get; set;} 
        public bool ArCondicionado {get; set;}
        public int CodigoCategoria {get; set;}
        public int Status { get; set; }
    }
}
