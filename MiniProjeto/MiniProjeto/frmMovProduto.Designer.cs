namespace MiniProjeto
{
    partial class frmMovProduto
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btoPesquisar = new System.Windows.Forms.Button();
            this.txtCodigoUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodigoProduto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtData = new System.Windows.Forms.MaskedTextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtQtde = new System.Windows.Forms.NumericUpDown();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btoCadastrar = new System.Windows.Forms.Button();
            this.btoAlterar = new System.Windows.Forms.Button();
            this.btoLimpar = new System.Windows.Forms.Button();
            this.btoSair = new System.Windows.Forms.Button();
            this.btoExcluir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtde)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btoPesquisar);
            this.groupBox1.Controls.Add(this.txtCodigoUsuario);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCodigoProduto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btoPesquisar
            // 
            this.btoPesquisar.Location = new System.Drawing.Point(6, 68);
            this.btoPesquisar.Name = "btoPesquisar";
            this.btoPesquisar.Size = new System.Drawing.Size(126, 23);
            this.btoPesquisar.TabIndex = 1;
            this.btoPesquisar.Text = "&Pesquisar";
            this.btoPesquisar.UseVisualStyleBackColor = true;
            this.btoPesquisar.Click += new System.EventHandler(this.btoPesquisar_Click);
            // 
            // txtCodigoUsuario
            // 
            this.txtCodigoUsuario.Location = new System.Drawing.Point(172, 86);
            this.txtCodigoUsuario.Name = "txtCodigoUsuario";
            this.txtCodigoUsuario.Size = new System.Drawing.Size(127, 23);
            this.txtCodigoUsuario.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Código do Usuário";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(6, 37);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(127, 23);
            this.txtCodigo.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Código";
            // 
            // txtCodigoProduto
            // 
            this.txtCodigoProduto.Location = new System.Drawing.Point(172, 37);
            this.txtCodigoProduto.Name = "txtCodigoProduto";
            this.txtCodigoProduto.Size = new System.Drawing.Size(127, 23);
            this.txtCodigoProduto.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Código do Produto";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtData);
            this.groupBox2.Controls.Add(this.cboStatus);
            this.groupBox2.Controls.Add(this.txtQtde);
            this.groupBox2.Controls.Add(this.txtObs);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 156);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(127, 33);
            this.txtData.Mask = "##/##/####";
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(96, 23);
            this.txtData.TabIndex = 1;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Ativo",
            "Inativo"});
            this.cboStatus.Location = new System.Drawing.Point(229, 33);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(94, 23);
            this.cboStatus.TabIndex = 2;
            // 
            // txtQtde
            // 
            this.txtQtde.Location = new System.Drawing.Point(6, 33);
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.Size = new System.Drawing.Size(115, 23);
            this.txtQtde.TabIndex = 0;
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(6, 77);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(317, 79);
            this.txtObs.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Observação";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(127, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Data de cadastro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Qtde movimentação";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btoCadastrar);
            this.groupBox3.Controls.Add(this.btoAlterar);
            this.groupBox3.Controls.Add(this.btoLimpar);
            this.groupBox3.Controls.Add(this.btoSair);
            this.groupBox3.Controls.Add(this.btoExcluir);
            this.groupBox3.Location = new System.Drawing.Point(12, 311);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(329, 108);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // btoCadastrar
            // 
            this.btoCadastrar.Location = new System.Drawing.Point(26, 22);
            this.btoCadastrar.Name = "btoCadastrar";
            this.btoCadastrar.Size = new System.Drawing.Size(95, 36);
            this.btoCadastrar.TabIndex = 0;
            this.btoCadastrar.Text = "Cadastrar";
            this.btoCadastrar.UseVisualStyleBackColor = true;
            this.btoCadastrar.Click += new System.EventHandler(this.btoCadastrar_Click);
            // 
            // btoAlterar
            // 
            this.btoAlterar.Location = new System.Drawing.Point(127, 22);
            this.btoAlterar.Name = "btoAlterar";
            this.btoAlterar.Size = new System.Drawing.Size(95, 36);
            this.btoAlterar.TabIndex = 1;
            this.btoAlterar.Text = "&Alterar";
            this.btoAlterar.UseVisualStyleBackColor = true;
            this.btoAlterar.Click += new System.EventHandler(this.btoAlterar_Click);
            // 
            // btoLimpar
            // 
            this.btoLimpar.Location = new System.Drawing.Point(183, 64);
            this.btoLimpar.Name = "btoLimpar";
            this.btoLimpar.Size = new System.Drawing.Size(67, 30);
            this.btoLimpar.TabIndex = 3;
            this.btoLimpar.Text = "&Limpar";
            this.btoLimpar.UseVisualStyleBackColor = true;
            this.btoLimpar.Click += new System.EventHandler(this.btoLimpar_Click);
            // 
            // btoSair
            // 
            this.btoSair.Location = new System.Drawing.Point(256, 64);
            this.btoSair.Name = "btoSair";
            this.btoSair.Size = new System.Drawing.Size(67, 30);
            this.btoSair.TabIndex = 4;
            this.btoSair.Text = "Sair";
            this.btoSair.UseVisualStyleBackColor = true;
            this.btoSair.Click += new System.EventHandler(this.btoSair_Click);
            // 
            // btoExcluir
            // 
            this.btoExcluir.Location = new System.Drawing.Point(228, 22);
            this.btoExcluir.Name = "btoExcluir";
            this.btoExcluir.Size = new System.Drawing.Size(95, 36);
            this.btoExcluir.TabIndex = 2;
            this.btoExcluir.Text = "&Excluir";
            this.btoExcluir.UseVisualStyleBackColor = true;
            this.btoExcluir.Click += new System.EventHandler(this.btoExcluir_Click);
            // 
            // frmMovProduto
            // 
            this.AcceptButton = this.btoCadastrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btoSair;
            this.ClientSize = new System.Drawing.Size(356, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMovProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Movimentação de Produto";
            this.Load += new System.EventHandler(this.frmMovProduto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtde)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Button btoPesquisar;
        private TextBox txtCodigoUsuario;
        private Label label3;
        private TextBox txtCodigoProduto;
        private Label label2;
        private GroupBox groupBox2;
        private MaskedTextBox txtData;
        private ComboBox cboStatus;
        private NumericUpDown txtQtde;
        private Label label5;
        private Label label4;
        private Label label1;
        private GroupBox groupBox3;
        private TextBox txtCodigo;
        private Label label7;
        private TextBox txtObs;
        private Label label6;
        private Button btoCadastrar;
        private Button btoAlterar;
        private Button btoLimpar;
        private Button btoSair;
        private Button btoExcluir;
    }
}