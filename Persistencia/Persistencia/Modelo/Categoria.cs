using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class Categoria
    {
        public Categoria() { }
        public Categoria(int cod_c, string nome, decimal valor, int status)
        {
            CodigoCategoria = cod_c;
            Nome = nome;
            Valor = valor;
            Status = status;
        }
        public int CodigoCategoria { get; set; }
        public String Nome { get; set; }
        public Decimal Valor { get; set; }
        public int Status { get; set; }

    }
}
