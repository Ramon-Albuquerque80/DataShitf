using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Produto
{
    public class ProdutoDAO
    {
        private string Conexao = "Server=localhost;Database=ProdutoCadastro;Uid=root;Pwd=senha1234321;";
        public void CadastrarProduto(Produtos produto)
        {
            using (MySqlConnection ponte = new MySqlConnection(Conexao))
            {
                try
                {
                    ponte.Open();
                    string query = "INSERT INTO produtos (NOME, PRECO, TIPO, PERECIVEL) VALUES (@NOME, @PRECO, @TIPO, @PERECIVEL)";
                    MySqlCommand cmd = new MySqlCommand(query, ponte);
                    cmd.Parameters.AddWithValue("@NOME", produto.NOME);
                    cmd.Parameters.AddWithValue("@PRECO", produto.PRECO);
                    cmd.Parameters.AddWithValue("@TIPO", produto.TIPO);
                    cmd.Parameters.AddWithValue("@PERECIVEL", produto.PERECIVEL);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao cadastrar produto: " + ex.Message);
                    throw;
                }
            }
        }
    }
}
