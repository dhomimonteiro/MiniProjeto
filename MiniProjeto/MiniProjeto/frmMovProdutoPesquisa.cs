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
    public partial class frmMovProdutoPesquisa : Form
    {
        public frmMovProdutoPesquisa()
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

        private void CarregarGridMovProduto()
        {
            string sql = "select " +
                "MovProduto.id_MovProduto as 'ID', " +
                "MovProduto.tipo_MovProduto as 'Movimento', " +
                "Usuario.nome_Usuario as 'Usuário', " +
                "Produto.nome_Produto as 'Produto', " +
                "MovProduto.qtde_MovProduto as 'Quantidade', " +
                "MovProduto.status_MovProduto as 'Status' " +
                "from MovProduto " +
                "inner join produto on MovProduto.id_Produto_MovProduto = produto.id_Produto " +
                "inner join usuario on MovProduto.id_Usuario_MovProduto = usuario.id_Usuario " +
                "order by id_MovProduto desc";

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            conn.Open();

            try
            {
                adapter.Fill(ds);
                gridMovProduto.DataSource = ds.Tables[0];
                gridMovProduto.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                gridMovProduto.AutoResizeRow(0, DataGridViewAutoSizeRowMode.AllCellsExceptHeader);
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

        private void frmMovProdutoPesquisa_Load(object sender, EventArgs e)
        {
            testeConexao();
            CarregarGridMovProduto();
        }

        private void txtNomePesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarGridMovProduto();
        }

        private void gridMovProduto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _codigo = gridMovProduto.CurrentRow.Cells["ID"].Value.ToString();
            this.Close();
        }
    }
}
