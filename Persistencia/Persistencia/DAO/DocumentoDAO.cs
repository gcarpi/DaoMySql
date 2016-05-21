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
    public class DocumentoDAO : IDAO<Documento>, IDisposable
    {
        private Interface.IConnection _connection;

        public DocumentoDAO()
        {
            _connection = new Connection();
        }

        public bool Atualizar(Documento documento)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE DOCUMENTO SET RENAVAM = @RENAVAM, CHASSI = @CHASSI, DATA_LICENCIAMENTO = @DATA_LICENCIAMENTO, COD_VEICULO = @COD_VEICULO, STATUS = @STATUS WHERE COD_DOCUMENTO = @COD_DOCUMENTO";

                    comando.Parameters.Add("@RENAVAM", MySqlDbType.Text).Value = documento.Renavam;
                    comando.Parameters.Add("@CHASSI", MySqlDbType.Text).Value = documento.Chassi;
                    comando.Parameters.Add("@DATA_LICENCIAMENTO", MySqlDbType.Text).Value = documento.DataLicenciamento;
                    comando.Parameters.Add("@COD_VEICULO", MySqlDbType.Int16).Value = documento.CodigoVeiculo;
                    comando.Parameters.Add("@COD_VEICULO", MySqlDbType.Int16).Value = documento.CodigoVeiculo;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = documento.Status;

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

        public bool Inserir(Documento documento)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO DOCUMENTO(RENAVAM,CHASSI,DATA_LICENCIAMENTO,COD_VEICULO, STATUS) VALUES (@RENAVAM,@CHASSI,@DATA_LICENCIAMENTO,@COD_VEICULO, @STATUS);";

                    comando.Parameters.Add("@DATA_RESERVA", MySqlDbType.Text).Value = documento.Renavam;
                    comando.Parameters.Add("@CHASSI", MySqlDbType.Text).Value = documento.Chassi;
                    comando.Parameters.Add("@DATA_LICENCIAMENTO", MySqlDbType.Text).Value = documento.DataLicenciamento;
                    comando.Parameters.Add("@COD_VEICULO", MySqlDbType.Text).Value = documento.CodigoVeiculo;
                    comando.Parameters.Add("@COD_VEICULO", MySqlDbType.Int16).Value = documento.Status;

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

        public List<Documento> Listar()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    List<Documento> documentos = new List<Documento>();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT RENAVAM,CHASSI,DATA_LICENCIAMENTO,COD_VEICULO, STATUS FROM DOCUMENTO WHERE STATUS <> 9;";
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Documento documento = new Documento();
                        documento.Renavam = leitor["RENAVAM"].ToString();
                        documento.Chassi = leitor["CHASSI"].ToString();
                        documento.DataLicenciamento = leitor["DATA_LICENCIAMENTO"].ToString();
                        documento.CodigoVeiculo = Int16.Parse(leitor["COD_VEICULO"].ToString());
                        documento.Status = Int16.Parse(leitor["STATUS"].ToString());

                        documentos.Add(documento);
                    }   

                    return documentos;
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

        public bool Remover(Documento documento)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE DOCUMENTO SET STATUS = @STATUS WHERE COD_DOCUMENTO = @COD_DOCUMENTO";

                    comando.Parameters.Add("@COD_DOCUMENTO", MySqlDbType.Int16).Value = documento.CodigoDocumento;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = documento.Status;

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
                //teste
                _connection.Fechar();
            }
        }
    }
}
    