using System;
using System.Windows.Forms;
using DataShift.Turnos;

namespace DataShift
{
    public partial class CadastroTurno : Form
    {
        public CadastroTurno()
        {
            InitializeComponent();
            
        }

       
        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxPeriodo.Text) || string.IsNullOrWhiteSpace(textBoxLider.Text))
                {
                    MessageBox.Show("Preencha o Nome do Turno e o Líder!");
                    return;
                }

                Turno t = new Turno();
                t.Periodo = textBoxPeriodo.Text;
                t.Lider = textBoxLider.Text;

                //O usuário tem que digitar ex: "08:00" ou "17:30"
                try
                {
                    t.Inicio = TimeSpan.Parse(textBoxInicio.Text);
                    t.Fim = TimeSpan.Parse(textBoxFim.Text);
                }
                catch
                {
                    MessageBox.Show("Horário inválido! Digite no formato HH:MM (ex: 08:00)");
                    return;
                }

                //Grava no Banco de Dados
                TurnoDAO dao = new TurnoDAO();
                dao.CadastrarTurno(t);

                MessageBox.Show("Turno cadastrado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }

        // Código do botão LIMPAR
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            textBoxPeriodo.Text = "";
            textBoxLider.Text = "";
            textBoxInicio.Text = "";
            textBoxFim.Text = "";
        }

        // Código do botão VOLTAR
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}