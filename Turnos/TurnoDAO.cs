using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataShift.Turnos
{
    public class TurnoDAO
    {
        private string stringConexao = "server=localhost;database=DataShiftDB;uid=root;pwd=senha1234321";

        public void CadastrarTurno(Turno turno)
        {
            using (MySqlConnection conexao = new MySqlConnection(stringConexao))
            {
                conexao.Open();

                string query = "INSERT INTO turnos (LIDER, PERIODO, INICIO, FIM) VALUES ( @lider, @periodo, @inicio, @fim)";

                using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@lider", turno.Lider);
                    cmd.Parameters.AddWithValue("@periodo", turno.Periodo);
                    cmd.Parameters.AddWithValue("@inicio", turno.Inicio);
                    cmd.Parameters.AddWithValue("@fim", turno.Fim);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Turno> ListarTodos()
        {
            List<Turno> lista = new List<Turno>();
            using (MySqlConnection conexao = new MySqlConnection(stringConexao))
            {
                conexao.Open();
                string query = "SELECT * FROM turnos";
                using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                using (MySqlDataReader leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        Turno t = new Turno();
                        t.Id = leitor.GetInt32("ID");
                        t.Periodo = leitor["PERIODO"].ToString();
                        t.Lider = leitor["LIDER"].ToString();
                        t.Inicio = leitor.GetTimeSpan("INICIO"); // O MySQL devolve TimeSpan direto
                        t.Fim = leitor.GetTimeSpan("FIM");
                        lista.Add(t);
                    }
                }
            }
            return lista;
        }
    }
}