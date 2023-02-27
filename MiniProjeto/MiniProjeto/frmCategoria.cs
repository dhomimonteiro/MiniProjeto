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
    public partial class frmCategoria : Form
    {

        //Criar conexão
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

        public frmCategoria()
        {
            InitializeComponent();
        }

        private void btoSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btoLimpar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "0";
            txtNome.Text = "";
            cboStatus.SelectedIndex = -1;
            txtDescricao.Text = "";
            txtObs.Text = "";
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            testeConexao();
        }

        //////////////////////////////////
        // BOTÃO CADASTRAR COM PESQUISA //
        private void btoCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() == "")
            {
                MessageBox.Show("Preencha o nome.");
                txtNome.Focus();
                return;
            }
            else if (cboStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Informe o status.");
                cboStatus.Focus();
                return;
            }

            string sql = "insert into categoria (" +
                "nome_Categoria," + "descricao_Categoria," + "obs_Categoria," + "status_Categoria)" +
                "values (" +
                "'" + txtNome.Text + "'," +
                "'" + txtDescricao.Text + "'," +
                "'" + txtObs.Text + "'," +
                "'" + cboStatus.Text +"')"+
                "select SCOPE_IDENTITY()"
                ;

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
                    MessageBox.Show("Dados cadastrados com sucesso. Código gerado: " + leitura[0].ToString());
                    btoLimpar.PerformClick();
                    txtCodigo.Text = leitura[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());  
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
            string sql = "select * from categoria where id_Categoria = " + txtCodigo.Text;

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
                    txtDescricao.Text = leitura[2].ToString();
                    txtObs.Text = leitura[3].ToString();
                    cboStatus.SelectedItem = leitura[4].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Selecione o Id do Usuário.");
                txtCodigo.Focus();
                return;
            }
            else if (txtNome.Text.Trim() == "")
            {
                MessageBox.Show("Preencha o nome.");
                txtNome.Focus();
                return;
            }
            else if (cboStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Informe o status.");
                cboStatus.Focus();
                return;
            }

            string sql = "update categoria set " +
                "nome_Categoria = '" + txtNome.Text + "'," +
                "descricao_Categoria = '" + txtDescricao.Text + "'," +
                "obs_Categoria = '" + txtObs.Text + "'," +
                "status_Categoria = '" + cboStatus.Text + "' " +
                "where id_Categoria = " + txtCodigo.Text;

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
            string sql = "delete from categoria where id_Categoria = " + txtCodigo.Text;

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
