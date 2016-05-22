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
    public class VeiculoTemCheckListDAO: IDAO<VeiculoTemCheckList>, IDisposable
    {
        private Connection _connection;

        public VeiculoTemCheckListDAO()
        {
            _connection = new Connection();
        }

        public bool Inserir(VeiculoTemCheckList veiculochecklist)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO VEICULO_TEM_MANUTENCAO(COD_VEICULO,COD_CHECKLIST, DATA_CHECAGEM,STATUS) VALUES (@COD_VEICULO,@COD_CHECKLIST,@DATA_CHECAGEM,@STATUS);";
                    comando.Parameters.Add("@COD_VEICULO", MySqlDbType.Int16).Value = veiculochecklist.CodigoVeiculo;
                    comando.Parameters.Add("@COD_CHECKLIST", MySqlDbType.Int16).Value = veiculochecklist.CodigoCheckList;
                    comando.Parameters.Add("@DATA_CHECAGEM", MySqlDbType.Text).Value = veiculochecklist.DataChecagem;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = veiculochecklist.Status;

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

        public bool Remover(VeiculoTemCheckList veiculochecklist)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE VEICULO_TEM_CHECKLIST SET STATUS = @STATUS WHERE COD_VEICULO_TEM_CHECKLIST = @COD_VEICULO_TEM_CHECKLIST";

                    comando.Parameters.Add("@COD_VEICULO_TEM_CHECKLIST", MySqlDbType.Int16).Value = veiculochecklist.CodigoVeiculoTemCheckList;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = veiculochecklist.Status;


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


        public bool Atualizar(VeiculoTemCheckList veiculochecklist)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE SET COD_VEICULO = @COD_VEICULO, COD_CHECKLIST = @COD_CHECKLIST, DATA_CHECAGEM = @DATA_CHECAGEM, STATUS = @STATUS WHERE COD_VEICULO_TEM_MANUTENCAO = @COD_VEICULO_TEM_MANUTENCAO;";
                    comando.Parameters.Add("@COD_VEICULO ", MySqlDbType.Int16).Value = veiculochecklist.CodigoVeiculo;
                    comando.Parameters.Add("@COD_CHECKLIST", MySqlDbType.Text).Value = veiculochecklist.CodigoCheckList;
                    comando.Parameters.Add("@DATA_CHECAGEM", MySqlDbType.Text).Value = veiculochecklist.DataChecagem;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = veiculochecklist.Status;

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

        public List<VeiculoTemCheckList> Listar()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    List<VeiculoTemCheckList> veiculochecklists = new List<VeiculoTemCheckList>();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_VEICULO_TEM_CHECKLIST,COD_VEICULO,COD_CHECKLIST,DATA_CHECAGEM,STATUS FROM VEICULO_TEM_CHECKLIST WHERE STATUS <> 9;";
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        VeiculoTemCheckList veiculochecklist = new VeiculoTemCheckList();
                        veiculochecklist.CodigoVeiculoTemCheckList = Int16.Parse(leitor["COD_VEICULO_TEM_CHECKLIST"].ToString());
                        veiculochecklist.CodigoVeiculo= Int16.Parse(leitor["COD_VEICULO"].ToString());
                        veiculochecklist.CodigoCheckList = Int16.Parse(leitor["COD_CHECKLIST"].ToString());
                        veiculochecklist.DataChecagem= leitor["DATA_CHECAGEM"].ToString();
                        veiculochecklist.Status = Int16.Parse(leitor["STATUS"].ToString());

                        veiculochecklists.Add(veiculochecklist);
                    }

                    return veiculochecklists;
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