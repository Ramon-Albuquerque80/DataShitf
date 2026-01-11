using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Producao
{
    public class ProducaoDAO
    {
        // Conexão apontando para o banco de PRODUTOS
        private string Conexao = "Server=localhost;Database=ProdutoCadastro;Uid=root;Pwd=senha1234321;";

        public void SalvarRegistro(DateTime data, TimeSpan inicio, TimeSpan fim, TimeSpan tempoTotal, int idProduto, string Comentarios)
        {
            using (MySqlConnection ponte = new MySqlConnection(Conexao))
            {
                try
                {
                    ponte.Open();

                    //Comando SQL para inserir o registro de produção
                    string query = "INSERT INTO RegistrosProducao (DataP, Inicio, Fim, Tempo_Total, Id_Produto, Comentarios) VALUES (@data, @inicio, @fim, @total, @idProd, @comentarios)";

                    using (MySqlCommand cmd = new MySqlCommand(query, ponte))
                    {
                        cmd.Parameters.AddWithValue("@data", data);
                        cmd.Parameters.AddWithValue("@inicio", inicio);
                        cmd.Parameters.AddWithValue("@fim", fim);
                        cmd.Parameters.AddWithValue("@total", tempoTotal);
                        cmd.Parameters.AddWithValue("@idProd", idProduto);

                        if (string.IsNullOrEmpty(Comentarios))
                        {
                            cmd.Parameters.AddWithValue("@comentarios", "Sem ocorrências");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@comentarios", Comentarios);
                        }

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao salvar produção: " + ex.Message);
                    throw; // Joga o erro para cima
                }
            }
        }
    }
}