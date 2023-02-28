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
    public partial class frmUsuarioPesquisa : Form
    {

        public frmUsuarioPesquisa()
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

        private void CarregarGridUsuario()
        {
            string sql = "select " +
                "id_Usuario as 'ID', " +
                "nome_Usuario as 'Nome', " +
                "login_Usuario as 'Login', " +
                "status_Usuario as 'Status' " +
                "from usuario where " +
                "nome_Usuario like '%" + txtNomePesquisar.Text + "%'";

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            conn.Open();

            try
            {
                adapter.Fill(ds);
                gridUsuarioPesquisar.DataSource = ds.Tables[0];
                gridUsuarioPesquisar.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                gridUsuarioPesquisar.AutoResizeRow(0, DataGridViewAutoSizeRowMode.AllCellsExceptHeader);
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

        private void frmUsuarioPesquisa_Load(object sender, EventArgs e)
        {
            testeConexao();
            CarregarGridUsuario();
        }

        private void gridUsuarioPesquisar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _codigo = gridUsuarioPesquisar.CurrentRow.Cells["ID"].Value.ToString();
            this.Close();
        }

        private void txtNomePesquisar_TextChanged(object sender, EventArgs e)
        {
            CarregarGridUsuario();
        }
    }
}
