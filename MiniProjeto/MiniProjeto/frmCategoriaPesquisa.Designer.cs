namespace MiniProjeto
{
    partial class frmCategoriaPesquisa
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
            this.txtNomePesquisar = new System.Windows.Forms.TextBox();
            this.gridCategoriaPesquisa = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridCategoriaPesquisa)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNomePesquisar
            // 
            this.txtNomePesquisar.Location = new System.Drawing.Point(12, 12);
            this.txtNomePesquisar.Name = "txtNomePesquisar";
            this.txtNomePesquisar.Size = new System.Drawing.Size(559, 23);
            this.txtNomePesquisar.TabIndex = 0;
            this.txtNomePesquisar.TextChanged += new System.EventHandler(this.txtNomePesquisar_TextChanged);
            // 
            // gridCategoriaPesquisa
            // 
            this.gridCategoriaPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCategoriaPesquisa.Location = new System.Drawing.Point(12, 41);
            this.gridCategoriaPesquisa.Name = "gridCategoriaPesquisa";
            this.gridCategoriaPesquisa.RowTemplate.Height = 25;
            this.gridCategoriaPesquisa.Size = new System.Drawing.Size(559, 284);
            this.gridCategoriaPesquisa.TabIndex = 1;
            this.gridCategoriaPesquisa.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCategoriaPesquisa_CellDoubleClick);
            // 
            // frmCategoriaPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 342);
            this.Controls.Add(this.gridCategoriaPesquisa);
            this.Controls.Add(this.txtNomePesquisar);
            this.Name = "frmCategoriaPesquisa";
            this.Text = "frmCategoriaPesquisa";
            this.Load += new System.EventHandler(this.frmCategoriaPesquisa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCategoriaPesquisa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtNomePesquisar;
        private DataGridView gridCategoriaPesquisa;
    }
}