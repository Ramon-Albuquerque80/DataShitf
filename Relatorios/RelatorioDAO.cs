using MySql.Data.MySqlClient;
using Producao;
using Produto;
using Relatorios;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios
{
    public class RelatorioDAO
    {

        // Conexão com o banco de produtos
        private string Conexao = "Server=localhost;Database=produtocadastro;Uid=root;Pwd=senha1234321;";

        // Método específico para buscar dados do gráfico
        public List<DadosGrafico> BuscarDadosParaGrafico(int idProduto)
        {
            List<DadosGrafico> lista = new List<DadosGrafico>();

            using (MySqlConnection ponte = new MySqlConnection(Conexao))
            {
                try
                {
                    ponte.Open();
                    // SQL: Pega Data e Tempo, ordenado por Data
                    string query = "SELECT DataP, Tempo_Total FROM RegistrosProducao WHERE Id_Produto = @id ORDER BY DataP ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, ponte))
                    {
                        cmd.Parameters.AddWithValue("@id", idProduto);

                        using (MySqlDataReader leitor = cmd.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                DadosGrafico dado = new DadosGrafico();
                                dado.Data = leitor.GetDateTime("DataP");

                                // Converte TimeSpan para Minutos (Double)
                                TimeSpan tempo = leitor.GetTimeSpan("Tempo_Total");
                                dado.MinutosTotais = tempo.TotalMinutes;

                                lista.Add(dado);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao buscar dados para relatório: " + ex.Message);
                }
            }
            return lista;
        }

        public List<DadosDetalhados> BuscarHistoricoCompleto(int idProduto)
        {
            List<DadosDetalhados> lista = new List<DadosDetalhados>();
            using (MySqlConnection ponte = new MySqlConnection(Conexao))
            {
                try
                {
                    ponte.Open();
                    string query = "SELECT DataP, Inicio, Fim, Tempo_Total, Comentarios FROM RegistrosProducao WHERE Id_Produto = @id ORDER BY DataP DESC";
                    using (MySqlCommand cmd = new MySqlCommand(query, ponte))
                    {
                        cmd.Parameters.AddWithValue("@id", idProduto);
                        using (MySqlDataReader leitor = cmd.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                DadosDetalhados dado = new DadosDetalhados();
                                dado.Data = leitor.GetDateTime("DataP");
                                dado.Inicio = leitor.GetTimeSpan("Inicio");
                                dado.Fim = leitor.GetTimeSpan("Fim");
                                dado.TempoTotal = leitor.GetTimeSpan("Tempo_Total");

                                if (!leitor.IsDBNull(leitor.GetOrdinal("Comentarios")))
                                    dado.Comentarios = leitor.GetString("Comentarios");
                                else
                                    dado.Comentarios = "-";

                                lista.Add(dado);
                            }
                        }
                    }
                }
                catch { }
            }
            return lista;
        }
    }
}



