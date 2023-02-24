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

        // Teste para ver se funciona o carregamento da ComboBox com o banco de dados
        private void carregarComboBox()
        {
            string sql = "select id_Categoria, nome_Categoria from categoria";

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader leitura;
            DataTable dt = new DataTable();
            conn.Open();

            try
            {
                leitura = cmd.ExecuteReader();
                //Quando a tabela carregar, usar leitura
                dt.Load(leitura);

                //Especifica a coluna da tabela
                cboCodigoCategoria.DisplayMember = "id_Categoria";
                //Mostra o valor da linha-coluna
                cboCodigoCategoria.DataSource = dt; 

                cboNomeCategoria.DisplayMember = "nome_Categoria";
                cboNomeCategoria.DataSource = dt;
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
            carregarComboBox();
        }

        private void btoLimpar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            cboNomeCategoria.SelectedIndex = -1;
            cboCodigoCategoria.SelectedIndex = -1;
            txtNome.Text = "";
            txtQuantidade.Value = 0;
            txtValorCusto.Text = "";
            txtValorVenda.Text = "";
            txtData.Text = "";
            cboStatus.SelectedIndex = -1;
            txtDescricao.Text = "";
            txtObs.Text = "";
        }

        // Formatar o valor de custo para moeda quando o usuário sai do campo
        private void txtValorCusto_Leave(object sender, EventArgs e)
        {
            float vCusto;
            if (!float.TryParse(txtValorCusto.Text, out vCusto) && txtValorCusto.Text.Trim() != "")
            {
                MessageBox.Show("Erro. Valor de custo deve ser numérico e sem formato.");
                txtValorCusto.Text = "";
                txtValorCusto.Focus();
                return;
            }else if (txtValorCusto.Text.Trim() == "")
            {
                txtValorCusto.Text = "";
                return;
            }

            txtValorCusto.Text = String.Format("{0:C}", vCusto);
        }

        //Retirar a formatação de moeda do valor de custo quanto o usuário abre o campo
        private void txtValorCusto_Enter(object sender, EventArgs e)
        {
            txtValorCusto.Text = txtValorCusto.Text.Replace("R$ ", "");
        }

        private void txtValorVenda_Leave(object sender, EventArgs e)
        {
            float vVenda;
            if (!float.TryParse(txtValorVenda.Text, out vVenda) && txtValorVenda.Text.Trim() != "")
            {
                MessageBox.Show("Erro. Valor de custo deve ser numérico e sem formato.");
                txtValorVenda.Text = "";
                txtValorVenda.Focus();
                return;
            }
            else if (txtValorVenda.Text.Trim() == "")
            {
                txtValorVenda.Text = "";
                return;
            }

            txtValorVenda.Text = String.Format("{0:C}", vVenda);
        }

        private void txtValorVenda_Enter(object sender, EventArgs e)
        {
            txtValorVenda.Text = txtValorVenda.Text.Replace("R$ ", "");
        }

        //////////////////////////////////
        // BOTÃO CADASTRAR COM PESQUISA //
        private void btoCadastrar_Click(object sender, EventArgs e)
        {
            string vCusto = txtValorCusto.Text;
            // Exemplo: R$1.000,00
            vCusto = vCusto.Replace("R$ ", "");// Exemplo: 1.000,00
            vCusto = vCusto.Replace(".", "");  // Exemplo: 1000,00

            string vVenda = txtValorVenda.Text;
            // Exemplo: R$1.000,00
            vVenda = vVenda.Replace("R$ ", "");// Exemplo: 1.000,00
            vVenda = vVenda.Replace(".", "");  // Exemplo: 1000,00

            if (cboNomeCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Informe a categoria");
                cboNomeCategoria.Focus();
                return;
            }
            
            if (txtNome.Text.Trim() == "")
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
                if (!float.TryParse(vCusto, out i))
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
                if (!float.TryParse(vVenda, out i))
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

            vCusto = vCusto.Replace(",", "."); // Exemplo: 1000.00 = formato correto para o banco de dados
            vVenda = vVenda.Replace(",", "."); // Exemplo: 1000.00 = formato correto para o banco de dados

            string sql = "insert into produto " + 
            "(nome_Produto, id_Categoria_Produto, valorcusto_Produto, valorvenda_Produto, descricao_Produto, qtde_Produto, obs_Produto, status_Produto)" +
            "values" +
            " ('" + txtNome.Text + "','" + cboCodigoCategoria.Text + "','" + vCusto + "','" + vVenda + "','" + txtDescricao.Text + "','" + txtQuantidade.Text + "','" + txtObs.Text + "','" + cboStatus.Text + "')" 
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
                    cboCodigoCategoria.Text = leitura[2].ToString();

                    txtValorCusto.Text = leitura[3].ToString();
                    txtValorCusto.Text = String.Format("{0:C}", float.Parse(txtValorCusto.Text));

                    txtValorVenda.Text = leitura[4].ToString();
                    txtValorVenda.Text = String.Format("{0:C}", float.Parse(txtValorVenda.Text));

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
            string vCusto = txtValorCusto.Text;
            // Exemplo: R$1.000,00
            vCusto = vCusto.Replace("R$ ", "");// Exemplo: 1.000,00
            vCusto = vCusto.Replace(".", "");  // Exemplo: 1000,00
            

            string vVenda = txtValorVenda.Text;
            // Exemplo: R$1.000,00
            vVenda = vVenda.Replace("R$ ", "");// Exemplo: 1.000,00
            vVenda = vVenda.Replace(".", "");  // Exemplo: 1000,00

            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Informe o código do produto.");
                txtCodigo.Focus();
                return;
            }
            
            if (cboNomeCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Informe a categoria.");
                cboNomeCategoria.Focus();
                return;
            }

           if (txtNome.Text.Trim() == "")
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
                if (!float.TryParse(vCusto, out i))
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
                txtValorVenda.Text.Replace("R$ ", "");
                float i;
                if (!float.TryParse(vVenda, out i))
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

            vCusto = vCusto.Replace(",", "."); // Exemplo: 1000.00 = formato correto para o banco de dados
            vVenda = vVenda.Replace(",", "."); // Exemplo: 1000.00 = formato correto para o banco de dados


            string sql = "set dateformat dmy update produto set " +
                "id_Categoria_Produto = " + cboCodigoCategoria.Text + "," +
                "nome_Produto = '" + txtNome.Text + "'," +
                // .Replace(oldchar, newchar) > altera um caracter.
                "valorcusto_Produto = " + vCusto + "," +
                "valorvenda_Produto = " + vVenda + "," +
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
