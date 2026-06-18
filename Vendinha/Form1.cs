namespace Vendinha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FormCadastrar tela = new FormCadastrar();

            tela.ShowDialog();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)

        {
            FormBuscar tela = new FormBuscar();

            tela.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            FormDividas tela = new FormDividas();

            tela.ShowDialog();
        }
    }
}