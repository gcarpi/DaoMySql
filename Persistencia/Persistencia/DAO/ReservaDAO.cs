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
    public class ReservaDAO: IDAO<Reserva>,IDisposable
    {
        private Interface.IConnection _connection;

        public ReservaDAO()
        {
            _connection = new Connection();
        }

        public bool Inserir(Reserva reserva)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO RESERVA(DATA_RESERVA,FORMA_PAGAMENTO,TIPO_RETIRADA,DATA_ENTREGA,DATA_RETIRADA,SITUACAO,STATUS,COD_CLIENTE,COD_USUARIO,COD_VEICULO) VALUES (@DATA_RESERVA,@FORMA_PAGAMENTO,@TIPO_RETIRADA,@DATA_ENTREGA,@DATA_RETIRADA,@SITUACAO,@STATUS,@COD_CLIENTE,@COD_USUARIO,@COD_VEICULO);";

                    comando.Parameters.Add("@DATA_RESERVA", MySqlDbType.Text).Value = reserva.DataReserva;
                    comando.Parameters.Add("@FORMA_PAGAMENTO", MySqlDbType.Int16).Value = reserva.FormaPagamento;
                    comando.Parameters.Add("@TIPO_RETIRADA", MySqlDbType.Int16).Value = reserva.TipoRetirada;
                    comando.Parameters.Add("@DATA_ENTREGA", MySqlDbType.Text).Value = reserva.DataEntrega;
                    comando.Parameters.Add("@DATA_RETIRADA", MySqlDbType.Text).Value = reserva.DataRetirada;
                    comando.Parameters.Add("@SITUACAO", MySqlDbType.Int16).Value = reserva.Situacao;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = reserva.Status;
                    comando.Parameters.Add("@COD_CLIENTE", MySqlDbType.Int16).Value = reserva.CodigoCliente;
                    comando.Parameters.Add("@COD_USUARIO", MySqlDbType.Int16).Value = reserva.CodigoUsuario;
                    comando.Parameters.Add("@COD_VEICULO", MySqlDbType.Int16).Value = reserva.CodigoVeiculo;

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

        public bool Remover(Reserva reserva)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE RESERVA SET STATUS = @STATUS WHERE NUMERO_RESERVA = @NUMERO_RESERVA";

                    comando.Parameters.Add("@NUMERO_RESERVA", MySqlDbType.Int16).Value = reserva.NumeroReserva;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int16).Value = reserva.Status;

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

        public bool Atualizar(Reserva reserva)
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE USUARIO SET DATA_RESERVA = @DATA_RESERVA, FORMA_PAGAMENTO = @FORMA_PAGAMENTO, TIPO_RETIRADA = @TIPO_RETIRADA, DATA_ENTREGA = @DATA_ENTREGA, DATA_RETIRADA = @DATA_RETIRADA, SITUACAO = @SITUACAO, COD_CLIENTE = @COD_CLIENTE, COD_USUARIO = @COD_USUARIO, COD_VEICULO = @COD_VEICULO WHERE COD_RESERVA = @COD_RESERVA;";

                    comando.Parameters.Add("@DATA_RESERVA", MySqlDbType.Text).Value = reserva.DataReserva;
                    comando.Parameters.Add("@FORMA_PAGAMENTO", MySqlDbType.Int16).Value = reserva.FormaPagamento;
                    comando.Parameters.Add("@TIPO_RETIRADA", MySqlDbType.Int16).Value = reserva.TipoRetirada;
                    comando.Parameters.Add("@DATA_ENTREGA", MySqlDbType.Text).Value = reserva.DataEntrega;
                    comando.Parameters.Add("@DATA_RETIRADA", MySqlDbType.Text).Value = reserva.DataRetirada;
                    comando.Parameters.Add("@SITUACAO", MySqlDbType.Int16).Value = reserva.Situacao;
                    comando.Parameters.Add("@COD_CLIENTE", MySqlDbType.Int16).Value = reserva.CodigoCliente;
                    comando.Parameters.Add("@COD_USUARIO", MySqlDbType.Int16).Value = reserva.CodigoUsuario;
                    comando.Parameters.Add("@COD_VEICULO", MySqlDbType.Int16).Value = reserva.CodigoVeiculo;

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

        public List<Reserva> Listar()
        {
            try
            {
                using (MySqlCommand comando = _connection.Buscar().CreateCommand())
                {
                    List<Reserva> reservas = new List<Reserva>();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT NUMERO_RESERVA,DATA_RESERVA,FORMA_PAGAMENTO,TIPO_RETIRADA,DATA_ENTREGA,DATA_RETIRADA,SITUACAO,STATUS,COD_CLIENTE,COD_USUARIO,COD_VEICULO FROM RESERVA WHERE STATUS <> 9;";
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Reserva reserva = new Reserva();
                        reserva.NumeroReserva = Int16.Parse(leitor["NUMERO_RESERVA"].ToString());
                        reserva.DataReserva = leitor["DATA_RESERVA"].ToString();
                        reserva.FormaPagamento = Int16.Parse(leitor["FORMA_PAGAMENTO"].ToString());
                        reserva.TipoRetirada = Int16.Parse(leitor["TIPO_RETIRADA"].ToString());
                        reserva.DataEntrega = leitor["DATA_ENTREGA"].ToString();
                        reserva.DataRetirada = leitor["DATA_RETIRADA"].ToString();
                        reserva.Situacao = Int16.Parse(leitor["SITUACAO"].ToString());
                        reserva.Status = Int16.Parse(leitor["STATUS"].ToString());
                        reserva.CodigoCliente = Int16.Parse(leitor["COD_CLIENTE"].ToString());
                        reserva.CodigoUsuario = Int16.Parse(leitor["COD_USUARIO"].ToString());
                        reserva.CodigoVeiculo = Int16.Parse(leitor["COD_VEICULO"].ToString());

                        reservas.Add(reserva);
                    }

                    return reservas;
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
