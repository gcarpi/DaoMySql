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
    public class TelefoneClienteDAO : IDAO<TelefoneCliente>, IDisposable
    {
        private Connection _connection;

        public TelefoneClienteDAO()
        {
            _connection = new Connection();
        }

        public long Inserir(TelefoneCliente telefone)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO TELEFONE_CLIENTE (TELEFONE,COD_CLIENTE) VALUES (@TELEFONE,@COD_CLIENTE);";

                    comando.Parameters.Add("@TELEFONE", MySqlDbType.Text).Value = telefone.Telefone;
                    comando.Parameters.Add("@COD_CLIENTE", MySqlDbType.Int16).Value = telefone.CodigoCliente;

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

        public bool Remover(TelefoneCliente telefone)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE TELEFONE_CLIENTE SET STATUS = @STATUS WHERE COD_TELEFONE_CLIENTE = @COD_TELEFONE_CLIENTE";

                    comando.Parameters.Add("@COD_TELEFONE_CLIENTE", MySqlDbType.Int16).Value = telefone.CodigoTelefoneCliente;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = telefone.Status;
                    

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


        public bool Atualizar(TelefoneCliente telefone)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE SET TELEFONE = @TELEFONE WHERE COD_TELEFONE_CLIENTE = @COD_TELEFONE_CLIENTE;";

                    comando.Parameters.Add("@COD_TELEFONE_CLIENTE", MySqlDbType.Int16).Value = telefone.CodigoTelefoneCliente;
                    comando.Parameters.Add("@TELEFONE", MySqlDbType.Text).Value = telefone.Telefone;

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

        public List<TelefoneCliente> Listar()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    List<TelefoneCliente> telefones = new List<TelefoneCliente>();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_TELEFONE_CLIENTE,TELEFONE,STATUS FROM TELEFONE_CLIENTE  WHERE STATUS <> 9;";
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        TelefoneCliente telefone = new TelefoneCliente();
                        telefone.CodigoTelefoneCliente = Int16.Parse(leitor["COD_TELEFONE_CLIENTE"].ToString());
                        telefone.Telefone = leitor["TELEFONE"].ToString();
                        telefone.Status = Int16.Parse(leitor["STATUS"].ToString());

                        telefones.Add(telefone);
                    }

                    return telefones;
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

        public TelefoneCliente Buscar(long cod)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    TelefoneCliente telefone = new TelefoneCliente();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_TELEFONE_CLIENTE,TELEFONE,STATUS FROM TELEFONE_CLIENTE  WHERE STATUS <> 9 AND COD_TELEFONE_CLIENTE = @COD_TELEFONE_CLIENTE;";

                    comando.Parameters.Add("@COD_TELEFONE_CLIENTE",MySqlDbType.Int16).Value = cod;
                    MySqlDataReader leitor = comando.ExecuteReader();

                    if (leitor.Read())
                    {
                        telefone.CodigoTelefoneCliente = Int16.Parse(leitor["COD_TELEFONE_CLIENTE"].ToString());
                        telefone.Telefone = leitor["TELEFONE"].ToString();
                        telefone.Status = Int16.Parse(leitor["STATUS"].ToString());
                    }

                    return telefone;
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

        public long Contagem()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COUNT(COD_TELEFONE_CLIENTE) FROM TELEFONE_CLIENTE;";

                    return (long)comando.ExecuteScalar();
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