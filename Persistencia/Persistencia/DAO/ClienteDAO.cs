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
    public class ClienteDAO : IDAO<Cliente>, IDisposable
    {
        private Connection _connection;

        public ClienteDAO()
        {
            _connection = new Connection();
        }

        public bool Inserir(Cliente cliente)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO CLIENTE(EMAIL,STATUS) VALUES (@EMAIL,@STATUS);";

                    comando.Parameters.Add("@EMAIL", MySqlDbType.Text).Value = cliente.Email;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = cliente.Status;

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

        public bool Remover(Cliente cliente)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE CLIENTE SET STATUS = @STATUS WHERE COD_CLIENTE = @COD_CLIENTE";

                    comando.Parameters.Add("@COD_CLIENTE", MySqlDbType.Int16).Value = cliente.CodigoCliente;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = cliente.Status;

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

        public bool Atualizar(Cliente cliente)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE CLIENTE SET EMAIL = @EMAIL WHERE COD_CLIENTE = @COD_CLIENTE;";

                    comando.Parameters.Add("@EMAIL", MySqlDbType.Text).Value = cliente.Email;

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

        public List<Cliente> Listar()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    List<Cliente> clientes = new List<Cliente>();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_CLIENTE,EMAIL,STATUS FROM CLIENTE WHERE STATUS <> 9;";
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente.CodigoCliente = Int16.Parse(leitor["COD_CLIENTE"].ToString());
                        cliente.Email = leitor["EMAIL"].ToString();
                        cliente.Status = Int16.Parse(leitor["STATUS"].ToString());

                        clientes.Add(cliente);
                    }

                    return clientes;
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

        public Cliente Buscar(int cod)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    Cliente cliente = new Cliente();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_CLIENTE,EMAIL,STATUS FROM CLIENTE WHERE STATUS <> 9 AND COD_CLIENTE = @COD_CLIENTE;";
                    comando.Parameters.Add("@COD_CLIENTE", MySqlDbType.Int16).Value = cod;
                    MySqlDataReader leitor = comando.ExecuteReader();

                    if (leitor.Read())
                    {
                        cliente.CodigoCliente = Int16.Parse(leitor["COD_CLIENTE"].ToString());
                        cliente.Email = leitor["EMAIL"].ToString();
                        cliente.Status = Int16.Parse(leitor["STATUS"].ToString());
                    }

                    return cliente;
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