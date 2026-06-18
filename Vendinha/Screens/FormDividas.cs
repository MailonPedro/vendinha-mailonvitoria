using System;
using System.Data;
using System.Windows.Forms;
using Vendinha.Models;
using Vendinha.Services;

namespace Vendinha
{
    public partial class FormDividas : Form
    {
        private int clienteIdSelecionado;
        private DividaService dividaService = new DividaService();

        public FormDividas()
        {
            InitializeComponent();
        }

        private void buttonbuscarcliente_Click(object sender, EventArgs e)
        {
            FormBuscar tela = new FormBuscar();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                Cliente cliente = tela.ClienteSelecionado;

                clienteIdSelecionado = cliente.ID;
                textobuscarcliente.Text = cliente.Nome;

                CarregarDividas();
            }
        }

        private void Valor_Click(object sender, EventArgs e)
        {
            if (clienteIdSelecionado == 0)
            {
                MessageBox.Show("Selecione um cliente.");
                return;
            }

            decimal valor;

            if (!decimal.TryParse(textovalor.Text, out valor))
            {
                MessageBox.Show("Valor inválido.");
                return;
            }

            if (dividaService.ClientePossuiDividaAberta(clienteIdSelecionado))
            {
                MessageBox.Show("Este cliente já possui dívida pendente.");
                return;
            }

            Divida divida = new Divida
            {
                ClienteId = clienteIdSelecionado,
                Valor = valor,
                Situacao = "Pendente",
                DataCriacao = DateTime.Now
            };

            string erro = dividaService.ValidarDivida(divida);

            if (!string.IsNullOrEmpty(erro))
            {
                MessageBox.Show(erro);
                return;
            }

            dividaService.RegistrarDivida(divida);

            MessageBox.Show("Dívida registrada com sucesso!");

            textovalor.Clear();
            CarregarDividas();
        }

        private void CarregarDividas()
        {
            if (clienteIdSelecionado == 0)
            {
                return;
            }

            DataTable dt = dividaService.BuscarDividasPorCliente(clienteIdSelecionado);
            listadividas.DataSource = dt;

            if (listadividas.Columns["Id"] != null)
            {
                listadividas.Columns["Id"].Visible = false;
            }
        }

        private void buttonpagamento_Click(object sender, EventArgs e)
        {
            if (listadividas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma dívida.");
                return;
            }

            string situacao = listadividas.SelectedRows[0].Cells["Situacao"].Value.ToString();

            if (situacao == "Pagamento Realizado")
            {
                MessageBox.Show("Esta dívida já está paga.");
                return;
            }

            int idDivida = Convert.ToInt32(listadividas.SelectedRows[0].Cells["Id"].Value);

            dividaService.MarcarComoPaga(idDivida);

            MessageBox.Show("Pagamento realizado com sucesso!");

            CarregarDividas();
        }
    }
}