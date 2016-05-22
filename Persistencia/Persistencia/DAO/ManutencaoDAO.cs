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
    public class ManutencaoDAO: IDAO<Manutencao>, IDisposable
    {
        private Connection _connection;

        public ManutencaoDAO()
        {
            _connection = new Connection();
        }

        public bool Inserir(Manutencao manutencao)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO MANUTENCAO(TIPO_MANUTENCAO,OBSERVACAO,STATUS) VALUES (@TIPO_MANUTENCAO,@OBSERVACAO,@STATUS);";

                    comando.Parameters.Add("@TIPO_MANUTENCAO", MySqlDbType.Int16).Value = manutencao.TipoManutencao;
                    comando.Parameters.Add("@OBSERVACAO", MySqlDbType.Text).Value = manutencao.Observacao;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = manutencao.Status;

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

        public bool Remover(Manutencao manutencao)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE MANUTENCAO SET STATUS = @STATUS WHERE COD_MANUTENCAO = @COD_MANUTENCAO";

                    comando.Parameters.Add("@COD_MANUTENCAO", MySqlDbType.Int16).Value = manutencao.CodigoManutencao;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = manutencao.Status;

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

        public bool Atualizar(Manutencao manutencao)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE MANUTENCAO SET TIPO_MANUTENCAO = @TIPO_MANUTENCAO, OBSERVACAO = @OBSERVACAO WHERE COD_MANUTENCAO = @COD_MANUTENCAO;";

                    comando.Parameters.Add("@TIPO_MANUTENCAO", MySqlDbType.Int16).Value = manutencao.TipoManutencao;
                    comando.Parameters.Add("@OBSERVACAO", MySqlDbType.Text).Value = manutencao.Observacao;

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

        public List<Manutencao> Listar()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    List<Manutencao> manutencaos = new List<Manutencao>();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_MANUTENCAO,TIPO_MANUTENCAO,OBSERVACAO,STATUS FROM MANUTENCAO WHERE STATUS <> 9;";
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Manutencao manutencao = new Manutencao();
                        manutencao.CodigoManutencao = Int16.Parse(leitor["COD_MANUTENCAO"].ToString());
                        manutencao.TipoManutencao = Int16.Parse(leitor["TIPO_MANUTENCAO"].ToString());
                        manutencao.Observacao = leitor["OBSERVACAO"].ToString();
                        manutencao.Status = Int16.Parse(leitor["STATUS"].ToString());

                        manutencaos.Add(manutencao);
                    }

                    return manutencaos;
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