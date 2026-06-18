using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SQLite;
using Vendinha.Database;
using Vendinha.Models;

namespace Vendinha.Services
{
    public class DividaService
    {
        public string ValidarDivida(Divida divida)
        {
            ValidationContext contexto = new ValidationContext(divida);
            List<ValidationResult> erros = new List<ValidationResult>();

            bool valido = Validator.TryValidateObject(divida, contexto, erros, true);

            if (!valido)
            {
                return erros[0].ErrorMessage;
            }

            return string.Empty;
        }

        public bool ClientePossuiDividaAberta(int clienteId)
        {
            using (var conexao = Conexao.GetConnection())
            {
                string sql = @"
            SELECT COUNT(*)
            FROM Dividas
            WHERE ClienteId = @clienteId
            AND Situacao = 'Pendente'";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@clienteId", clienteId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public void RegistrarDivida(Divida divida)
        {
            using (var conexao = Conexao.GetConnection())
            {
                string sql = @"
            INSERT INTO Dividas
            (
                ClienteId,
                Valor,
                Situacao,
                DataCriacao
            )
            VALUES
            (
                @clienteId,
                @valor,
                @situacao,
                @dataCriacao
            )";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@clienteId", divida.ClienteId);
                    cmd.Parameters.AddWithValue("@valor", divida.Valor);
                    cmd.Parameters.AddWithValue("@situacao", divida.Situacao);
                    cmd.Parameters.AddWithValue("@dataCriacao", divida.DataCriacao.ToString("yyyy-MM-dd"));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void MarcarComoPaga(int idDivida)
        {
            using (var conexao = Conexao.GetConnection())
            {
                string sql = @"
            UPDATE Dividas
            SET
                Situacao = 'Pagamento Realizado',
                DataPagamento = @dataPagamento
            WHERE Id = @id";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@dataPagamento", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@id", idDivida);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable BuscarDividasPorCliente(int clienteId)
        {
            using (var conexao = Conexao.GetConnection())
            {
                string sql = @"
            SELECT
                Id,
                printf('R$ %.2f', Valor) AS [Dívida],
                DataCriacao AS [Data Criação],
                DataPagamento AS [Data Pagamento],
                Situacao
            FROM Dividas
            WHERE ClienteId = @clienteId
            ORDER BY DataCriacao DESC";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@clienteId", clienteId);
                    DataTable dt = new DataTable();

                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }

                    return dt;
                }
            }
        }

        public Divida BuscarPorId(int id)
        {
            using (var conexao = Conexao.GetConnection())
            {
                string sql = @"
            SELECT *
            FROM Dividas
            WHERE Id = @id";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Divida
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ClienteId = Convert.ToInt32(reader["ClienteId"]),
                                Valor = Convert.ToDecimal(reader["Valor"]),
                                Situacao = reader["Situacao"].ToString(),
                                DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                                DataPagamento = reader["DataPagamento"] == DBNull.Value
                                    ? (DateTime?)null
                                    : Convert.ToDateTime(reader["DataPagamento"])
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}