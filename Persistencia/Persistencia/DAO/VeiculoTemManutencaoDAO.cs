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
    public class VeiculoTemManutencaoDAO : IDAO<VeiculoTemManutencao>, IDisposable
    {
        private Connection _connection;

        public VeiculoTemManutencaoDAO()
        {
            _connection = new Connection();
        }

        public long Inserir(VeiculoTemManutencao veiculomanutencao)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO VEICULO_TEM_MANUTENCAO(DATA_PREVISTA,DATA_ENTREGA,DATA_SAIDA,COD_VEICULO,COD_MANUTENCAO) VALUES (@DATA_PREVISTA,@DATA_ENTREGA,@DATA_SAIDA,@COD_VEICULO,@COD_MANUTENCAO);";

                    comando.Parameters.Add("@DATA_PREVISTA", MySqlDbType.Text).Value = veiculomanutencao.DataPrevista;
                    comando.Parameters.Add("@DATA_ENTREGA", MySqlDbType.Text).Value = veiculomanutencao.DataEntrega;
                    comando.Parameters.Add("@DATA_SAIDA", MySqlDbType.Text).Value = veiculomanutencao.DataSaida;
                    comando.Parameters.Add("@COD_VEICULO", MySqlDbType.Int16).Value = veiculomanutencao.CodigoVeiculo;
                    comando.Parameters.Add("@COD_MANUTENCAO", MySqlDbType.Int16).Value = veiculomanutencao.CodigoManutencao;

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

        public bool Remover(VeiculoTemManutencao veiculomanutencao)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE VEICULO_TEM_MANUTENCAO SET STATUS = @STATUS WHERE COD_VEICULO_TEM_MANUTENCAO = @COD_VEICULO_TEM_MANUTENCAO";

                    comando.Parameters.Add("@COD_VEICULO_TEM_MANUTENCAO", MySqlDbType.Int16).Value = veiculomanutencao.CodigoVeiculoTemManutencao;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = veiculomanutencao.Status;
                    

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


        public bool Atualizar(VeiculoTemManutencao veiculomanutencao)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE VEICULO_TEM_MANUTENCAO SET DATA_PREVISTA = @DATA_PREVISTA, DATA_ENTREGA = @DATA_ENTREGA, DATA_SAIDA = @DATA_SAIDA WHERE COD_VEICULO_TEM_MANUTENCAO = @COD_VEICULO_TEM_MANUTENCAO;";

                    comando.Parameters.Add("@COD_VEICULO_TEM_MANUTENCAO", MySqlDbType.Int16).Value = veiculomanutencao.CodigoVeiculoTemManutencao;
                    comando.Parameters.Add("@DATA_PREVISTA", MySqlDbType.Text).Value = veiculomanutencao.DataPrevista;
                    comando.Parameters.Add("@DATA_ENTREGA", MySqlDbType.Text).Value = veiculomanutencao.DataEntrega;
                    comando.Parameters.Add("@DATA_SAIDA", MySqlDbType.Text).Value = veiculomanutencao.DataSaida;

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

        public List<VeiculoTemManutencao> Listar()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    List<VeiculoTemManutencao> veiculomanutencaos = new List<VeiculoTemManutencao>();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_VEICULO_TEM_MANUTENCAO,DATA_PREVISTA,DATA_ENTREGA,DATA_SAIDA,COD_VEICULO,COD_MANUTENCAO,STATUS FROM VEICULO_TEM_MANUTENCAO WHERE STATUS <> 9;";
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        VeiculoTemManutencao veiculomanutencao = new VeiculoTemManutencao();
                        veiculomanutencao.CodigoVeiculoTemManutencao = Int16.Parse(leitor["COD_VEICULO_TEM_MANUTENCAO"].ToString());
                        veiculomanutencao.DataPrevista = leitor["DATA_PREVISTA"].ToString();
                        veiculomanutencao.DataEntrega = leitor["DATA_ENTREGA"].ToString();
                        veiculomanutencao.DataSaida = leitor["DATA_SAIDA"].ToString();
                        veiculomanutencao.CodigoVeiculo = Int16.Parse(leitor["COD_VEICULO"].ToString());
                        veiculomanutencao.CodigoManutencao = Int16.Parse(leitor["COD_MANUTENCAO"].ToString());
                        veiculomanutencao.Status = Int16.Parse(leitor["STATUS"].ToString());

                        veiculomanutencaos.Add(veiculomanutencao);
                    }

                    return veiculomanutencaos;
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

        public VeiculoTemManutencao Buscar(long cod)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    VeiculoTemManutencao veiculomanutencao = new VeiculoTemManutencao();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_VEICULO_TEM_MANUTENCAO,DATA_PREVISTA,DATA_ENTREGA,DATA_SAIDA,COD_VEICULO,COD_MANUTENCAO,STATUS FROM VEICULO_TEM_MANUTENCAO WHERE STATUS <> 9 AND COD_VEICULO_TEM_MANUTENCAO = @COD_VEICULO_TEM_MANUTENCAO;";

                    comando.Parameters.Add("@COD_VEICULO_TEM_MANUTENCAO",MySqlDbType.Int16).Value = cod;
                    MySqlDataReader leitor = comando.ExecuteReader();

                    if (leitor.Read())
                    {
                        veiculomanutencao.CodigoVeiculoTemManutencao = Int16.Parse(leitor["COD_VEICULO_TEM_MANUTENCAO"].ToString());
                        veiculomanutencao.DataPrevista = leitor["DATA_PREVISTA"].ToString();
                        veiculomanutencao.DataEntrega = leitor["DATA_ENTREGA"].ToString();
                        veiculomanutencao.DataSaida = leitor["DATA_SAIDA"].ToString();
                        veiculomanutencao.CodigoVeiculo = Int16.Parse(leitor["COD_VEICULO"].ToString());
                        veiculomanutencao.CodigoManutencao = Int16.Parse(leitor["COD_MANUTENCAO"].ToString());
                        veiculomanutencao.Status = Int16.Parse(leitor["STATUS"].ToString());
                    }

                    return veiculomanutencao;
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
                    comando.CommandText = "SELECT COUNT(COD_VEICULO_TEM_MANUTENCAO) FROM VEICULO_TEM_MANUTENCAO;";

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