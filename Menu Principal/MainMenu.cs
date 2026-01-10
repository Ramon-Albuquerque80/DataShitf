using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataShift.Turnos;

namespace DataShift.Menu_Principal
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            ConfigurarJanela();
            CarregarTurnos();

        }

        public void ConfigurarJanela()
        {
            this.Text = "DataShift - Menu Principal";
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterScreen;
        }   

        public void CarregarTurnos()
        {
            try
            {
                TurnoDAO dao = new TurnoDAO();
                List<Turno> Turnos = dao.ListarTodos();

                comboTurnos.DataSource = Turnos;
                comboTurnos.DisplayMember = "Periodo";
                comboTurnos.ValueMember = "Id";

                comboTurnos.SelectedIndexChanged += ComboTurnos_SelectedIndexChanged;

                ComboTurnos_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar turnos: " + ex.Message);
            }


        }

        private void ComboTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboTurnos.SelectedItem is Turno turnoSelecionado)
            {
                Sessao.TurnoId = turnoSelecionado.Id;
                Sessao.TurnoNome = turnoSelecionado.Periodo;
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            CadastroTurno tela = new CadastroTurno();

            tela.ShowDialog();

            CarregarTurnos();
        }
    }
}
