// Importa a biblioteca SQLite.
// Essa biblioteca contém as classes necessárias para criar conexões,
// executar comandos SQL e manipular o banco de dados SQLite.
using System.Data.SQLite;

// Namespace responsável pelas classes relacionadas ao banco de dados.
namespace Vendinha.Database
{
    // Classe responsável pela criação e estrutura inicial do banco.
    public class Banco
    {
        // Método estático que pode ser chamado sem criar um objeto Banco.
        // Sua função é verificar e criar as tabelas necessárias para o sistema.
        public static void CriarBanco()
        {
            // Cria uma conexão com o banco utilizando o método GetConnection().
            //
            // O "using" garante que a conexão será fechada automaticamente
            // quando o bloco terminar, mesmo se ocorrer algum erro.
            //
            // Equivalente a:
            // conexao.Close();
            // conexao.Dispose();
            using (var conexao = Conexao.GetConnection())
            {
                // Armazena um comando SQL dentro de uma string.
                //
                // CREATE TABLE IF NOT EXISTS significa:
                // "Crie a tabela apenas se ela ainda não existir".
                //
                // Isso evita erros caso o sistema seja executado várias vezes.
                string tabelaClientes = @"
                CREATE TABLE IF NOT EXISTS Clientes(
                
                    -- Chave primária da tabela.
                    -- Cada cliente terá um ID único.
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,

                    -- Nome do cliente.
                    -- NOT NULL significa que não pode ficar vazio.
                    Nome TEXT NOT NULL,

                    -- CPF do cliente.
                    -- UNIQUE impede CPFs duplicados.
                    CPF TEXT NOT NULL UNIQUE,

                    -- Data de nascimento.
                    DataNascimento TEXT NOT NULL,

                    -- Campo opcional para e-mail.
                    Email TEXT
                );
                ";

                // Criação da tabela de dívidas.
                string tabelaDividas = @"
                CREATE TABLE IF NOT EXISTS Dividas(
                
                    -- Identificador único da dívida.
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,

                    -- Guarda qual cliente possui a dívida.
                    ClienteId INTEGER NOT NULL,

                    -- Valor da dívida.
                    Valor REAL NOT NULL,

                    -- Situação da dívida.
                    -- Exemplos:
                    -- Pendente
                    -- Paga
                    -- Atrasada
                    Situacao TEXT NOT NULL,

                    -- Data em que a dívida foi criada.
                    DataCriacao TEXT NOT NULL,

                    -- Data do pagamento.
                    -- Pode ficar vazia caso ainda não tenha sido paga.
                    DataPagamento TEXT,

                    -- Cria relacionamento com a tabela Clientes.
                    --
                    -- Isso significa que ClienteId deve existir
                    -- na tabela Clientes.
                    FOREIGN KEY(ClienteId)
                    REFERENCES Clientes(Id)

                 );
                 ";

                // Cria um objeto SQLiteCommand.
                //
                // Esse objeto recebe:
                // 1 - O comando SQL
                // 2 - A conexão com o banco
                //
                // Neste caso ele está preparado para criar a tabela Clientes.
                SQLiteCommand cmd = new SQLiteCommand(tabelaClientes, conexao);

                // Executa o comando SQL.
                //
                // ExecuteNonQuery é usado quando não esperamos retorno.
                //
                // Exemplos:
                // CREATE
                // INSERT
                // UPDATE
                // DELETE
                //
                // Aqui ele executa o CREATE TABLE Clientes.
                cmd.ExecuteNonQuery();

                // Reaproveita a variável cmd.
                //
                // Agora ela passa a armazenar o comando SQL
                // responsável pela criação da tabela Dividas.
                cmd = new SQLiteCommand(tabelaDividas, conexao);

                // Executa o CREATE TABLE Dividas.
                cmd.ExecuteNonQuery();
            }

            // Quando o código sai do bloco using:
            //
            // A conexão é fechada automaticamente.
            //
            // Isso evita:
            // - Vazamento de memória
            // - Conexões abertas desnecessariamente
            // - Travamentos no banco
        }
    }
}