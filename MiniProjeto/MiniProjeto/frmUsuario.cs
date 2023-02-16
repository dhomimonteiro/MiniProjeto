using System.Data;
using System.Data.SqlClient;

namespace MiniProjeto
{
    public partial class frmUsuario : Form
    {
        // Cria uma conexão para o banco de dados
        string stringConexao = "Data Source=localhost; Initial Catalog=MiniProjeto_T13;User ID= sa; Password=123456";

        // Teste de erro com o banco de dados
        private void TesteConexao()
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

        public frmUsuario()
        {
            InitializeComponent();
        }

        private void btoSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btoLimpar_Click(object sender, EventArgs e)
        {

            txtId.Value = 0;
            txtNome.Text = "";
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtConfirmarSenha.Text = "";
            cboStatus.SelectedIndex = -1;
            txtObs.Text = "";
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            TesteConexao();
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
            }else if (txtLogin.Text.Trim() == "")
            {
                MessageBox.Show("Preencha o login.");
                txtLogin.Focus();
                return;
            }else if (txtSenha.Text.Trim() == "")
            {
                MessageBox.Show("Preencha a senha.");
                txtSenha.Focus();
                return;
            }else if (txtConfirmarSenha.Text.Trim() == "")
            {
                MessageBox.Show("Confirme a senha.");
                txtConfirmarSenha.Focus();
                return;
            }else if (cboStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Informe o status.");
                cboStatus.Focus();
                return;
            }

            if (txtConfirmarSenha.Text != txtSenha.Text)
            {
                MessageBox.Show("As senhas não são iguais.");
                txtConfirmarSenha.Text = "";
                txtConfirmarSenha.Focus();
                return;
            }
            

            string sql = "insert into usuario" +
                "(" +
                "nome_Usuario," + "login_Usuario," + "senha_Usuario," + "obs_Usuario," + "status_Usuario" + ")" +
                "values" + "(" +
                "'"+txtNome.Text+"',"+
                "'"+txtLogin.Text+"',"+
                "'"+txtSenha.Text+"',"+
                "'"+txtObs.Text+"',"+
                "'"+cboStatus.Text+"')"+
                "select SCOPE_IDENTITY()"
                ;

            // instancia uma conexão para o banco de dados
            SqlConnection conn = new SqlConnection(stringConexao);
            // instancia o comando
            SqlCommand cmd = new SqlCommand(sql, conn);
            // especifica o tipo de data do comando
            cmd.CommandType = CommandType.Text;
            SqlDataReader leitura;
            conn.Open();

            try
            {   // A variável é criada para verificar se houve resposta de linhas afetadas no banco de dados
                leitura = cmd.ExecuteReader();
                if (leitura.Read())
                {
                    btoLimpar.PerformClick();
                    MessageBox.Show("Cadastro realizado com sucesso.", "Código gerado: " + leitura[0].ToString());
                    txtId.Text = leitura[0].ToString();
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

            txtNome.Text = "";
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtConfirmarSenha.Text = "";
            cboStatus.SelectedIndex = -1;
            txtObs.Text = "";

        }

        /////////////////////
        // BOTÃO PESQUISAR //
        private void btoPesquisar_Click(object sender, EventArgs e)
        {
            string sql = "select * from usuario where id_Usuario = " + txtId.Text;

            SqlConnection conn = new SqlConnection (stringConexao);
            SqlCommand cmd = new SqlCommand (sql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader leitura;
            conn.Open();

            try
            {
                leitura = cmd.ExecuteReader();
                if (leitura.Read())
                {
                    txtNome.Text = leitura[1].ToString();
                    txtLogin.Text = leitura[2].ToString();
                    txtSenha.Text = leitura[3].ToString();
                    txtConfirmarSenha.Text = leitura[3].ToString();
                    txtObs.Text = leitura[4].ToString();
                    cboStatus.SelectedItem = leitura[5].ToString();
                }
                else
                {
                    MessageBox.Show("Usuário inexistente.");
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

        ///////////////////
        // BOTÃO ALTERAR //
        private void btoAlterar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "0")
            {
                MessageBox.Show("Selecione o Id do usuário.");
                txtId.Focus();
                return;
            }
            if (txtNome.Text.Trim() == "")
            {
                MessageBox.Show("Preencha o nome.");
                txtNome.Focus();
                return;
            }
            else if (txtLogin.Text.Trim() == "")
            {
                MessageBox.Show("Preencha o login.");
                txtLogin.Focus();
                return;
            }
            else if (txtSenha.Text.Trim() == "")
            {
                MessageBox.Show("Preencha a senha.");
                txtSenha.Focus();
                return;
            }
            else if (txtConfirmarSenha.Text.Trim() == "")
            {
                MessageBox.Show("Confirme a senha.");
                txtConfirmarSenha.Focus();
                return;
            }
            else if (cboStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Informe o status.");
                cboStatus.Focus();
                return;
            }

            if (txtConfirmarSenha.Text != txtSenha.Text)
            {
                MessageBox.Show("As senhas não são iguais.");
                txtConfirmarSenha.Text = "";
                txtConfirmarSenha.Focus();
                return;
            }

            string sql = "update usuario set " +
                "nome_Usuario = '" + txtNome.Text + "'," +
                "login_Usuario = '" + txtLogin.Text + "'," +
                "senha_Usuario = '" + txtSenha.Text + "'," +
                "obs_Usuario = '" + txtObs.Text + "'," +
                "status_Usuario = '" + cboStatus.Text + "' " +
                "where id_usuario = " + txtId.Text;

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
            string sql = "delete from usuario where id_Usuario = " + txtId.Text;

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