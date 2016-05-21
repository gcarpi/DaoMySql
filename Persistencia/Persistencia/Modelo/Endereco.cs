using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Modelo
{
    public class Endereco
    {
        public Endereco() { }

        public Endereco(int cod_e)
        {
            CodigoEndereco = cod_e;
        }

        public Endereco(int cod_e, string cep, string bairro, int numero, string cidade, string estado, int cod_f, int cod_c)
        {
            CodigoEndereco= cod_e;
            CEP = cep;
            Bairro = bairro;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            CodigoFornecedor = cod_f;
            CodigoCliente = cod_c;
        }

        public int CodigoEndereco { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int CodigoCliente { get; set; }
        public int CodigoFornecedor { get; set; }
    }
}
