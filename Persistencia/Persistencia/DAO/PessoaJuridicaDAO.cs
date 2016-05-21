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
    class PessoaJuridicaDAO: IDAO<PessoaJuridica>, IDisposable
    {
        private Interface.IConnection _connection;

        public PessoaJuridicaDAO()
        {
            _connection = new Connection();
        }

        public bool Inserir(PessoaJuridica pessoa)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO PESSOA_FISICA (INSCRICAO_ESTADUAL,RAZAO_SOCIAL,CNPJ,NOME_FANTASIA,STATUS) VALUES (@INSCRICAO_ESTADUAL,@RAZAO_SOCIAL,@CNPJ,@NOME_FANTASIA,@STATUS);";

                    comando.Parameters.Add("@INSCRICAO_ESTADUAL", MySqlDbType.Text).Value = pessoa.InscricaoEstadual;
                    comando.Parameters.Add("@RAZAO_SOCIAL", MySqlDbType.Text).Value = pessoa.RazaoSocial;
                    comando.Parameters.Add("@CNPJ", MySqlDbType.Int16).Value = pessoa.CNPJ;
                    comando.Parameters.Add("@NOME_FANTASIA", MySqlDbType.Text).Value = pessoa.NomeFantasia;
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
                    comando.CommandText = "UPDATE USUARIO SET PESSOA_JURIDICA INSCRICAO_ESTADUAL = @INSCRICAO_ESTADUAL, RAZAO_SOCIAL = @RAZAO_SOCIAL, CNPJ = @CNPJ, NOME_FANTASIA = @NOME_FANTASIA WHERE COD_PESSOA_JURIDICA = @COD_PESSOA_JURIDICA;";

                    comando.Parameters.Add("@INSCRICAO_ESTADUAL", MySqlDbType.Text).Value = pessoa.InscricaoEstadual;
                    comando.Parameters.Add("@RAZAO_SOCIAL", MySqlDbType.Text).Value = pessoa.RazaoSocial;
                    comando.Parameters.Add("@CNPJ", MySqlDbType.Int16).Value = pessoa.CNPJ;
                    comando.Parameters.Add("@NOME_FANTASIA", MySqlDbType.Text).Value = pessoa.NomeFantasia;
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

        public List<PessoaJuridica> Listar()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    List<PessoaJuridica> pessoas = new List<PessoaJuridica>();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_PESSOA_JURIDICA,INSCRICAO_ESTADUAL,RAZAO_SOCIAL,CNPJ,NOME_FANTASIA,STATUS FROM PESSOA_JURIDICA WHERE STATUS <> 9;";
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        PessoaJuridica pessoa = new PessoaJuridica();
                        pessoa.CodigoPessoaJuridica = Int16.Parse(leitor["COD_PESSOA_JURIDICA"].ToString());
                        pessoa.InscricaoEstadual = leitor["INSCRICAO_ESTADUAL"].ToString();
                        pessoa.RazaoSocial = leitor["RAZAO_SOCIAL"].ToString();
                        pessoa.CNPJ = leitor["CNPJ"].ToString();
                        pessoa.NomeFantasia = leitor["NOME_FANTASIA"].ToString();
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

        public void Dispose()
        {
            _connection.Fechar();
            GC.SuppressFinalize(this);
        }
    }
}