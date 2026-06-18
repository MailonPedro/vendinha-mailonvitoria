using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Vendinha.Models;
using Vendinha.Services;

namespace Vendinha
{
    public partial class FormBuscar : Form
    {
        private ClienteService clienteService = new ClienteService();
        private int paginaAtual = 1;
        private const int itensPorPagina = 10;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Cliente ClienteSelecionado { get; set; }

        public FormBuscar()
        {
            InitializeComponent();
        }

        private void FormBuscar_Load(object sender, EventArgs e)
        {
            CarregarClientes();
        }

        private void CarregarClientes()
        {
            string textoBusca = textobuscar.Text.Trim();

            DataTable dt = clienteService.BuscarClientes(
                textoBusca,
                paginaAtual,
                itensPorPagina
            );

            listaclientes.DataSource = dt;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            paginaAtual = 1;
            CarregarClientes();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FormCadastrar tela = new FormCadastrar();
            tela.ShowDialog();

            CarregarClientes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (listaclientes.CurrentRow == null)
            {
                MessageBox.Show("Selecione um cliente.");
                return;
            }

            int id = Convert.ToInt32(listaclientes.CurrentRow.Cells["ID"].Value);
            Cliente cliente = clienteService.BuscarPorId(id);

            FormCadastrar tela = new FormCadastrar(cliente);
            tela.ShowDialog();

            CarregarClientes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (listaclientes.CurrentRow == null)
            {
                MessageBox.Show("Selecione um cliente.");
                return;
            }

            int id = Convert.ToInt32(listaclientes.CurrentRow.Cells["ID"].Value);

            DialogResult resposta = MessageBox.Show(
                "Deseja excluir este cliente?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta == DialogResult.Yes)
            {
                clienteService.ExcluirCliente(id);
                CarregarClientes();
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaAtual > 1)
            {
                paginaAtual--;
                CarregarClientes();
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            paginaAtual++;
            CarregarClientes();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (listaclientes.CurrentRow == null)
            {
                MessageBox.Show("Selecione um cliente.");
                return;
            }

            int id = Convert.ToInt32(listaclientes.CurrentRow.Cells["ID"].Value);
            ClienteSelecionado = clienteService.BuscarPorId(id);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}