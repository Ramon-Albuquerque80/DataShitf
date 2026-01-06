using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Turnos
{
    
    public class TurnoDAO
    {
        private string Conexao = "Server=localhost;Database=CadastroLogin;Uid=root;Pwd=senha1234321;";

        public void CadastrarTurno(Turno turno)
        {
            using (MySqlConnection ponte = new MySqlConnection(Conexao))
            {
                try
                {
                    ponte.Open();
                    // ATENÇÃO: Verifique se no banco está 'lider_do_periodo' ou outro nome
                    string query = "INSERT INTO Turnos (Lider, Periodo, Inicio, Fim) VALUES (@lider, @periodo, @inicio, @fim)";

                    using (MySqlCommand cmd = new MySqlCommand(query, ponte))
                    {
                        cmd.Parameters.AddWithValue("@lider", turno.Lider);
                        cmd.Parameters.AddWithValue("@periodo", turno.Periodo);
                        cmd.Parameters.AddWithValue("@inicio", turno.Inicio);
                        cmd.Parameters.AddWithValue("@fim", turno.Fim);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao cadastrar: " + ex.Message);
                }
            }
        }

        public List<Turno> ListarTodos()
        {
            List<Turno> lista = new List<Turno>();
            using (MySqlConnection ponte = new MySqlConnection(Conexao))
            {
                try
                {
                    ponte.Open();
                    string query = "SELECT * FROM Turnos";

                    using (MySqlCommand cmd = new MySqlCommand(query, ponte))
                    using (MySqlDataReader leitor = cmd.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            Turno t = new Turno();
                            t.ID = leitor.GetInt32("id");

                            // Mapeando as colunas novas
                            // Se der erro aqui, confira o nome exato da coluna no Workbench
                            t.Lider = leitor.GetString("lider");
                            t.Periodo = leitor.GetString("Periodo");

                            t.Inicio = leitor.GetTimeSpan("Inicio");
                            t.Fim = leitor.GetTimeSpan("Fim");

                            lista.Add(t);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao listar: " + ex.Message);
                }
            }
            return lista;
        }
    }
}
