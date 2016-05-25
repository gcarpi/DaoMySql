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
    public class PessoaJuridicaDAO: IDAO<PessoaJuridica>, IDisposable
    {
        private Connection _connection;

        public PessoaJuridicaDAO()
        {
            _connection = new Connection();
        }

        public long Inserir(PessoaJuridica pessoa)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO PESSOA_JURIDICA (NOME_FANTASIA,RAZAO_SOCIAL,CNPJ,INSCRICAO_ESTADUAL,COD_CLIENTE) VALUES (@NOME_FANTASIA,@RAZAO_SOCIAL,@CNPJ,@INSCRICAO_ESTADUAL,@COD_CLIENTE);";

                    comando.Parameters.Add("@NOME_FANTASIA", MySqlDbType.Text).Value = pessoa.NomeFantasia;
                    comando.Parameters.Add("@RAZAO_SOCIAL", MySqlDbType.Text).Value = pessoa.RazaoSocial;
                    comando.Parameters.Add("@CNPJ", MySqlDbType.Int16).Value = pessoa.CNPJ;
                    comando.Parameters.Add("@INSCRICAO_ESTADUAL", MySqlDbType.Text).Value = pessoa.InscricaoEstadual;
                    comando.Parameters.Add("@COD_CLIENTE", MySqlDbType.Int16).Value = pessoa.CodigoCliente;

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

        public bool Remover(PessoaJuridica pessoa)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE PESSOA_JURIDICA SET STATUS = @STATUS WHERE COD_PESSOA_JURIDICA = @COD_PESSOA_JURIDICA";

                    comando.Parameters.Add("@COD_PESSOA_JURIDICA", MySqlDbType.Int16).Value = pessoa.CodigoPessoaJuridica;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = pessoa.Status;

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

        public bool Atualizar(PessoaJuridica pessoa)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE PESSOA_JURIDICA SET NOME_FANTASIA = @NOME_FANTASIA, RAZAO_SOCIAL = @RAZAO_SOCIAL, CNPJ = @CNPJ, INSCRICAO_ESTADUAL = @INSCRICAO_ESTADUAL WHERE COD_PESSOA_JURIDICA = @COD_PESSOA_JURIDICA;";

                    comando.Parameters.Add("@COD_PESSOA_JURIDICA", MySqlDbType.Int16).Value = pessoa.CodigoPessoaJuridica;
                    comando.Parameters.Add("@NOME_FANTASIA", MySqlDbType.Text).Value = pessoa.NomeFantasia;
                    comando.Parameters.Add("@RAZAO_SOCIAL", MySqlDbType.Text).Value = pessoa.RazaoSocial;
                    comando.Parameters.Add("@CNPJ", MySqlDbType.Int16).Value = pessoa.CNPJ;
                    comando.Parameters.Add("@INSCRICAO_ESTADUAL", MySqlDbType.Text).Value = pessoa.InscricaoEstadual;
                    
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

        public List<PessoaJuridica> Listar()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    List<PessoaJuridica> pessoas = new List<PessoaJuridica>();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_PESSOA_JURIDICA,NOME_FANTASIA,RAZAO_SOCIAL,CNPJ,INSCRICAO_ESTADUAL,COD_CLIENTE,COD_FORNECEDOR,STATUS FROM PESSOA_JURIDICA WHERE STATUS <> 9;";
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        PessoaJuridica pessoa = new PessoaJuridica();
                        pessoa.CodigoPessoaJuridica = Int16.Parse(leitor["COD_PESSOA_JURIDICA"].ToString());
                        pessoa.NomeFantasia = leitor["NOME_FANTASIA"].ToString();
                        pessoa.RazaoSocial = leitor["RAZAO_SOCIAL"].ToString();
                        pessoa.CNPJ = leitor["CNPJ"].ToString();
                        pessoa.InscricaoEstadual = leitor["INSCRICAO_ESTADUAL"].ToString();
                        pessoa.CodigoCliente = Int16.Parse(leitor["COD_CLIENTE"].ToString());
                        pessoa.Status = Int16.Parse(leitor["STATUS"].ToString());

                        pessoas.Add(pessoa);
                    }

                    return pessoas;
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

        public PessoaJuridica Buscar(long cod)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    PessoaJuridica pessoa = new PessoaJuridica();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_PESSOA_JURIDICA,INSCRICAO_ESTADUAL,RAZAO_SOCIAL,CNPJ,NOME_FANTASIA,COD_CLIENTE,COD_FORNECEDOR,STATUS FROM PESSOA_JURIDICA WHERE STATUS <> 9 AND COD_PESSOA_JURIDICA = @COD_PESSOA_JURIDICA;";

                    comando.Parameters.Add("@COD_PESSOA_JURIDICA",MySqlDbType.Int16).Value = cod;
                    MySqlDataReader leitor = comando.ExecuteReader();

                    if (leitor.Read())
                    {
                        pessoa.CodigoPessoaJuridica = Int16.Parse(leitor["COD_PESSOA_JURIDICA"].ToString());
                        pessoa.NomeFantasia = leitor["NOME_FANTASIA"].ToString();
                        pessoa.RazaoSocial = leitor["RAZAO_SOCIAL"].ToString();
                        pessoa.CNPJ = leitor["CNPJ"].ToString();
                        pessoa.InscricaoEstadual = leitor["INSCRICAO_ESTADUAL"].ToString();
                        pessoa.CodigoCliente = Int16.Parse(leitor["COD_CLIENTE"].ToString());
                        pessoa.Status = Int16.Parse(leitor["STATUS"].ToString());
                    }

                    return pessoa;
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
                    comando.CommandText = "SELECT COUNT(COD_PESSOA_JURIDICA) FROM PESSOA_JURIDICA;";

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