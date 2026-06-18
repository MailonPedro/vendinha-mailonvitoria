// Importa a biblioteca SQLite.
// Ela contém as classes necessárias para criar conexões
// e executar comandos no banco de dados SQLite.
using System.Data.SQLite;

// Namespace relacionado às classes de banco de dados.
namespace Vendinha.Database
{
    // Classe responsável por criar conexões com o banco.
    public class Conexao
    {
        // Variável estática que armazena o caminho do banco.
        //
        // "Data Source" informa ao SQLite qual arquivo
        // será utilizado como banco de dados.
        //
        // Se o arquivo vendinha.db não existir,
        // o SQLite pode criá-lo automaticamente.
        private static string caminhoBanco = "Data Source=vendinha.db";

        // Método estático responsável por devolver
        // uma conexão já aberta para quem solicitar.
        //
        // Como é static, podemos chamar:
        // Conexao.GetConnection();
        //
        // sem precisar fazer:
        // new Conexao();
        public static SQLiteConnection GetConnection()
        {
            // Cria um objeto do tipo SQLiteConnection.
            //
            // Neste momento a conexão apenas foi criada
            // em memória.
            //
            // Ainda não existe comunicação com o banco.
            SQLiteConnection conexao =
                new SQLiteConnection(caminhoBanco);

            // Abre efetivamente a conexão com o banco.
            //
            // A partir daqui o sistema consegue:
            // - Criar tabelas
            // - Inserir dados
            // - Atualizar registros
            // - Fazer consultas
            //
            // Sem esta linha qualquer comando SQL geraria erro.
            conexao.Open();

            // Retorna a conexão já aberta para quem chamou o método.
            //
            // Exemplo:
            //
            // SQLiteConnection conexao =
            //      Conexao.GetConnection();
            //
            // Agora a variável conexao poderá ser utilizada
            // para executar comandos SQL.
            return conexao;
        }
    }
}