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
    public class NivelPermissaoDAO: IDAO<NivelPermissaoUsuario>, IDisposable
    {
        private Connection _connection;

        public NivelPermissaoDAO()
        {
            _connection = new Connection();
        }

        public long Inserir(NivelPermissaoUsuario nivel)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO NIVEL_PERMISSAO_USUARIO (NIVEL_PERMISSAO,COD_USUARIO) VALUES (@NIVEL_PERMISSAO,@COD_USUARIO);";

                    comando.Parameters.Add("@NIVEL_PERMISSAO", MySqlDbType.Text).Value = nivel.NivelPermissao;
                    comando.Parameters.Add("@COD_USUARIO", MySqlDbType.Int16).Value = nivel.CodigoUsuario;

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

        public bool Remover(NivelPermissaoUsuario nivel)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE NIVEL_PERMISSAO_USUARIO SET STATUS = @STATUS WHERE COD_NIVEL_PERMISSAO_USUARIO = @COD_NIVEL_PERMISSAO_USUARIO";

                    comando.Parameters.Add("@COD_NIVEL_PERMISSAO", MySqlDbType.Int16).Value = nivel.CodigoNivelPermissaoUsuario;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = nivel.Status;


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


        public bool Atualizar(NivelPermissaoUsuario nivel)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE NIVEL_PERMISSAO_USUARIO SET NIVEL_PERMISSAO = @NIVEL_PERMISSAO WHERE COD_NIVEL_PERMISSAO_USUARIO = @COD_NIVEL_PERMISSAO_USUARIO;";

                    comando.Parameters.Add("@NIVEL_PERMISSAO", MySqlDbType.Text).Value = nivel.NivelPermissao;
                    comando.Parameters.Add("@COD_NIVEL_PERMISSAO_USUARIO", MySqlDbType.Int16).Value = nivel.CodigoUsuario;

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

        public List<NivelPermissaoUsuario> Listar()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    List<NivelPermissaoUsuario> nivels = new List<NivelPermissaoUsuario>();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_NIVEL_PERMISSAO,NIVEL_PERMISSAO,STATUS,COD_USUARIO FROM NIVEL_PERMISSAO_USUARIO  WHERE STATUS <> 9;";
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        NivelPermissaoUsuario nivel = new NivelPermissaoUsuario();
                        nivel.CodigoNivelPermissaoUsuario = Int16.Parse(leitor["COD_NIVEL_PERMISSAO_USUARIO"].ToString());
                        nivel.NivelPermissao = leitor["NIVEL_PERMISSAO"].ToString();
                        nivel.CodigoUsuario = Int16.Parse(leitor["COD_USUARIO"].ToString());
                        nivel.Status = Int16.Parse(leitor["STATUS"].ToString());

                        nivels.Add(nivel);
                    }

                    return nivels;
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

        public NivelPermissaoUsuario Buscar(long cod)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    NivelPermissaoUsuario nivel = new NivelPermissaoUsuario();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_NIVEL_PERMISSAO,NIVEL_PERMISSAO,STATUS,COD_USUARIO FROM NIVEL_PERMISSAO_USUARIO  WHERE STATUS <> 9 AND COD_NIVEL_PERMISSAO_USUARIO = @COD_NIVEL_PERMISSAO_USUARIO;";

                    comando.Parameters.Add("@COD_NIVEL_PERMISSAO_USUARIO",MySqlDbType.Int16).Value = cod;
                    MySqlDataReader leitor = comando.ExecuteReader();

                    if (leitor.Read())
                    {
                        nivel.CodigoNivelPermissaoUsuario = Int16.Parse(leitor["COD_NIVEL_PERMISSAO_USUARIO"].ToString());
                        nivel.NivelPermissao = leitor["NIVEL_PERMISSAO"].ToString();
                        nivel.CodigoUsuario = Int16.Parse(leitor["COD_USUARIO"].ToString());
                        nivel.Status = Int16.Parse(leitor["STATUS"].ToString());
                    }

                    return nivel;
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
                    comando.CommandText = "SELECT COUNT(COD_NIVEL_PERMISSAO_USUARIO) FROM NIVEL_PERMISSAO_USUARIO;";

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