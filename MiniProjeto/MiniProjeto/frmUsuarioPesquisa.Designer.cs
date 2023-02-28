namespace MiniProjeto
{
    partial class frmUsuarioPesquisa
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
            this.gridUsuarioPesquisar = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsuarioPesquisar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNomePesquisar
            // 
            this.txtNomePesquisar.Location = new System.Drawing.Point(12, 12);
            this.txtNomePesquisar.Name = "txtNomePesquisar";
            this.txtNomePesquisar.Size = new System.Drawing.Size(485, 23);
            this.txtNomePesquisar.TabIndex = 0;
            this.txtNomePesquisar.TextChanged += new System.EventHandler(this.txtNomePesquisar_TextChanged);
            // 
            // gridUsuarioPesquisar
            // 
            this.gridUsuarioPesquisar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUsuarioPesquisar.Location = new System.Drawing.Point(12, 41);
            this.gridUsuarioPesquisar.Name = "gridUsuarioPesquisar";
            this.gridUsuarioPesquisar.RowTemplate.Height = 25;
            this.gridUsuarioPesquisar.Size = new System.Drawing.Size(485, 264);
            this.gridUsuarioPesquisar.TabIndex = 1;
            this.gridUsuarioPesquisar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUsuarioPesquisar_CellDoubleClick);
            // 
            // frmUsuarioPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 320);
            this.Controls.Add(this.gridUsuarioPesquisar);
            this.Controls.Add(this.txtNomePesquisar);
            this.Name = "frmUsuarioPesquisa";
            this.Text = "frmUsuarioPesquisa";
            this.Load += new System.EventHandler(this.frmUsuarioPesquisa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridUsuarioPesquisar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtNomePesquisar;
        private DataGridView gridUsuarioPesquisar;
    }
}