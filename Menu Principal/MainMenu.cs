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
using DataShift.Produtos;

namespace DataShift.Menu_Principal
{
    public partial class MainMenu : Form
    {

        private string contextoAtual = "";
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

                if (comboTurnos.Items.Count > 0)
                {
                    ComboTurnos_SelectedIndexChanged(null, null);
                }
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

                if (contextoAtual == "Produtos") BtnProdutos_Click(null, null);
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            CadastroTurno tela = new CadastroTurno();

            tela.ShowDialog();

            CarregarTurnos();
        }

        private void BtnProdutos_Click(object sender, EventArgs e)
        {
            contextoAtual = "Produtos";

            if(Sessao.TurnoId == 0)
            {
                MessageBox.Show("Selecione um turno!");
                return;
            }

            try
            {
                ProdutoDAO dao = new ProdutoDAO();

                var lista = dao.ListarPorTurno(Sessao.TurnoId);

                GridDados.DataSource = lista;

                if (GridDados.Columns["ID"] != null) GridDados.Columns["ID"].Visible = false;
                if (GridDados.Columns["Turno_ID"] != null) GridDados.Columns["Turno_ID"].Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
            }
        }

        private void buttonNovo_Click(object sender, EventArgs e)
        {
            if (contextoAtual == "Produtos")
            {
                if (Sessao.TurnoId == 0)
                {
                    MessageBox.Show("Selecione um turno!");
                    return;
                }

                CadastroProduto tela = new CadastroProduto();
                tela.ShowDialog();

                BtnProdutos_Click(null, null);
            }
        }

        private int IdSelecionada = 0;

        private void GridDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
               IdSelecionada = Convert.ToInt32(GridDados.Rows[e.RowIndex].Cells["ID"].Value);
            }
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            if (IdSelecionada == 0)
            {
                MessageBox.Show("Selecione um item na tabela primeiro.");
                return;
            }

            if (contextoAtual == "Produtos")
            {
                if (MessageBox.Show("Deseja excluir?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ProdutoDAO dao = new ProdutoDAO();
                    dao.ExcluirProduto(IdSelecionada);

                    BtnProdutos_Click(null, null);
                    IdSelecionada = 0;
                }
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (IdSelecionada == 0)
            {
                MessageBox.Show("Selecione um produto na tabela para editar.");
                return;
            }

            if (contextoAtual == "Produtos")
            {
                
                if (GridDados.CurrentRow != null)
                {
                    
                    DataShift.Produtos.Produtos produtoEdit = new DataShift.Produtos.Produtos();

                    
                    produtoEdit.ID = Convert.ToInt32(GridDados.CurrentRow.Cells["ID"].Value);
                    produtoEdit.NOME = GridDados.CurrentRow.Cells["NOME"].Value.ToString();
                    produtoEdit.PRECO = Convert.ToDecimal(GridDados.CurrentRow.Cells["PRECO"].Value);

                    produtoEdit.TIPO = GridDados.CurrentRow.Cells["TIPO"].Value.ToString();
                    produtoEdit.PERECIVEL = GridDados.CurrentRow.Cells["PERECIVEL"].Value.ToString();

                   
                    CadastroProduto tela = new CadastroProduto();

                   
                    tela.CarregarDadosParaEdicao(produtoEdit);

                    tela.ShowDialog();

                   
                    BtnProdutos_Click(null, null);
                    IdSelecionada = 0;
                }
            }
        }
    }
}
