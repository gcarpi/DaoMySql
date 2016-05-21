using MySql.Data.MySqlClient;
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
    public class FornecedorDAO : Interface.IDAO<Fornecedor>, IDisposable
    {
        private Interface.IConnection _connection;

        public FornecedorDAO()
        {
            _connection = new Connection();
        }

        public bool Atualizar(Fornecedor fornecedor)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE FORNECEDOR SET COD_FORNECEDOR = @COD_FORNECEDOR, COD_PESSOA_JURIDICA = @COD_PESSOA_JURIDICA, STATUS = @STATUS WHERE COD_FORNECEDOR = @COD_FORNECEDOR";

                    comando.Parameters.Add("@COD_FORNECEDOR", MySqlDbType.Int16).Value = fornecedor.CodigoFornecedor;
                    comando.Parameters.Add("@COD_PESSOA_JURIDICA", MySqlDbType.Int16).Value = fornecedor.CodigoPessoaJuridica;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = fornecedor.Status;

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

        public void Dispose()
        {
            _connection.Fechar();
            GC.SuppressFinalize(this);
        }

        public bool Inserir(Fornecedor fornecedor)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO FORNECEDOR(COD_FORNECEDOR,COD_PESSOA_JURIDICA,STATUS) VALUES (@COD_FORNECEDOR,@COD_PESSOA_JURIDICA,STATUS);";

                    comando.Parameters.Add("@COD_FORNECEDOR", MySqlDbType.Int16).Value = fornecedor.CodigoFornecedor;
                    comando.Parameters.Add("@COD_PESSOA_JURIDICA", MySqlDbType.Int16).Value = fornecedor.CodigoPessoaJuridica;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = fornecedor.Status;

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

        public List<Fornecedor> Listar()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    List<Fornecedor> fornecedores = new List<Fornecedor>();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_FORNECEDOR,COD_PESSOA_JURIDICA,STATUS FROM FORNECEDOR WHERE STATUS <> 9;";
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Fornecedor fornecedor = new Fornecedor();
                        fornecedor.CodigoFornecedor = Int16.Parse(leitor["COD_FORNECEDOR"].ToString());
                        fornecedor.CodigoPessoaJuridica = Int16.Parse(leitor["COD_PESSOA_JURIDICA"].ToString());
                        fornecedor.Status = Int16.Parse(leitor["STATUS"].ToString());

                        fornecedores.Add(fornecedor);
                    }

                    return fornecedores;
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

        public bool Remover(Fornecedor fornecedor)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE FORNECEDOR SET STATUS = @STATUS WHERE COD_FORNECEDOR = @COD_FORNECEDOR";

                    comando.Parameters.Add("@COD_FORNECEDOR", MySqlDbType.Int16).Value = fornecedor.CodigoFornecedor;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = fornecedor.Status;

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
    }
}
