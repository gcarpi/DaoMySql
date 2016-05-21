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
    public class TelefoneFornecedorDAO : Interface.IDAO<TelefoneFornecedor>, IDisposable
    {
        private Interface.IConnection _connection;

        public TelefoneFornecedorDAO()
        {
            _connection = new Connection();
        }

        public bool Inserir(TelefoneFornecedor telefone)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO TELEFONE_FORNECEDOR (TELEFONE,COD_FORNECEDOR,STATUS) VALUES (@TELEFONE,@COD_FORNECEDOR,@STATUS);";

                    comando.Parameters.Add("@TELEFONE", MySqlDbType.Text).Value = telefone.Telefone;
                    comando.Parameters.Add("@COD_FORNECEDOR", MySqlDbType.Int16).Value = telefone.CodigoFornecedor;
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

        public bool Remover(TelefoneFornecedor telefone)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE TELEFONE_FORNECEDOR  SET STATUS = @STATUS WHERE COD_TELEFONE_FORNECEDOR = @COD_TELEFONE_FORNECEDOR";

                    comando.Parameters.Add("@COD_TELEFONE_FORNECEDOR", MySqlDbType.Int16).Value = telefone.CodigoTelefoneFornecedor;
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


        public bool Atualizar(TelefoneFornecedor telefone)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE SET TELEFONE = @TELEFONE, STATUS = @STATUS WHERE COD_TELFORNECEDOR = @COD_TELFORNECEDOR;";
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

        public List<TelefoneFornecedor> Listar()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    List<TelefoneFornecedor> telefones = new List<TelefoneFornecedor>();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_TELFORNECEDOR, STATUS FROM TELEFONEFORNECEDOR WHERE STATUS <> 9;";
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        TelefoneFornecedor telefone = new TelefoneFornecedor();
                        telefone.CodigoTelefoneFornecedor = Int16.Parse(leitor["COD_TELFORNECEDOR"].ToString());
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
