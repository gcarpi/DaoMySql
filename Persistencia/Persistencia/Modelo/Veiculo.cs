using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class Veiculo
    {
        public long CodigoVeiculo {get; set;} 
        public string Marca {get; set;} 
        public string Modelo {get; set;} 
        public string AnoFabricacao {get; set;} 
        public int Condicao {get; set;} 
        public bool VidroEletrico {get; set;} 
        public bool TravaEletrica {get; set;} 
        public bool Automatico {get; set;} 
        public int QuantidadePortas {get; set;} 
        public bool DirecaoHidraulica {get; set;} 
        public string Cor {get; set;} 
        public bool ArCondicionado {get; set;}
        public long CodigoCategoria {get; set;}
        public int Status { get; set; }
    }
}
