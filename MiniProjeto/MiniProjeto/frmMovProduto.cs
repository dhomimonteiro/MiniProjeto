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
    public partial class frmMovProduto : Form
    {
        string stringConexao = frmLogin.stringConexao;

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

        private void carregarComboBoxUser()
        {
            string sql = "select id_Usuario, nome_Usuario from usuario";

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader leitura;
            DataTable dt = new DataTable();
            conn.Open();

            try
            {
                leitura = cmd.ExecuteReader();
                dt.Load(leitura);

                cboCodigoUsuario.DisplayMember = "id_Usuario";
                cboCodigoUsuario.DataSource = dt;

                cboNomeUsuario.DisplayMember = "nome_Usuario";
                cboNomeUsuario.DataSource = dt;
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

        private void carregarComboBoxProduto()
        {
            string sql = "select id_Produto, nome_Produto, qtde_Produto from produto";

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader leitura;
            DataTable dt = new DataTable();
            conn.Open();

            try
            {
                leitura = cmd.ExecuteReader();
                dt.Load(leitura);

                cboCodigoProduto.DisplayMember = "id_Produto";
                cboCodigoProduto.DataSource = dt;

                cboNomeProduto.DisplayMember = "nome_Produto";
                cboNomeProduto.DataSource = dt;

                cboQtdeEstoque.DisplayMember = "qtde_Produto";
                cboQtdeEstoque.DataSource = dt;

                //txtQtdeEstoque.Text = leitura[6].ToString();
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

        private void CarregarGridMovProduto()
        {
            string sql = "select " +
                "id_MovProduto as 'ID', " +
                "tipo_MovProduto as 'Movimento', " +
                "qtde_MovProduto as 'Quantidade', " +
                "status_MovProduto as 'Status' " +
                "from MovProduto where " +
                "tipo_MovProduto like '%" + txtNomePesquisar.Text + "%'";

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlDataAdapter adapter = new SqlDataAdapter(sql,conn);
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

        public frmMovProduto()
        {
            InitializeComponent();
        }

        private void frmMovProduto_Load(object sender, EventArgs e)
        {
            testeConexao();
            carregarComboBoxUser();
            carregarComboBoxProduto();
            CarregarGridMovProduto();
        }

        private void btoSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btoLimpar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            cboNomeProduto.SelectedIndex = -1;
            cboCodigoProduto.SelectedIndex = -1;
            cboNomeUsuario.SelectedIndex = -1;
            cboCodigoUsuario.SelectedIndex = -1;
            cboQtdeEstoque.SelectedIndex = -1;
            cboTipoMov.SelectedIndex = -1;
            txtQtde.Value = 0;
            txtData.Text = "";
            cboStatus.SelectedIndex = -1;
            txtObs.Text = "";
        }


        //////////////////////////////////
        // BOTÃO CADASTRAR COM PESQUISA //
        private void btoCadastrar_Click(object sender, EventArgs e)
        {
            if (cboNomeProduto.SelectedIndex == -1)
            {
                MessageBox.Show("Informe o nome do produto.");
                cboNomeProduto.Focus();
                return;
            }
            
            if (cboNomeUsuario.SelectedIndex == -1)
            {
                MessageBox.Show("Informe o nome do usuário.");
                cboNomeUsuario.Focus();
                return;
            }
            if (cboTipoMov.SelectedIndex == -1)
            {
                MessageBox.Show("Informe o tipo de movimentação.");
                cboTipoMov.Focus();
                return;
            }

            if (txtQtde.Value == 0)
            {
                MessageBox.Show("A quantidade deve ser maior que 0.");
                txtQtde.Focus();
                return;
            }else if (cboStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o status.");
                cboStatus.Focus();
                return;
            }

            string sql = "insert into MovProduto" +
                "(" +
                "id_Produto_MovProduto," + 
                "id_Usuario_MovProduto," +
                "tipo_MovProduto," +
                "qtde_MovProduto," + 
                "obs_MovProduto," + 
                "status_MovProduto" + 
                ")" +
                "values" + 
                "(" +
                cboCodigoProduto.Text + "," +
                cboCodigoUsuario.Text + "," +
                "'" + cboTipoMov.Text + "'," +
                txtQtde.Text + "," +
                "'" + txtObs.Text + "'," +
                "'" + cboStatus.Text + "')" +
                "select SCOPE_IDENTITY()";

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader leitura;
            conn.Open();

            try
            {
                leitura = cmd.ExecuteReader();
                if (leitura.Read())
                {
                    
                    MessageBox.Show("Dados cadastrados com sucesso. Código gerido: " + leitura[0].ToString());
                    txtCodigo.Text = leitura[0].ToString();
                    btoPesquisar.PerformClick();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
            finally
            {
                conn.Close();
            }

            string sql2 = "";
            if (cboTipoMov.SelectedIndex == 0)
            {
                sql2 = "update produto set qtde_produto = qtde_produto + " + txtQtde.Text + " where id_Produto = " + cboCodigoProduto.Text;
            }
            if (cboTipoMov.SelectedIndex == 1)
            {
                sql2 = "update produto set " +
                    "qtde_Produto = qtde_Produto - " + txtQtde.Text + " where id_Produto = " +
                    cboCodigoProduto.Text;
            }
            SqlConnection connRm = new SqlConnection(stringConexao);
            SqlCommand cmdRm = new SqlCommand(sql2, connRm);
            cmdRm.CommandType = CommandType.Text;
            connRm.Open();

            try
            {
                int i = cmdRm.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("Dados alterados com sucesso.");
                    btoLimpar.PerformClick();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connRm.Close();
            }
            
        }

        /////////////////////
        // BOTÃO PESQUISAR //
        private void btoPesquisar_Click(object sender, EventArgs e)
        {
            string sql = "select * from MovProduto where id_MovProduto = " + txtCodigo.Text;

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader leitura;
            conn.Open();

            try
            {
                leitura = cmd.ExecuteReader();
                if (leitura.Read())
                {
                    cboCodigoProduto.Text = leitura[1].ToString();
                    cboCodigoUsuario.Text = leitura[2].ToString();
                    cboTipoMov.SelectedItem = leitura[3].ToString();
                    txtQtde.Text = leitura[4].ToString();
                    txtData.Text = leitura[5].ToString();
                    txtObs.Text = leitura[6].ToString();
                    cboStatus.SelectedItem = leitura[7].ToString();
                }
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

        ///////////////////
        // BOTÃO ALTERAR //
        private void btoAlterar_Click(object sender, EventArgs e)
        {
            string sql = "update MovProduto set " +
                "id_Produto_MovProduto = '" + cboCodigoProduto.Text + "'," +
                "id_Usuario_MovProduto = '" + cboCodigoUsuario.Text + "'," +
                "qtde_MovProduto = '" + txtQtde.Text + "'," +
                "dataCadastro_MovProduto = '" + txtData.Text + "'," +
                "obs_MovProduto = '" + txtObs.Text + "'," +
                "status_MovProduto = '" + cboStatus.Text + "' " +
                "where id_MovProduto = " + txtCodigo.Text;

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("Dados alterados com sucesso.");
                    btoPesquisar.PerformClick();
                }
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

        ///////////////////
        // BOTÃO EXCLUIR //
        private void btoExcluir_Click(object sender, EventArgs e)
        {
            string sql = "delete from MovProduto where id_MovProduto = " + txtCodigo.Text;

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("Dados excluídos com sucesso.");
                    btoLimpar.PerformClick();
                }
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

        private void txtNomePesquisar_TextChanged(object sender, EventArgs e)
        {
            CarregarGridMovProduto();
        }

        private void gridMovProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = gridMovProduto.CurrentRow.Cells["ID"].Value.ToString();
            btoPesquisar.PerformClick();
        }
    }
}
