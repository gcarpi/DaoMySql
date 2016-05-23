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
    public class PermissaoDAO: IDAO<Permissao>, IDisposable
    {
        private Connection _connection;

        public PermissaoDAO()
        {
            _connection = new Connection();
        }

        public long Inserir(Permissao permissao)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO PERMISSAO(TIPO,NIVEL_PERMISSAO,DESCRICAO) VALUES (@TIPO,@NIVEL_PERMISSAO,@DESCRICAO);";


                    comando.Parameters.Add("@TIPO", MySqlDbType.Int16).Value = permissao.Tipo;
                    comando.Parameters.Add("@NIVEL_PERMISSAO", MySqlDbType.Int16).Value = permissao.NivelPermissao;
                    comando.Parameters.Add("@DESCRICAO", MySqlDbType.Text).Value = permissao.Descricao;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = permissao.Status;

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

        public bool Remover(Permissao permissao)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE PERMISSAO SET STATUS = @STATUS WHERE COD_PERMISSAO = @COD_PERMISSAO";

                    comando.Parameters.Add("@COD_PERMISSAO", MySqlDbType.Int16).Value = permissao.CodigoPermissao;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = permissao.Status;

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

        public bool Atualizar(Permissao permissao)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE PERMISSAO SET TIPO = @TIPO, NIVEL_PERMISSAO = @NIVEL_PERMISSAO, DESCRICAO = @DESCRICAO WHERE COD_PERMISSAO = @COD_PERMISSAO;";

                    comando.Parameters.Add("@TIPO", MySqlDbType.Int16).Value = permissao.Tipo;
                    comando.Parameters.Add("@NIVEL_PERMISSAO", MySqlDbType.Int16).Value = permissao.NivelPermissao;
                    comando.Parameters.Add("@DESCRICAO", MySqlDbType.Text).Value = permissao.Descricao;

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

        public List<Permissao> Listar()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    List<Permissao> permissaos = new List<Permissao>();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_PERMISSAO,TIPO,NIVEL_PERMISSAO,DESCRICAO,STATUS FROM PERMISSAO WHERE STATUS <> 9;";
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Permissao permissao = new Permissao();
                        permissao.CodigoPermissao = Int16.Parse(leitor["COD_PERMISSAO"].ToString());
                        permissao.Tipo = Int16.Parse(leitor["TIPO"].ToString());
                        permissao.NivelPermissao = Int16.Parse(leitor["NIVEL_PERMISSAO"].ToString());
                        permissao.Descricao = leitor["DESCRICAO"].ToString();
                        permissao.Status = Int16.Parse(leitor["STATUS"].ToString());

                        permissaos.Add(permissao);
                    }

                    return permissaos;
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

        public Permissao Buscar(int cod)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    Permissao permissao = new Permissao();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_PERMISSAO,TIPO,NIVEL_PERMISSAO,DESCRICAO,STATUS FROM PERMISSAO WHERE STATUS <> 9 AND COD_PERMISSAO = @COD_PERMISSAO;";

                    comando.Parameters.Add("@COD_PERMISSAO",MySqlDbType.Int16).Value = cod;
                    MySqlDataReader leitor = comando.ExecuteReader();

                    if (leitor.Read())
                    {
                        permissao.CodigoPermissao = Int16.Parse(leitor["COD_PERMISSAO"].ToString());
                        permissao.Tipo = Int16.Parse(leitor["TIPO"].ToString());
                        permissao.NivelPermissao = Int16.Parse(leitor["NIVEL_PERMISSAO"].ToString());
                        permissao.Descricao = leitor["DESCRICAO"].ToString();
                        permissao.Status = Int16.Parse(leitor["STATUS"].ToString());
                    }

                    return permissao;
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