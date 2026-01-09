using System;
using System.Drawing;
using System.Windows.Forms;

namespace DataShift.Login_Cadastro
{
    
    public partial class TelaCadastro : Form
    {
        public TelaCadastro()
        {
            InitializeComponent();
            ConfigurarPlaceholders();
        }

       
        private void TelaCadastro_Load(object sender, EventArgs e)
        {
           
        }

        private void ConfigurarPlaceholders()
        {
            if (TxtBoxNome != null) { TxtBoxNome.Text = "Insira seu Nome Completo"; TxtBoxNome.ForeColor = Color.Gray; }
            if (TxtBoxEmail != null) { TxtBoxEmail.Text = "Insira seu E-mail"; TxtBoxEmail.ForeColor = Color.Gray; }
            if (TxtBoxSenha != null) { TxtBoxSenha.Text = "Crie uma Senha"; TxtBoxSenha.ForeColor = Color.Gray; TxtBoxSenha.UseSystemPasswordChar = false; }
            if (TxtBoxConfirma != null) { TxtBoxConfirma.Text = "Repita a Senha"; TxtBoxConfirma.ForeColor = Color.Gray; TxtBoxConfirma.UseSystemPasswordChar = false; }
        }

        private void TxtBoxNome_Enter(object sender, EventArgs e)
        {
            if (TxtBoxNome.Text == "Insira seu Nome Completo") { TxtBoxNome.Text = ""; TxtBoxNome.ForeColor = Color.Black; }
        }

        private void TxtBoxNome_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtBoxNome.Text)) { TxtBoxNome.Text = "Insira seu Nome Completo"; TxtBoxNome.ForeColor = Color.Gray; }
        }
        private void TxtBoxEmail_Enter(object sender, EventArgs e)
        {
            if (TxtBoxEmail.Text == "Insira seu E-mail") { TxtBoxEmail.Text = ""; TxtBoxEmail.ForeColor = Color.Black; }
        }
        private void TxtBoxEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtBoxEmail.Text)) { TxtBoxEmail.Text = "Insira seu E-mail"; TxtBoxEmail.ForeColor = Color.Gray; }
        }

        private void TxtBoxSenha_Enter(object sender, EventArgs e)
        {
            if (TxtBoxSenha.Text == "Crie uma Senha") { TxtBoxSenha.Text = ""; TxtBoxSenha.ForeColor = Color.Black; TxtBoxSenha.UseSystemPasswordChar = true; }
        }
        private void TxtBoxSenha_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtBoxSenha.Text)) { TxtBoxSenha.UseSystemPasswordChar = false; TxtBoxSenha.Text = "Crie uma Senha"; TxtBoxSenha.ForeColor = Color.Gray; }
        }

        private void TxtBoxConfirma_Enter(object sender, EventArgs e)
        {
            if (TxtBoxConfirma.Text == "Repita a Senha") { TxtBoxConfirma.Text = ""; TxtBoxConfirma.ForeColor = Color.Black; TxtBoxConfirma.UseSystemPasswordChar = true; }
        }
        private void TxtBoxConfirma_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtBoxConfirma.Text)) { TxtBoxConfirma.UseSystemPasswordChar = false; TxtBoxConfirma.Text = "Repita a Senha"; TxtBoxConfirma.ForeColor = Color.Gray; }
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            if (TxtBoxEmail.Text == "Insira seu E-mail" || string.IsNullOrWhiteSpace(TxtBoxEmail.Text) ||TxtBoxSenha.Text == "Crie uma Senha" || string.IsNullOrWhiteSpace(TxtBoxSenha.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos!", "Atenção");
                return;
            }

            if (TxtBoxSenha.Text != TxtBoxConfirma.Text)
            {
                MessageBox.Show("As senhas não conferem!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Cria o pacote de dados
                Usuario novoUsuario = new Usuario();
                novoUsuario.Nome = TxtBoxNome.Text; 
                novoUsuario.Email = TxtBoxEmail.Text;
                novoUsuario.Senha = TxtBoxSenha.Text;

                UsuarioDAO dao = new UsuarioDAO();
                dao.CadastrarUsuario(novoUsuario);

                MessageBox.Show("Conta criada com sucesso!", "Bem-vindo");

                TelaLogin login = new TelaLogin();
                login.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                // Mostra o erro se o banco falhar
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void LinkLogin_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

            TelaLogin login = new TelaLogin();
            login.Show();
            this.Close();

        }


    }
}