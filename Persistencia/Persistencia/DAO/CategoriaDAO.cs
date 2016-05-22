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
    public class CategoriaDAO : IDAO<Categoria>, IDisposable
    {
        private Connection _connection;

        public CategoriaDAO()
        {
            _connection = new Connection();
        }

        public bool Inserir(Categoria categoria)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO CATEGORIA(NOME,VALOR,STATUS) VALUES (@NOME,@VALOR,@STATUS);";

                    comando.Parameters.Add("@NOME", MySqlDbType.Text).Value = categoria.Nome;
                    comando.Parameters.Add("@VALOR", MySqlDbType.Decimal).Value = categoria.Valor;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = categoria.Status;

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

        public bool Remover(Categoria categoria)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE CATEGORIA SET STATUS = @STATUS WHERE COD_CATEGORIA = @COD_CATEGORIA";

                    comando.Parameters.Add("@COD_CATEGORIA", MySqlDbType.Int16).Value = categoria.CodigoCategoria;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = categoria.Status;

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


        public bool Atualizar(Categoria categoria)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE CATEGORIA SET NOME = @NOME, VALOR = @VALOR, STATUS = @STATUS WHERE COD_CATEGORIA = @COD_CATEGORIA;";

                    comando.Parameters.Add("@NOME", MySqlDbType.Text).Value = categoria.Nome;
                    comando.Parameters.Add("@VALOR", MySqlDbType.Decimal).Value = categoria.Valor;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = categoria.Status;

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

        public List<Categoria> Listar()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    List<Categoria> categorias = new List<Categoria>();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_CATEGORIA,NOME,VALOR,STATUS FROM CATEGORIA WHERE STATUS <> 9;";
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Categoria categoria = new Categoria();
                        categoria.CodigoCategoria = Int16.Parse(leitor["COD_CATEGORIA"].ToString());
                        categoria.Nome = leitor["NOME"].ToString();
                        categoria.Valor = decimal.Parse(leitor["VALOR"].ToString());
                        categoria.Status = Int16.Parse(leitor["STATUS"].ToString());

                        categorias.Add(categoria);
                    }

                    return categorias;
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