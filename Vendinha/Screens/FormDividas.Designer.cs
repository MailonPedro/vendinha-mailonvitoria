namespace Vendinha
{
    partial class FormDividas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonbuscarcliente = new Button();
            textobuscarcliente = new TextBox();
            textovalor = new TextBox();
            Valor = new Button();
            label1 = new Label();
            listadividas = new DataGridView();
            buttonpagamento = new Button();
            ((System.ComponentModel.ISupportInitialize)listadividas).BeginInit();
            SuspendLayout();
            // 
            // buttonbuscarcliente
            // 
            buttonbuscarcliente.Location = new Point(12, 12);
            buttonbuscarcliente.Name = "buttonbuscarcliente";
            buttonbuscarcliente.Size = new Size(116, 23);
            buttonbuscarcliente.TabIndex = 0;
            buttonbuscarcliente.Text = "Selecionar cliente";
            buttonbuscarcliente.UseVisualStyleBackColor = true;
            buttonbuscarcliente.Click += buttonbuscarcliente_Click;
            // 
            // textobuscarcliente
            // 
            textobuscarcliente.Location = new Point(134, 12);
            textobuscarcliente.Name = "textobuscarcliente";
            textobuscarcliente.Size = new Size(285, 23);
            textobuscarcliente.TabIndex = 1;
            // 
            // textovalor
            // 
            textovalor.Location = new Point(134, 41);
            textovalor.Name = "textovalor";
            textovalor.Size = new Size(175, 23);
            textovalor.TabIndex = 3;
            // 
            // Valor
            // 
            Valor.Location = new Point(315, 41);
            Valor.Name = "Valor";
            Valor.Size = new Size(103, 23);
            Valor.TabIndex = 4;
            Valor.Text = "Registrar dívida";
            Valor.UseVisualStyleBackColor = true;
            Valor.Click += Valor_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 45);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 5;
            label1.Text = "Valor da dívida:";
            // 
            // listadividas
            // 
            listadividas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            listadividas.Location = new Point(24, 91);
            listadividas.Name = "listadividas";
            listadividas.RowHeadersWidth = 51;
            listadividas.Size = new Size(594, 180);
            listadividas.TabIndex = 6;
            // 
            // buttonpagamento
            // 
            buttonpagamento.Location = new Point(490, 277);
            buttonpagamento.Name = "buttonpagamento";
            buttonpagamento.Size = new Size(128, 23);
            buttonpagamento.TabIndex = 7;
            buttonpagamento.Text = "Marcar como paga";
            buttonpagamento.UseVisualStyleBackColor = true;
            buttonpagamento.Click += buttonpagamento_Click;
            // 
            // FormDividas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonpagamento);
            Controls.Add(listadividas);
            Controls.Add(label1);
            Controls.Add(Valor);
            Controls.Add(textovalor);
            Controls.Add(textobuscarcliente);
            Controls.Add(buttonbuscarcliente);
            Name = "FormDividas";
            Text = "FormDividas";
            ((System.ComponentModel.ISupportInitialize)listadividas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonbuscarcliente;
        private TextBox textobuscarcliente;
        private Button buttonregistro;
        private TextBox textovalor;
        private Button Valor;
        private Label label1;
        private DataGridView listadividas;
        private Button buttonpagamento;
        private ComboBox combostatus;
    }
}