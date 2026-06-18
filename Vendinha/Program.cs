using Vendinha.Database;

namespace Vendinha
{
    internal static class Program
    {
       
        [STAThread]
        static void Main()
        {
            Banco.CriarBanco();

            ApplicationConfiguration.Initialize();

            Application.Run(new Form1());

        }
    }
}