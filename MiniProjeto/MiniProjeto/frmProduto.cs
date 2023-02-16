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
    public partial class frmProduto : Form
    {

        string stringConexao = "Data Source=localhost; Initial Catalog=MiniProjeto_T13;User ID= sa; Password=123456";

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

        public frmProduto()
        {
            InitializeComponent();
        }

        private void btoSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmProduto_Load(object sender, EventArgs e)
        {
            testeConexao();
        }

        private void btoLimpar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtCodigoCategoria.Text = "";
            txtNome.Text = "";
            txtQuantidade.Value = 0;
            txtValorCusto.Text = "";
            txtValorVenda.Text = "";
            txtData.Text = "";
            cboStatus.SelectedIndex = -1;
            txtDescricao.Text = "";
            txtObs.Text = "";
        }

        //////////////////////////////////
        // BOTÃO CADASTRAR COM PESQUISA //
        private void btoCadastrar_Click(object sender, EventArgs e)
        {
            if (txtCodigoCategoria.Text.Trim() == "")
            {
                MessageBox.Show("Informe o código da categoria.");
                txtCodigoCategoria.Focus();
                return;
            }else if (txtNome.Text.Trim() == "")
            {
                MessageBox.Show("Preencha o nome.");
                txtNome.Focus();
                return;
            }

            if (txtQuantidade.Value == 0)
            {
                MessageBox.Show("A quantidade deve ser maior que 0.");
                txtQuantidade.Focus();
                return;
            }
            
            if (txtValorCusto.Text.Trim() == "")
            {
                MessageBox.Show("Preencha o valor de custo");
                txtValorCusto.Focus();
                return;
            }
            else
            {
                float i;
                if (!float.TryParse(txtValorCusto.Text, out i))
                {
                    MessageBox.Show("Erro. O valor de custo deve ser numérico");
                    txtValorCusto.Text = "";
                    txtValorCusto.Focus();
                    return;
                }
            }

            if (txtValorVenda.Text.Trim() == "")
            {
                MessageBox.Show("Preencha o valor de custo");
                txtValorVenda.Focus();
                return;
            }
            else
            {
                float i;
                if (!float.TryParse(txtValorVenda.Text, out i))
                {
                    MessageBox.Show("Erro. O valor de custo deve ser numérico");
                    txtValorVenda.Text = "";
                    txtValorVenda.Focus();
                    return;
                }
            }

            if (cboStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o status.");
                cboStatus.Focus();
                return;
            }


            string sql = "insert into produto " + 
            "(nome_Produto, id_Categoria_Produto, valorcusto_Produto, valorvenda_Produto, descricao_Produto, qtde_Produto, obs_Produto, status_Produto)" +
            "values" +
            " ('" + txtNome.Text + "','" + txtCodigoCategoria.Text + "','" + txtValorCusto.Text + "','" + txtValorVenda.Text + "','" + txtDescricao.Text + "','" + txtQuantidade.Text + "','" + txtObs.Text + "','" + cboStatus.Text + "')" 
            + "select SCOPE_IDENTITY()";

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
                    MessageBox.Show("Dados cadastrados com sucesso.");
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
            string sql = "select * from produto where id_Produto = " + txtCodigo.Text;

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
                    txtNome.Text = leitura[1].ToString();
                    txtCodigoCategoria.Text = leitura[2].ToString();
                    txtValorCusto.Text = leitura[3].ToString();
                    txtValorVenda.Text = leitura[4].ToString();
                    txtDescricao.Text = leitura[5].ToString();
                    txtQuantidade.Text = leitura[6].ToString();
                    txtData.Text = leitura[7].ToString();
                    txtObs.Text = leitura[8].ToString();
                    cboStatus.SelectedItem = leitura[9].ToString();
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
            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Informe o código do produto.");
                txtCodigo.Focus();
                return;
            }
            
            if (txtCodigoCategoria.Text.Trim() == "")
            {
                MessageBox.Show("Informe o código da categoria.");
                txtCodigoCategoria.Focus();
                return;
            }
            else if (txtNome.Text.Trim() == "")
            {
                MessageBox.Show("Preencha o nome.");
                txtNome.Focus();
                return;
            }

            if (txtQuantidade.Value == 0)
            {
                MessageBox.Show("A quantidade deve ser maior que 0.");
                txtQuantidade.Focus();
                return;
            }

            if (txtValorCusto.Text.Trim() == "")
            {
                MessageBox.Show("Preencha o valor de custo");
                txtValorCusto.Focus();
                return;
            }
            else
            {
                float i;
                if (!float.TryParse(txtValorCusto.Text, out i))
                {
                    MessageBox.Show("Erro. O valor de custo deve ser numérico");
                    txtValorCusto.Text = "";
                    txtValorCusto.Focus();
                    return;
                }
            }

            if (txtValorVenda.Text.Trim() == "")
            {
                MessageBox.Show("Preencha o valor de custo");
                txtValorVenda.Focus();
                return;
            }
            else
            {
                float i;
                if (!float.TryParse(txtValorVenda.Text, out i))
                {
                    MessageBox.Show("Erro. O valor de custo deve ser numérico.");
                    txtValorVenda.Text = "";
                    txtValorVenda.Focus();
                    return;
                }
            }

            if (cboStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o status.");
                cboStatus.Focus();
                return;
            }

            string sql = "set dateformat dmy update produto set " +
                "id_Categoria_Produto = " + txtCodigoCategoria.Text + "," +
                "nome_Produto = '" + txtNome.Text + "'," +
                // .Replace(oldchar, newchar) > altera um caracter.
                "valorcusto_Produto = " + txtValorCusto.Text.Replace(",",".") + "," +
                "valorvenda_Produto = " + txtValorVenda.Text.Replace(",", ".") + "," +
                "descricao_Produto = '" + txtDescricao.Text + "'," +
                "qtde_Produto = " + txtQuantidade.Value + "," +
                "dataCadastro_Produto = '" + txtData.Text + "'," +
                "obs_Produto = '" + txtObs.Text + "'," +
                "status_Produto = '" + cboStatus.Text + "' " +
                "where id_Produto = " + txtCodigo.Text;
                

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("Dados foram alterados com sucesso.");
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
            string sql = "delete from produto where id_Produto = " + txtCodigo.Text;

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
