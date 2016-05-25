﻿using MySql.Data.MySqlClient;
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
    public class VeiculoTemFornecedorDAO : IDAO<VeiculoTemFornecedor>, IDisposable
    {
        private Connection _connection;

        public VeiculoTemFornecedorDAO()
        {
            _connection = new Connection();
        }

        public long Inserir(VeiculoTemFornecedor veiculofornecedor)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO VEICULO_TEM_FORNECEDOR (COD_VEICULO,COD_FORNECEDOR) VALUES (@COD_VEICULO,@COD_FORNECEDOR);";

                    comando.Parameters.Add("@COD_VEICULO", MySqlDbType.Int16).Value = veiculofornecedor.CodigoVeiculo;
                    comando.Parameters.Add("@COD_FORNECEDOR", MySqlDbType.Int16).Value = veiculofornecedor.CodigoFornecedor;

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

        public bool Remover(VeiculoTemFornecedor veiculofornecedor)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE VEICULO_TEM_FORNECEDOR SET STATUS = @STATUS WHERE COD_VEICULO_TEM_FORNECEDOR = @COD_VEICULO_TEM_FORNECEDOR";

                    comando.Parameters.Add("@COD_VEICULO_TEM_FORNECEDOR", MySqlDbType.Int16).Value = veiculofornecedor.CodigoVeiculoTemFornecedor;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = veiculofornecedor.Status;
                    

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


        public bool Atualizar(VeiculoTemFornecedor veiculofornecedor)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE VEICULO_TEM_FORNECEDOR SET COD_VEICULO = @COD_VEICULO, COD_FORNECEDOR = @COD_FORNECEDOR WHERE COD_VEICULO_TEM_FORNECEDOR = @COD_VEICULO_TEM_FORNECEDOR;";

                    comando.Parameters.Add("@COD_VEICULO_TEM_FORNECEDOR", MySqlDbType.Int16).Value = veiculofornecedor.CodigoVeiculoTemFornecedor;
                    comando.Parameters.Add("@COD_VEICULO", MySqlDbType.Int16).Value = veiculofornecedor.CodigoVeiculo;
                    comando.Parameters.Add("@COD_FORNECEDOR", MySqlDbType.Int16).Value = veiculofornecedor.CodigoFornecedor;

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

        public List<VeiculoTemFornecedor> Listar()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    List<VeiculoTemFornecedor> veiculofornecedors = new List<VeiculoTemFornecedor>();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_VEICULO_TEM_FORNECEDOR,COD_VEICULO,COD_FORNECEDOR,STATUS FROM VEICULO_TEM_FORNECEDOR WHERE STATUS <> 9;";
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        VeiculoTemFornecedor veiculofornecedor = new VeiculoTemFornecedor();
                        veiculofornecedor.CodigoVeiculoTemFornecedor = Int16.Parse(leitor["COD_VEICULO_TEM_FORNECEDOR"].ToString());
                        veiculofornecedor.CodigoVeiculo = Int16.Parse(leitor["COD_VEICULO"].ToString());
                        veiculofornecedor.CodigoVeiculo = Int16.Parse(leitor["COD_FORNECEDOR"].ToString());
                        veiculofornecedor.Status = Int16.Parse(leitor["STATUS"].ToString());

                        veiculofornecedors.Add(veiculofornecedor);
                    }

                    return veiculofornecedors;
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

        public VeiculoTemFornecedor Buscar(long cod)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    VeiculoTemFornecedor veiculofornecedor = new VeiculoTemFornecedor();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_VEICULO_TEM_FORNECEDOR, STATUS FROM VEICULO_TEM_FORNECEDOR WHERE STATUS <> 9 AND COD_VEICULO_TEM_FORNECEDOR = @COD_VEICULO_TEM_FORNECEDOR;";

                    comando.Parameters.Add("@COD_VEICULO_TEM_FORNECEDOR",MySqlDbType.Int16).Value = cod; 
                    MySqlDataReader leitor = comando.ExecuteReader();

                    if (leitor.Read())
                    {
                        veiculofornecedor.CodigoVeiculoTemFornecedor = Int16.Parse(leitor["COD_VEICULO_TEM_FORNECEDOR"].ToString());
                        veiculofornecedor.CodigoVeiculo = Int16.Parse(leitor["COD_VEICULO"].ToString());
                        veiculofornecedor.CodigoVeiculo = Int16.Parse(leitor["COD_FORNECEDOR"].ToString());
                        veiculofornecedor.Status = Int16.Parse(leitor["STATUS"].ToString());
                    }

                    return veiculofornecedor;
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
                    comando.CommandText = "SELECT COUNT(COD_VEICULO_TEM_FORNECEDOR) FROM VEICULO_TEM_FORNECEDOR;";

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