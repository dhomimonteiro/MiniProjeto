using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProjeto
{
    public partial class frmProdutoPesquisa : Form
    {
        public frmProdutoPesquisa()
        {
            InitializeComponent();
        }

        string stringConexao = frmLogin.stringConexao;
        public string _codigo;

        private void testeConexao()
        {
            SqlConnection conn = new SqlConnection(stringConexao);

            try
            {
                conn.Open();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private void CarregarGridProduto()
        {
            string sql = "select " +
                "id_Produto as 'ID', " +
                "nome_Produto as 'Nome', " +
                "valorvenda_Produto as 'Valor de Venda', " +
                "qtde_Produto as 'Estoque', " +
                "datacadastro_Produto as 'Data', " +
                "status_Produto as 'Status' " +
                "from produto where " +
                "nome_Produto like '%" + txtNomePesquisa.Text + "%'";

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            conn.Open();

            try
            {
                adapter.Fill(ds);
                gridProdutoPesquisa.DataSource = ds.Tables[0];
                gridProdutoPesquisa.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                gridProdutoPesquisa.AutoResizeRow(0, DataGridViewAutoSizeRowMode.AllCellsExceptHeader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void frmProdutoPesquisa_Load(object sender, EventArgs e)
        {
            testeConexao();
            CarregarGridProduto();
        }

        private void txtNomePesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarGridProduto();
        }

        private void gridProdutoPesquisa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _codigo = gridProdutoPesquisa.CurrentRow.Cells["ID"].Value.ToString();
            this.Close();
        }
    }
}
