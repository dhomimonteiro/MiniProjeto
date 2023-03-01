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
                "MovProduto.id_MovProduto as 'ID', " +
                "MovProduto.tipo_MovProduto as 'Movimento', " +
                "Usuario.nome_Usuario as 'Usuário', " +
                "Produto.nome_Produto as 'Produto', " +
                "MovProduto.qtde_MovProduto as 'Quantidade', " +
                "MovProduto.status_MovProduto as 'Status' " +
                "from MovProduto " +
                "inner join produto on MovProduto.id_Produto_MovProduto = produto.id_Produto " +
                "inner join usuario on MovProduto.id_Usuario_MovProduto = usuario.id_Usuario " +
                "where produto.nome_produto = '" + cboNomeProduto.Text + "' order by id_MovProduto desc";

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
            }

            cboStatus.SelectedIndex = 0;

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
                    btoPesquisar.PerformClick();

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
            CarregarGridMovProduto();
            carregarComboBoxProduto();

        }

        /////////////////////
        // BOTÃO PESQUISAR //
        private void btoPesquisar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "")
            {
                frmMovProdutoPesquisa frm = new frmMovProdutoPesquisa();
                frm.ShowDialog();
                txtCodigo.Text = frm._codigo;
            }

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
        // BOTÃO CANCELAR //
        private void btoCancelar_Click(object sender, EventArgs e)
        {
            btoPesquisar.PerformClick();
            cboStatus.SelectedIndex = 1;
            

            //Alteração na tabela de produto 
            string sql = "";
            if (cboTipoMov.SelectedIndex == 0)
            {
                sql = "update produto set qtde_produto = qtde_produto - " + txtQtde.Text + " where id_Produto = " + 
                    cboCodigoProduto.Text + "; " +
                    "update MovProduto set status_MovProduto = '" + cboStatus.Text + "' where id_MovProduto = " +
                    txtCodigo.Text;
            }
            if (cboTipoMov.SelectedIndex == 1)
            {
                sql = "update produto set " +
                    "qtde_Produto = qtde_Produto + " + txtQtde.Text + " where id_Produto = " +
                    cboCodigoProduto.Text + "; " +
                    "update MovProduto set status_MovProduto = '" + cboStatus.Text + "' where id_MovProduto = " +
                    txtCodigo.Text;
            }

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i == 2)
                {
                    MessageBox.Show("Movimentação cancelada com sucesso.");
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
            CarregarGridMovProduto();
            carregarComboBoxProduto();
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

        // PREENCHER O CAMPO NOME DO USUÁRIO COM BASE NO CÓDIGO DIGITADO
        private void btoPesquisarUsuario_Enter(object sender, EventArgs e)
        {
            if (cboCodigoUsuario.Text.Trim() != "")
            {
                string sql = "select * from usuario where id_Usuario = " + cboCodigoUsuario.Text;

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
                        cboNomeUsuario.Text = leitura[1].ToString();
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
            
        }

        //Abrir o DataGrid do Usuário para pesquisa
        private void btoPesquisarUsuario_Click(object sender, EventArgs e)
        {
            frmUsuarioPesquisa frm = new frmUsuarioPesquisa();
            frm.ShowDialog();
            cboCodigoUsuario.Text = frm._codigo;
        }

        private void btoPesquisarProduto_Click(object sender, EventArgs e)
        {
            frmProdutoPesquisa frm = new frmProdutoPesquisa();
            frm.ShowDialog();
            cboCodigoProduto.Text = frm._codigo;
        }

        private void btoPesquisarProduto_Enter(object sender, EventArgs e)
        {
            if (cboCodigoProduto.Text.Trim() != "")
            {
                string sql = "select * from produto where id_Produto = " + cboCodigoProduto.Text;

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
                        cboNomeProduto.Text = leitura[1].ToString();
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
        }

        private void cboNomeProduto_Leave(object sender, EventArgs e)
        {
           
        }

        private void cboNomeProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNomeProduto.Text.Trim() != "")
            {
                CarregarGridMovProduto();
            }
        }
    }
}
