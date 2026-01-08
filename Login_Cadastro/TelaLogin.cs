using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataShift.Login_Cadastro
{ 

    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();

            ConfigurarPlaceholders();
        }

        private void ConfigurarPlaceholders()
        {

            TxtBoxEmail.Text = "Digite seu E-mail";
            TxtBoxEmail.ForeColor = Color.Gray;


            TxtBoxSenha.Text = "Digite sua Senha";
            TxtBoxSenha.ForeColor = Color.Gray;
            TxtBoxSenha.UseSystemPasswordChar = false;
        }

        private void TxtBoxEmail_Enter(object sender, EventArgs e)
        {

            if (TxtBoxEmail.Text == "Digite seu E-mail")
            {
                TxtBoxEmail.Text = "";
                TxtBoxEmail.ForeColor = Color.Black;
            }

        }

        private void TxtBoxEmail_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TxtBoxEmail.Text))
            {
                TxtBoxEmail.Text = "Digite seu E-mail";
                TxtBoxEmail.ForeColor = Color.Gray;
            }

        }

        private void TxtBoxSenha_Enter(object sender, EventArgs e)
        {
            if (TxtBoxSenha.Text == "Digite sua Senha")
            {
                TxtBoxSenha.Text = "";
                TxtBoxSenha.ForeColor = Color.Black;
                TxtBoxSenha.UseSystemPasswordChar = true;
            }
        }

        private void TxtBoxSenha_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtBoxSenha.Text))
            {
                TxtBoxSenha.UseSystemPasswordChar = false;
                TxtBoxSenha.Text = "Digite sua Senha";
                TxtBoxSenha.ForeColor = Color.Gray;
            }
        }

        private void BotaoConfirmar_Click(object sender, EventArgs e)
        {

            if (TxtBoxEmail.Text == "Digite seu E-mail" || string.IsNullOrWhiteSpace(TxtBoxEmail.Text) || TxtBoxSenha.Text == "Digite sua Senha" || string.IsNullOrWhiteSpace(TxtBoxSenha.Text))
            {
                MessageBox.Show("Preencha todos os campos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                UsuarioDAO dao = new UsuarioDAO();
                Usuario usertemporario = new Usuario();

                usertemporario.Email = TxtBoxEmail.Text;
                usertemporario.Senha = TxtBoxSenha.Text;

                bool loginSucesso = dao.VerificarLogin(usertemporario);

                if (loginSucesso)
                {
                    MessageBox.Show("Bem-vindo ao DataShift!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();

                    MessageBox.Show("Entrou!");
                }
                else
                {
                    MessageBox.Show("E-mail ou senha incorretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Erro ao conectar no banco de dados: " + ex.Message);
            }
        }

        private void LinkCadastro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TelaCadastro tela = new TelaCadastro();

            tela.Show();

            this.Hide();
        }
    }
}
