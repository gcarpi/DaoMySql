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
    public class PessoaFisicaDAO: IDAO<PessoaFisica>, IDisposable
    {
        private Connection _connection;

        public PessoaFisicaDAO()
        {
            _connection = new Connection();
        }

        public long Inserir(PessoaFisica pessoa)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO PESSOA_FISICA (NOME,RG,CPF,DATA_NASCIMENTO,CNH,PASSAPORTE,NATURALIDADE,STATUS) VALUES (@NOME,@RG,@CPF,@DATA_NASCIMENTO,@CNH,@PASSAPORTE,@NATURALIDADE,@STATUS);";

                    comando.Parameters.Add("@NOME", MySqlDbType.Text).Value = pessoa.Nome;
                    comando.Parameters.Add("@RG", MySqlDbType.Text).Value = pessoa.RG;
                    comando.Parameters.Add("@DATA_NASCIMENTO", MySqlDbType.Int16).Value = pessoa.DataNascimento;
                    comando.Parameters.Add("@CNH", MySqlDbType.Text).Value = pessoa.CNH;
                    comando.Parameters.Add("@PASSAPORTE", MySqlDbType.Text).Value = pessoa.Passaporte;
                    comando.Parameters.Add("@NATURALIDADE", MySqlDbType.Text).Value = pessoa.Naturalidade;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = pessoa.Status;

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

        public bool Remover(PessoaFisica pessoa)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE PESSOA_FISICA SET STATUS = @STATUS WHERE COD_PESSOA_FISICA = @COD_PESSOA_FISICA";

                    comando.Parameters.Add("@COD_PESSOA_FISICA", MySqlDbType.Int16).Value = pessoa.CodigoPessoaFisica;
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

        public bool Atualizar(PessoaFisica pessoa)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE  PESSOA_FISICA SET NOME = @NOME, RG = @RG, CPF = @CPF, DATA_NASCIMENTO = @DATA_NASCIMENTO, CNH = @CNH, PASSAPORTE = @PASSAPORTE, NATURALIDADE = @NATURALIDADE WHERE COD_PESSOA_FISICA = @COD_PESSOA_FISICA;";

                    comando.Parameters.Add("@COD_PESSOA_FISICA", MySqlDbType.Int16).Value = pessoa.CodigoPessoaFisica;
                    comando.Parameters.Add("@NOME", MySqlDbType.Text).Value = pessoa.Nome;
                    comando.Parameters.Add("@RG", MySqlDbType.Text).Value = pessoa.RG;
                    comando.Parameters.Add("@DATA_NASCIMENTO", MySqlDbType.Int16).Value = pessoa.DataNascimento;
                    comando.Parameters.Add("@CNH", MySqlDbType.Text).Value = pessoa.CNH;
                    comando.Parameters.Add("@PASSAPORTE", MySqlDbType.Text).Value = pessoa.Passaporte;
                    comando.Parameters.Add("@NATURALIDADE", MySqlDbType.Text).Value = pessoa.Naturalidade;
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

        public List<PessoaFisica> Listar()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    List<PessoaFisica> pessoas = new List<PessoaFisica>();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_PESSOA_FISICA,NOME,RG,CPF,DATA_NASCIMENTO,CNH,PASSAPORTE,NATURALIDADE,STATUS FROM PESSOA_FISICA WHERE STATUS <> 9;";
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        PessoaFisica pessoa = new PessoaFisica();
                        pessoa.CodigoPessoaFisica = Int16.Parse(leitor["COD_PESSOA_FISICA"].ToString());
                        pessoa.Nome = leitor["NOME"].ToString();
                        pessoa.RG = leitor["RG"].ToString();
                        pessoa.CPF = leitor["CPF"].ToString();
                        pessoa.DataNascimento = leitor["DATA_NASCIMENTO"].ToString();
                        pessoa.CNH = leitor["CNH"].ToString();
                        pessoa.Passaporte = leitor["PASSAPORTE"].ToString();
                        pessoa.CNH = leitor["NATURALIDADE"].ToString();
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

        public PessoaFisica Buscar(int cod)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    PessoaFisica pessoa = new PessoaFisica();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_PESSOA_FISICA,NOME,RG,CPF,DATA_NASCIMENTO,CNH,PASSAPORTE,NATURALIDADE,STATUS FROM PESSOA_FISICA WHERE STATUS <> 9 AND COD_PESSOA_FISICA = @COD_PESSOA_FISICA;";

                    comando.Parameters.Add("@COD_PESSOA_FISICA", MySqlDbType.Int16).Value = cod;
                    MySqlDataReader leitor = comando.ExecuteReader();

                    if (leitor.Read())
                    {
                        pessoa.CodigoPessoaFisica = Int16.Parse(leitor["COD_PESSOA_FISICA"].ToString());
                        pessoa.Nome = leitor["NOME"].ToString();
                        pessoa.RG = leitor["RG"].ToString();
                        pessoa.CPF = leitor["CPF"].ToString();
                        pessoa.DataNascimento = leitor["DATA_NASCIMENTO"].ToString();
                        pessoa.CNH = leitor["CNH"].ToString();
                        pessoa.Passaporte = leitor["PASSAPORTE"].ToString();
                        pessoa.CNH = leitor["NATURALIDADE"].ToString();
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

        public void Dispose()
        {
            _connection.Fechar();
            GC.SuppressFinalize(this);
        }
    }
}