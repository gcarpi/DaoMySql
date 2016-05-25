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
    public class CheckListDAO: IDAO<CheckList>,IDisposable
    {
        private Connection _connection;

        public CheckListDAO()
        {
            _connection = new Connection();
        }

        public long Inserir(CheckList checklist)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO CHECKLIST(OBSERVACAO,STATUS_CHECKLIST) VALUES (@OBSERVACAO,@STATUS_CHECKLIST);";

                    comando.Parameters.Add("@OBSERVACAO", MySqlDbType.Text).Value = checklist.Observacao;
                    comando.Parameters.Add("@STATUS_CHECKLIST", MySqlDbType.Int16).Value = checklist.Status_CheckList;

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

        public bool Remover(CheckList checklist)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE CHECKLIST SET STATUS = @STATUS WHERE COD_CHECKLIST = @COD_CHECKLIST";

                    comando.Parameters.Add("@COD_CHECKLIST", MySqlDbType.Int16).Value = checklist.CodigoCheckList;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = checklist.Status;

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

        public bool Atualizar(CheckList checklist)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE CHECKLIST SET OBSERVACAO = @OBSERVACAO, STATUS_CHECKLIST = @STATUS_CHECKLIST WHERE COD_CHECKLIST = @COD_CHECKLIST;";

                    comando.Parameters.Add("@COD_CHECKLIST", MySqlDbType.Int16).Value = checklist.CodigoCheckList;
                    comando.Parameters.Add("@OBSERVACAO", MySqlDbType.Text).Value = checklist.Observacao;
                    comando.Parameters.Add("@STATUS_CHECKLIST", MySqlDbType.Int16).Value = checklist.Status_CheckList;

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

        public List<CheckList> Listar()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    List<CheckList> checklists = new List<CheckList>();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_CHECKLIST,OBSERVACAO,STATUS_CHECKLIST,STATUS FROM CHECKLIST WHERE STATUS <> 9;";
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        CheckList checklist = new CheckList();
                        checklist.CodigoCheckList = Int16.Parse(leitor["COD_CHECKLIST"].ToString());
                        checklist.Observacao= leitor["OBSERVACAO"].ToString();
                        checklist.Status_CheckList = Int16.Parse(leitor["STATUS_CHECKLIST"].ToString());
                        checklist.Status = Int16.Parse(leitor["STATUS"].ToString());

                        checklists.Add(checklist);
                    }

                    return checklists;
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

        public CheckList Buscar(long cod)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    CheckList checklist = new CheckList();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COD_CHECKLIST,OBSERVACAO,STATUS_CHECKLIST,STATUS FROM CHECKLIST WHERE STATUS <> 9 AND COD_CHECKLIST = @COD_CHECKLIST;";

                    comando.Parameters.Add("@COD_CHECKLIST",MySqlDbType.Int16).Value = cod;
                    MySqlDataReader leitor = comando.ExecuteReader();

                    if (leitor.Read())
                    {
                        checklist.CodigoCheckList = Int16.Parse(leitor["COD_CHECKLIST"].ToString());
                        checklist.Observacao = leitor["OBSERVACAO"].ToString();
                        checklist.Status_CheckList = Int16.Parse(leitor["STATUS_CHECKLIST"].ToString());
                        checklist.Status = Int16.Parse(leitor["STATUS"].ToString());
                    }

                    return checklist;
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
                    comando.CommandText = "SELECT COUNT(COD_CHECKLIST) FROM CHECKLIST  WHERE STATUS <> 9;";

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