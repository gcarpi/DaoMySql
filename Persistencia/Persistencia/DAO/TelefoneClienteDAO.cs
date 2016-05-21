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
    public class TelefoneClienteDAO : Interface.IDAO<TelefoneCliente>, IDisposable
    {
        private Interface.IConnection _connection;

        public TelefoneClienteDAO()
        {
            _connection = new Connection();
        }

        public bool Inserir(TelefoneCliente telefone)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO TELEFONE_CLIENTE (TELEFONE,COD_CLIENTE,STATUS) VALUES (@TELEFONE,@COD_CLIENTE,@STATUS);";

                    comando.Parameters.Add("@TELEFONE", MySqlDbType.Text).Value = telefone.Telefone;
                    comando.Parameters.Add("@COD_CLIENTE", MySqlDbType.Int16).Value = telefone.CodigoCliente;
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

        public bool Remover(TelefoneCliente telefone)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE TELEFONECLIENTE SET STATUS = @STATUS WHERE COD_TELEFONE_CLIENTE = @COD_TELEFONE_CLIENTE";

                    comando.Parameters.Add("@COD_TELEFONECLIENTE", MySqlDbType.Int16).Value = telefone.CodigoTelefoneCliente;
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
                    comando.CommandText = "UPDATE SET TELEFONE = @TELEFONE, STATUS = @STATUS WHERE COD_TELEFONE_CLIENTE = @COD_TELEFONE_CLIENTE;";
                    comando.Parameters.Add("@TELEFONE", MySqlDbType.Text).Value = telefone.Telefone;
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

        public List<TelefoneCliente> Listar()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    List<TelefoneCliente> telefones = new List<TelefoneCliente>();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_TELEFONE_CLIENTE, STATUS FROM TELEFONE_CLIENTE  WHERE STATUS <> 9;";
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        TelefoneCliente telefone = new TelefoneCliente();
                        telefone.CodigoTelefoneCliente = Int16.Parse(leitor["COD_TELEFONE_CLIENTE"].ToString());
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

        
        public void Dispose()
        {
            _connection.Fechar();
            GC.SuppressFinalize(this);
        }

    }
}