using System;
using System.Windows.Forms;
using Vendinha.Models;
using Vendinha.Services;

namespace Vendinha
{
    public partial class FormCadastrar : Form
    {
        private int clienteId = 0;
        private bool modoEdicao = false;
        private ClienteService clienteService = new ClienteService();

        public FormCadastrar()
        {
            InitializeComponent();
        }

        public FormCadastrar(Cliente cliente)
        {
            InitializeComponent();

            modoEdicao = true;
            clienteId = cliente.ID;

            textonome.Text = cliente.Nome;
            textocpf.Text = cliente.CPF;
            textoemail.Text = cliente.Email;
            dtNascimento.Value = cliente.DataNascimento;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                ID = clienteId,
                Nome = textonome.Text.Trim(),
                CPF = textocpf.Text.Trim(),
                Email = textoemail.Text.Trim(),
                DataNascimento = dtNascimento.Value
            };

            string mensagemErro = clienteService.ValidarCliente(cliente);

            if (!string.IsNullOrEmpty(mensagemErro))
            {
                MessageBox.Show(
                    mensagemErro,
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            bool cpfExiste = modoEdicao
                ? clienteService.CpfJaExiste(cliente.CPF, cliente.ID)
                : clienteService.CpfJaExiste(cliente.CPF);

            if (cpfExiste)
            {
                MessageBox.Show(
                    "CPF já cadastrado.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (modoEdicao)
            {
                clienteService.AtualizarCliente(cliente);
                MessageBox.Show("Cliente atualizado com sucesso!");
                Close();
            }
            else
            {
                clienteService.InserirCliente(cliente);
                MessageBox.Show("Cliente cadastrado com sucesso!");

                textonome.Clear();
                textocpf.Clear();
                textoemail.Clear();
                dtNascimento.Value = DateTime.Today;

                textonome.Focus();
            }
        }
    }
}