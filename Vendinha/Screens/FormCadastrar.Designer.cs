using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vendinha
{
    partial class FormCadastrar
    {
        /// <summary>
        /// Variável do Designer
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpa recursos
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        private void InitializeComponent()
        {
            linkLabel1 = new LinkLabel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textonome = new TextBox();
            textoemail = new TextBox();
            textocpf = new TextBox();
            dtNascimento = new DateTimePicker();
            button1 = new Button();
            SuspendLayout();
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(421, 129);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(0, 20);
            linkLabel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(219, 56);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 2;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(219, 120);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 3;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(219, 183);
            label3.Name = "label3";
            label3.Size = new Size(33, 20);
            label3.TabIndex = 4;
            label3.Text = "CPF";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(219, 248);
            label4.Name = "label4";
            label4.Size = new Size(145, 20);
            label4.TabIndex = 5;
            label4.Text = "Data de Nascimento";
            // 
            // textonome
            // 
            textonome.Location = new Point(219, 79);
            textonome.Name = "textonome";
            textonome.Size = new Size(322, 27);
            textonome.TabIndex = 6;
            // 
            // textoemail
            // 
            textoemail.Location = new Point(219, 143);
            textoemail.Name = "textoemail";
            textoemail.Size = new Size(322, 27);
            textoemail.TabIndex = 7;
            // 
            // textocpf
            // 
            textocpf.Location = new Point(219, 205);
            textocpf.Name = "textocpf";
            textocpf.Size = new Size(322, 27);
            textocpf.TabIndex = 8;
            // 
            // dtNascimento
            // 
            dtNascimento.Format = DateTimePickerFormat.Short;
            dtNascimento.Location = new Point(219, 283);
            dtNascimento.Name = "dtNascimento";
            dtNascimento.Size = new Size(322, 27);
            dtNascimento.TabIndex = 9;
            // 
            // button1
            // 
            button1.Location = new Point(295, 347);
            button1.Name = "button1";
            button1.Size = new Size(175, 31);
            button1.TabIndex = 10;
            button1.Text = "REALIZAR CADASTRO";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormCadastrar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(linkLabel1);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(textonome);
            Controls.Add(textoemail);
            Controls.Add(textocpf);
            Controls.Add(dtNascimento);
            Controls.Add(button1);
            Name = "FormCadastrar";
            Text = "Cadastro Cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel linkLabel1;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;

        private TextBox textonome;
        private TextBox textoemail;
        private TextBox textocpf;

        private DateTimePicker dtNascimento;

        private Button button1;
    }
}