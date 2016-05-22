using MySql.Data.MySqlClient;
using Persistencia.Interface;
using Persistencia.Modelo;
using Persistencia.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAO
{
    public class EnderecoDAO : IDAO<Endereco>, IDisposable
    {
        private Connection _connection;

        public EnderecoDAO()
        {
            _connection = new Connection();
        }

        public long Inserir(Endereco endereco)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO ENDERECO (COD_ENDERECO,CEP,BAIRRO,NUMERO,CIDADE,ESTADO,STATUS,COD_FORNECEDOR,COD_CLIENTE) VALUES (@COD_ENDERECO,@CEP,@BAIRRO,@NUMERO,@CIDADE,@ESTADO,@STATUS,@COD_FORNECEDOR,@COD_CLIENTE);";

                    comando.Parameters.Add("@COD_ENDERECO", MySqlDbType.Int16).Value = endereco.CodigoEndereco;
                    comando.Parameters.Add("@CEP", MySqlDbType.Text).Value = endereco.CEP;
                    comando.Parameters.Add("@BAIRRO", MySqlDbType.Text).Value = endereco.Bairro;
                    comando.Parameters.Add("@NUMERO", MySqlDbType.Int16).Value = endereco.Numero;
                    comando.Parameters.Add("@CIDADE", MySqlDbType.Text).Value = endereco.Cidade;
                    comando.Parameters.Add("@ESTADO", MySqlDbType.Text).Value = endereco.Estado;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = endereco.Status;
                    comando.Parameters.Add("@COD_FORNECEDOR", MySqlDbType.Int16).Value = endereco.CodigoEndereco;
                    comando.Parameters.Add("@COD_CLIENTE", MySqlDbType.Int16).Value = endereco.CodigoCliente;

                    if (comando.ExecuteNonQuery() > 0)
                        return comando.LastInsertedId;
                    return -1;
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                _connection.Fechar();
            }
        }

        public bool Remover(Endereco endereco)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE ENDERECO SET STATUS = @STATUS WHERE COD_ENDERECO = @COD_ENDERECO";

                    comando.Parameters.Add("@COD_ENDERECO", MySqlDbType.Int16).Value = endereco.CodigoEndereco;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = endereco.Status;

                    if (comando.ExecuteNonQuery() > 0)
                        return true;
                    return false;
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                _connection.Fechar();
            }
        }

        public bool Atualizar(Endereco endereco)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE ENDERECO SET ENDERECO COD_ENDERECO = @COD_ENDERECO, CEP = @CEP, BAIRRO = @BAIRRO, NUMERO = @NUMERO, CIDADE = @CIDADE, ESTADO = @ESTADO WHERE COD_ENDERECO = @COD_ENDERECO;";

                    comando.Parameters.Add("@COD_ENDERECO", MySqlDbType.Int16).Value = endereco.CodigoEndereco;
                    comando.Parameters.Add("@CEP", MySqlDbType.Text).Value = endereco.CEP;
                    comando.Parameters.Add("@BAIRRO", MySqlDbType.Text).Value = endereco.Bairro;
                    comando.Parameters.Add("@NUMERO", MySqlDbType.Int16).Value = endereco.Numero;
                    comando.Parameters.Add("@CIDADE", MySqlDbType.Text).Value = endereco.Cidade;
                    comando.Parameters.Add("@ESTADO", MySqlDbType.Text).Value = endereco.Estado;

                    if (comando.ExecuteNonQuery() > 0)
                        return true;
                    return false;
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                _connection.Fechar();
            }
        }

        public List<Endereco> Listar()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    List<Endereco> enderecos = new List<Endereco>();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_ENDERECO,CEP,BAIRRO,NUMERO,CIDADE,ESTADO,STATUS,COD_FORNECEDOR,COD_CLIENTE FROM ENDERECO WHERE STATUS <> 9;";
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Endereco endereco = new Endereco();
                        endereco.CodigoEndereco = Int16.Parse(leitor["COD_ENDERECO"].ToString());
                        endereco.CEP = leitor["CEP"].ToString();
                        endereco.Bairro = leitor["BAIRRO"].ToString();
                        endereco.Numero = Int16.Parse(leitor["NUMERO"].ToString());
                        endereco.Cidade = leitor["CIDADE"].ToString();
                        endereco.Estado = leitor["ESTADO"].ToString();
                        endereco.Status = Int16.Parse(leitor["STATUS"].ToString());
                        endereco.CodigoFornecedor = Int16.Parse(leitor["COD_FORNECEDOR"].ToString());
                        endereco.CodigoCliente = Int16.Parse(leitor["COD_CLIENTE"].ToString());

                        enderecos.Add(endereco);
                    }

                    return enderecos;
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                _connection.Fechar();
            }
        }

        public Endereco Buscar(int cod)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    Endereco endereco = new Endereco();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_ENDERECO,CEP,BAIRRO,NUMERO,CIDADE,ESTADO,STATUS,COD_FORNECEDOR,COD_CLIENTE FROM ENDERECO WHERE STATUS <> 9 AND COD_ENDERECO = @COD_ENDERECO;";

                    comando.Parameters.Add("COD_ENDERECO", MySqlDbType.Int16).Value = cod;
                    MySqlDataReader leitor = comando.ExecuteReader();

                    if (leitor.Read())
                    {
                        endereco.CodigoEndereco = Int16.Parse(leitor["COD_ENDERECO"].ToString());
                        endereco.CEP = leitor["CEP"].ToString();
                        endereco.Bairro = leitor["BAIRRO"].ToString();
                        endereco.Numero = Int16.Parse(leitor["NUMERO"].ToString());
                        endereco.Cidade = leitor["CIDADE"].ToString();
                        endereco.Estado = leitor["ESTADO"].ToString();
                        endereco.Status = Int16.Parse(leitor["STATUS"].ToString());
                        endereco.CodigoFornecedor = Int16.Parse(leitor["COD_FORNECEDOR"].ToString());
                        endereco.CodigoCliente = Int16.Parse(leitor["COD_CLIENTE"].ToString());
                    }

                    return endereco;
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                _connection.Fechar();
            }
        }

        public void Dispose()
        {
            _connection.Fechar();
            GC.SuppressFinalize(this);
        }
    }
}