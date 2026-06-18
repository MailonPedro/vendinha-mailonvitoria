using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SQLite;
using Vendinha.Database;
using Vendinha.Models;

namespace Vendinha.Services
{
    public class ClienteService
    {
        public string ValidarCliente(Cliente cliente)
        {
            ValidationContext contexto = new ValidationContext(cliente);
            List<ValidationResult> erros = new List<ValidationResult>();

            bool valido = Validator.TryValidateObject(cliente, contexto, erros, true);

            if (!valido)
            {
                return erros[0].ErrorMessage;
            }

            return string.Empty;
        }

        public Cliente BuscarPorId(int id)
        {
            using (var conexao = Conexao.GetConnection())
            {
                string sql = "SELECT * FROM Clientes WHERE ID = @id";

                SQLiteCommand cmd = new SQLiteCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@id", id);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Cliente
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Nome = reader["Nome"].ToString(),
                            CPF = reader["CPF"].ToString(),
                            Email = reader["Email"].ToString(),
                            DataNascimento = Convert.ToDateTime(reader["DataNascimento"])
                        };
                    }
                }
            }

            return null;
        }

        public bool CpfJaExiste(string cpf)
        {
            using (var conexao = Conexao.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM Clientes WHERE CPF = @cpf";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public bool CpfJaExiste(string cpf, int idIgnorado)
        {
            using (var conexao = Conexao.GetConnection())
            {
                string sql = @"
            SELECT COUNT(*)
            FROM Clientes
            WHERE CPF = @cpf
            AND ID <> @id";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    cmd.Parameters.AddWithValue("@id", idIgnorado);

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public void InserirCliente(Cliente cliente)
        {
            using (var conexao = Conexao.GetConnection())
            {
                string sql = @"
            INSERT INTO Clientes
            (
                Nome,
                CPF,
                Email,
                DataNascimento
            )
            VALUES
            (
                @nome,
                @cpf,
                @email,
                @dataNascimento
            )";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@cpf", cliente.CPF);
                    cmd.Parameters.AddWithValue("@email", cliente.Email);
                    cmd.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento.ToString("yyyy-MM-dd"));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarCliente(Cliente cliente)
        {
            using (var conexao = Conexao.GetConnection())
            {
                string sql = @"
            UPDATE Clientes
            SET
                Nome = @nome,
                CPF = @cpf,
                Email = @email,
                DataNascimento = @dataNascimento
            WHERE ID = @id";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", cliente.ID);
                    cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@cpf", cliente.CPF);
                    cmd.Parameters.AddWithValue("@email", cliente.Email);
                    cmd.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento.ToString("yyyy-MM-dd"));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool ExcluirCliente(int id)
        {
            using (var conexao = Conexao.GetConnection())
            {
                string verificarSql = @"
            SELECT COUNT(*)
            FROM Dividas
            WHERE ClienteId = @id";

                using (SQLiteCommand verificarCmd = new SQLiteCommand(verificarSql, conexao))
                {
                    verificarCmd.Parameters.AddWithValue("@id", id);
                    int quantidadeDividas = Convert.ToInt32(verificarCmd.ExecuteScalar());

                    if (quantidadeDividas > 0)
                    {
                        return false;
                    }
                }

                string sql = "DELETE FROM Clientes WHERE ID = @id";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }

        public DataTable BuscarClientes(string textoBusca, int pagina, int itensPorPagina)
        {
            int offset = (pagina - 1) * itensPorPagina;
            string filtro = "%" + textoBusca.Trim() + "%";

            using (var conexao = Conexao.GetConnection())
            {
                string sql = @"
            SELECT
                c.ID,
                c.Nome,
                c.Email,
                c.CPF,
                c.DataNascimento AS [Data Nascimento],

                (strftime('%Y', 'now') -
                 strftime('%Y', c.DataNascimento))
                -
                (strftime('%m-%d', 'now') <
                 strftime('%m-%d', c.DataNascimento))
                AS Idade,

                COALESCE(
                    SUM(
                        CASE
                            WHEN d.Situacao = 'Pendente'
                            THEN d.Valor
                            ELSE 0
                        END
                    ),
                    0
                ) AS TotalDivida

            FROM Clientes c

            LEFT JOIN Dividas d
                ON c.ID = d.ClienteId

            WHERE c.Nome LIKE @filtro

            GROUP BY c.ID

            ORDER BY TotalDivida DESC

            LIMIT @limit
            OFFSET @offset";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@filtro", filtro);
                    cmd.Parameters.AddWithValue("@limit", itensPorPagina);
                    cmd.Parameters.AddWithValue("@offset", offset);

                    DataTable dt = new DataTable();

                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }

                    return dt;
                }
            }
        }
    }
}