﻿using MySql.Data.MySqlClient;
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
    public class VeiculoDAO : Interface.IDAO<Veiculo>, IDisposable
    {
        private Interface.IConnection _connection;

        public VeiculoDAO()
        {
            _connection = new Connection();
        }

        public bool Inserir(Veiculo veiculo)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO VEICULO(MARCA,MODELO,ANO_DE_FABRICACAO,CONDICAO,VIDRO_ELETRICO,TRAVA_ELETRICA,AUTOMATICO,QUANTIDADE_PORTAS,DIRECAO_HIDRAULICA,COR,AR_CONDICIONADO,STATUS,COD_CATEGORIA) VALUES (@MARCA,@MODELO,@ANO_DE_FABRICACAO,@CONDICAO,@VIDRO_ELETRICO,@TRAVA_ELETRICA,@AUTOMATICO,@QUANTIDADE_PORTAS,@DIRECAO_HIDRAULICA,@COR,@AR_CONDICIONADO,@COD_CATEGORIA,@STATUS);";

                    comando.Parameters.Add("@MARCA",MySqlDbType.Text).Value = veiculo.Marca;
                    comando.Parameters.Add("@MODELO",MySqlDbType.Text).Value = veiculo.Modelo;
                    comando.Parameters.Add("@ANO_DE_FABRICACAO",MySqlDbType.Date).Value = veiculo.AnoFabricação;
                    comando.Parameters.Add("@CONDICAO", MySqlDbType.Text).Value = veiculo.Condicao;
                    comando.Parameters.Add("@VIDRO_ELETRICO",MySqlDbType.Bit).Value = veiculo.VidroEletrico;
                    comando.Parameters.Add("@TRAVA_ELETRICA", MySqlDbType.Bit).Value = veiculo.TravaEletrica;
                    comando.Parameters.Add("@AUTOMATICO", MySqlDbType.Bit).Value = veiculo.Automatico;
                    comando.Parameters.Add("@QUANTIDADE_PORTAS", MySqlDbType.Int16).Value = veiculo.QuantidadePortas;
                    comando.Parameters.Add("@DIRECAO_HIDRAULICA", MySqlDbType.Bit).Value = veiculo.DirecaoHidraulica;
                    comando.Parameters.Add("@COR", MySqlDbType.Text).Value = veiculo.Cor;
                    comando.Parameters.Add("@AR_CONDICIONADO", MySqlDbType.Bit).Value = veiculo.ArCondicionado;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = veiculo.Status;
                    comando.Parameters.Add("@COD_CATEGORIA", MySqlDbType.Int16).Value = veiculo.CodigoCategoria;

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

        public bool Remover(Veiculo user)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE VEICULO SET STATUS = @STATUS WHERE COD_VEICULO = @COD_VEICULO";

                    comando.Parameters.Add("@COD_VEICULO", MySqlDbType.Int16).Value = user.CodigoVeiculo;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = user.Status;

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

        public bool Atualizar(Veiculo veiculo)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE USUARIO SET MARCA = @MARCA, MODELO = @MODELO, ANO_DE_FABRICACAO = @ANO_DE_FABRICACAO, CONDICAO = @CONDICAO, VIDRO_ELETRICO = @VIDRO_ELETRICO, TRAVA_ELETRICA = @TRAVA_ELETRICA, AUTOMATICO = @AUTOMATICO, QUANTIDADE_PORTAS = @QUANTIDADE_PORTAS, DIRECAO_HIDRAULICA = @DIRECAO_HIDRAULICA, COR = @COR, AR_CONDICIONADO = @AR_CONDICIONADO, COD_CATEGORIA = @COD_CATEGORIA, STATUS = @STATUS WHERE COD_VEICULO = @COD_VEICULO;";

                    comando.Parameters.Add("@MARCA", MySqlDbType.Text).Value = veiculo.Marca;
                    comando.Parameters.Add("@MODELO", MySqlDbType.Text).Value = veiculo.Modelo;
                    comando.Parameters.Add("@ANO_DE_FABRICACAO", MySqlDbType.Date).Value = veiculo.AnoFabricação;
                    comando.Parameters.Add("@CONDICAO", MySqlDbType.Text).Value = veiculo.Condicao;
                    comando.Parameters.Add("@VIDRO_ELETRICO", MySqlDbType.Bit).Value = veiculo.VidroEletrico;
                    comando.Parameters.Add("@TRAVA_ELETRICA", MySqlDbType.Bit).Value = veiculo.TravaEletrica;
                    comando.Parameters.Add("@AUTOMATICO", MySqlDbType.Bit).Value = veiculo.Automatico;
                    comando.Parameters.Add("@QUANTIDADE_PORTAS", MySqlDbType.Int16).Value = veiculo.QuantidadePortas;
                    comando.Parameters.Add("@DIRECAO_HIDRAULICA", MySqlDbType.Bit).Value = veiculo.DirecaoHidraulica;
                    comando.Parameters.Add("@COR", MySqlDbType.Text).Value = veiculo.Cor;
                    comando.Parameters.Add("@AR_CONDICIONADO", MySqlDbType.Bit).Value = veiculo.ArCondicionado;
                    comando.Parameters.Add("@COD_CATEGORIA", MySqlDbType.Int16).Value = veiculo.CodigoCategoria;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = veiculo.Status;

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

        public List<Veiculo> Listar()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    List<Veiculo> veiculos = new List<Veiculo>();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT MARCA,MODELO,ANO_DE_FABRICACAO,CONDICAO,VIDRO_ELETRICO,TRAVA_ELETRICA,AUTOMATICO,QUANTIDADE_PORTAS,DIRECAO_HIDRAULICA,COR,AR_CONDICIONADO,STATUS FROM VEICULO WHERE STATUS <> 9;";
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Veiculo veiculo = new Veiculo();
                        veiculo.Marca = leitor["MARCA"].ToString();
                        veiculo.Modelo = leitor["MODELO"].ToString();
                        veiculo.AnoFabricação = leitor["ANO_DE_FABRICACAO"].ToString();
                        veiculo.Condicao = leitor["CONDICAO"].ToString();
                        veiculo.VidroEletrico = bool.Parse(leitor["VIDRO_ELETRICO"].ToString());
                        veiculo.TravaEletrica = bool.Parse(leitor["TRAVA_ELETRICA"].ToString());
                        veiculo.Automatico = bool.Parse(leitor["AUTOMATICO"].ToString());
                        veiculo.QuantidadePortas = int.Parse(leitor["QUANTIDADE_PORTAS"].ToString());
                        veiculo.DirecaoHidraulica = bool.Parse(leitor["DIRECAO_HIDRAULICA"].ToString());
                        veiculo.Cor = leitor["COR"].ToString();
                        veiculo.ArCondicionado = bool.Parse(leitor["AR_CONDICIONADO"].ToString());
                        veiculo.Status = int.Parse(leitor["STATUS"].ToString());

                        veiculos.Add(veiculo);
                    }

                    return veiculos;
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