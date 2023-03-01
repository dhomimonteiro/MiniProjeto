namespace MiniProjeto
{
    partial class frmMovProdutoPesquisa
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
            this.gridMovProduto = new System.Windows.Forms.DataGridView();
            this.txtNomePesquisa = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMovProduto
            // 
            this.gridMovProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMovProduto.Location = new System.Drawing.Point(12, 41);
            this.gridMovProduto.Name = "gridMovProduto";
            this.gridMovProduto.RowTemplate.Height = 25;
            this.gridMovProduto.Size = new System.Drawing.Size(554, 265);
            this.gridMovProduto.TabIndex = 0;
            this.gridMovProduto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMovProduto_CellDoubleClick);
            // 
            // txtNomePesquisa
            // 
            this.txtNomePesquisa.Location = new System.Drawing.Point(12, 12);
            this.txtNomePesquisa.Name = "txtNomePesquisa";
            this.txtNomePesquisa.Size = new System.Drawing.Size(554, 23);
            this.txtNomePesquisa.TabIndex = 1;
            this.txtNomePesquisa.TextChanged += new System.EventHandler(this.txtNomePesquisa_TextChanged);
            // 
            // frmMovProdutoPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 318);
            this.Controls.Add(this.txtNomePesquisa);
            this.Controls.Add(this.gridMovProduto);
            this.Name = "frmMovProdutoPesquisa";
            this.Text = "frmMovProdutoPesquisa";
            this.Load += new System.EventHandler(this.frmMovProdutoPesquisa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridMovProduto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView gridMovProduto;
        private TextBox txtNomePesquisa;
    }
}