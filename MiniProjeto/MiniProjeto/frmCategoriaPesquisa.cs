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
    public partial class frmCategoriaPesquisa : Form
    {
        public frmCategoriaPesquisa()
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

        private void CarregarGridCategoria()
        {
            string sql = "select " +
                "id_Categoria as 'ID', " +
                "nome_Categoria as 'Nome', " +
                "status_Categoria as 'Status' " +
                "from categoria where " +
                "nome_Categoria like '%" + txtNomePesquisar.Text + "%'";

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            conn.Open();

            try
            {
                adapter.Fill(ds);
                gridCategoriaPesquisa.DataSource = ds.Tables[0];
                gridCategoriaPesquisa.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                gridCategoriaPesquisa.AutoResizeRow(0, DataGridViewAutoSizeRowMode.AllCellsExceptHeader);
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

        private void frmCategoriaPesquisa_Load(object sender, EventArgs e)
        {
            testeConexao();
            CarregarGridCategoria();
        }

        private void txtNomePesquisar_TextChanged(object sender, EventArgs e)
        {
            CarregarGridCategoria();
        }

        private void gridCategoriaPesquisa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _codigo = gridCategoriaPesquisa.CurrentRow.Cells["ID"].Value.ToString();
            this.Close();
        }
    }
}
