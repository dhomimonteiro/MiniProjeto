namespace MiniProjeto
{
    partial class frmProdutoPesquisa
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
            this.txtNomePesquisa = new System.Windows.Forms.TextBox();
            this.gridProdutoPesquisa = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutoPesquisa)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNomePesquisa
            // 
            this.txtNomePesquisa.Location = new System.Drawing.Point(12, 12);
            this.txtNomePesquisa.Name = "txtNomePesquisa";
            this.txtNomePesquisa.Size = new System.Drawing.Size(428, 23);
            this.txtNomePesquisa.TabIndex = 0;
            this.txtNomePesquisa.TextChanged += new System.EventHandler(this.txtNomePesquisa_TextChanged);
            // 
            // gridProdutoPesquisa
            // 
            this.gridProdutoPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProdutoPesquisa.Location = new System.Drawing.Point(12, 51);
            this.gridProdutoPesquisa.Name = "gridProdutoPesquisa";
            this.gridProdutoPesquisa.RowTemplate.Height = 25;
            this.gridProdutoPesquisa.Size = new System.Drawing.Size(428, 236);
            this.gridProdutoPesquisa.TabIndex = 1;
            this.gridProdutoPesquisa.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProdutoPesquisa_CellDoubleClick);
            // 
            // frmProdutoPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 306);
            this.Controls.Add(this.gridProdutoPesquisa);
            this.Controls.Add(this.txtNomePesquisa);
            this.Name = "frmProdutoPesquisa";
            this.Text = "frmProdutoPesquisa";
            this.Load += new System.EventHandler(this.frmProdutoPesquisa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutoPesquisa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtNomePesquisa;
        private DataGridView gridProdutoPesquisa;
    }
}