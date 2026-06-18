namespace Vendinha
{
    partial class FormBuscar
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            listaclientes = new DataGridView();

            botaobuscar = new Button();
            textobuscar = new TextBox();
            buttoneditar = new Button();
            buttonexcluir = new Button();

            btnAnterior = new Button();
            btnProximo = new Button();
            lblPagina = new Label();

            ((System.ComponentModel.ISupportInitialize)listaclientes).BeginInit();
            SuspendLayout();

           

            listaclientes.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            listaclientes.Location = new Point(21, 51);
            listaclientes.Margin = new Padding(3, 2, 3, 2);
            listaclientes.MultiSelect = false;
            listaclientes.Name = "listaclientes";
            listaclientes.RowHeadersVisible = false;
            listaclientes.RowHeadersWidth = 51;
            listaclientes.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            listaclientes.Size = new Size(650, 180);
            listaclientes.TabIndex = 0;

            

            botaobuscar.Location = new Point(21, 26);
            botaobuscar.Name = "botaobuscar";
            botaobuscar.Size = new Size(58, 23);
            botaobuscar.TabIndex = 1;
            botaobuscar.Text = "Buscar";
            botaobuscar.UseVisualStyleBackColor = true;
            botaobuscar.Click += btnBuscar_Click;


            textobuscar.Location = new Point(84, 26);
            textobuscar.Name = "textobuscar";
            textobuscar.Size = new Size(353, 23);
            textobuscar.TabIndex = 2;


            buttoneditar.Location = new Point(596, 240);
            buttoneditar.Name = "buttoneditar";
            buttoneditar.Size = new Size(75, 23);
            buttoneditar.TabIndex = 3;
            buttoneditar.Text = "Editar";
            buttoneditar.UseVisualStyleBackColor = true;
            buttoneditar.Click += btnEditar_Click;


            buttonexcluir.Location = new Point(515, 240);
            buttonexcluir.Name = "buttonexcluir";
            buttonexcluir.Size = new Size(75, 23);
            buttonexcluir.TabIndex = 4;
            buttonexcluir.Text = "Excluir";
            buttonexcluir.UseVisualStyleBackColor = true;
            buttonexcluir.Click += btnExcluir_Click;

            

            btnAnterior.Location = new Point(21, 240);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(90, 25);
            btnAnterior.TabIndex = 5;
            btnAnterior.Text = "Anterior";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;


            lblPagina.AutoSize = true;
            lblPagina.Location = new Point(130, 245);
            lblPagina.Name = "lblPagina";
            lblPagina.Size = new Size(54, 15);
            lblPagina.TabIndex = 6;
            lblPagina.Text = "Página 1";

            

            btnProximo.Location = new Point(220, 240);
            btnProximo.Name = "btnProximo";
            btnProximo.Size = new Size(90, 25);
            btnProximo.TabIndex = 7;
            btnProximo.Text = "Próximo";
            btnProximo.UseVisualStyleBackColor = true;
            btnProximo.Click += btnProximo_Click;

            

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);

            Controls.Add(btnProximo);
            Controls.Add(lblPagina);
            Controls.Add(btnAnterior);
            Controls.Add(buttonexcluir);
            Controls.Add(buttoneditar);
            Controls.Add(textobuscar);
            Controls.Add(botaobuscar);
            Controls.Add(listaclientes);

            Name = "FormBuscar";
            Text = "Buscar Clientes";
            Load += FormBuscar_Load;

            ((System.ComponentModel.ISupportInitialize)listaclientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView listaclientes;

        private Button botaobuscar;
        private TextBox textobuscar;
        private Button buttoneditar;
        private Button buttonexcluir;

        private Button btnAnterior;
        private Button btnProximo;
        private Label lblPagina;
    }
}