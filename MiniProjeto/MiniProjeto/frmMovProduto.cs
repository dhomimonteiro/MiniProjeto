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
        string stringConexao = "Data Source = localhost;Initial Catalog = MiniProjeto_T13; User ID = sa; Password = 123456";

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

        public frmMovProduto()
        {
            InitializeComponent();
        }

        private void frmMovProduto_Load(object sender, EventArgs e)
        {
            testeConexao();
        }

        private void btoSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btoLimpar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtCodigoProduto.Text = "";
            txtCodigoUsuario.Text = "";
            txtQtde.Value = 0;
            txtData.Text = "";
            cboStatus.SelectedIndex = -1;
            txtObs.Text = "";
        }


        //////////////////////////////////
        // BOTÃO CADASTRAR COM PESQUISA //
        private void btoCadastrar_Click(object sender, EventArgs e)
        {
            if (txtCodigoProduto.Text.Trim() == "")
            {
                MessageBox.Show("Informe o código do produto.");
                txtCodigoProduto.Focus();
                return;
            }
            else
            {
                float i;
                if (!float.TryParse(txtCodigoProduto.Text, out i))
                {
                    MessageBox.Show("Erro. O código do produto deve ser numérico");
                    txtCodigoProduto.Text = "";
                    txtCodigoProduto.Focus();
                    return;
                }
            }
            if (txtCodigoUsuario.Text.Trim() == "")
            {
                MessageBox.Show("Informe o código do usuário.");
                txtCodigoUsuario.Focus();
                return;
            }
            else
            {
                float i;
                if (!float.TryParse(txtCodigoUsuario.Text, out i))
                {
                    MessageBox.Show("Erro. O código do usuário deve ser numérico");
                    txtCodigoUsuario.Text = "";
                    txtCodigoUsuario.Focus();
                    return;
                }
            }

            if (txtQtde.Value == 0)
            {
                MessageBox.Show("A quantidade deve ser maior que 0.");
                txtQtde.Focus();
                return;
            }else if (txtData.Text == "  /  /")
            {
                MessageBox.Show("Insira a data.");
                txtData.Focus();
                return;
            }else if (cboStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o status.");
                cboStatus.Focus();
                return;
            }


            string sql = "set dateformat dmy " +
                "insert into MovProduto" +
                "(" +
                "id_Produto_MovProduto," + "id_Usuario_MovProduto," + "qtde_MovProduto," + "dataCadastro_MovProduto," +
                "obs_MovProduto," + "status_MovProduto" + ")" +
                "values" + "(" +
                txtCodigoProduto.Text + "," +
                txtCodigoUsuario.Text + "," +
                txtQtde.Text + "," +
                "'" + txtData.Text + "'," +
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
                    btoLimpar.PerformClick();
                    MessageBox.Show("Dados cadastrados com sucesso. Código gerido: " + leitura[0].ToString());
                    txtCodigo.Text = leitura[0].ToString();
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
                    txtCodigoProduto.Text = leitura[1].ToString();
                    txtCodigoUsuario.Text = leitura[2].ToString();
                    txtQtde.Text = leitura[3].ToString();
                    txtData.Text = leitura[4].ToString();
                    txtObs.Text = leitura[5].ToString();
                    cboStatus.SelectedItem = leitura[6].ToString();
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
                "id_Produto_MovProduto = '" + txtCodigoProduto.Text + "'," +
                "id_Usuario_MovProduto = '" + txtCodigoUsuario.Text + "'," +
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
    }
}
