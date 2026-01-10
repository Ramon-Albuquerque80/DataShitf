using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Produto
{
    public class ProdutoDAO
    {
        private string Conexao = "Server=localhost;Database=DataShiftDB;Uid=root;Pwd=senha1234321;";
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

        public List<Produtos> ListarTodos()
        {
            List<Produtos> listaRetorno = new List<Produtos>();

            using (MySqlConnection ponte = new MySqlConnection(Conexao))
            {
                try
                {
                    ponte.Open();
                    string query = "SELECT * FROM produtos";

                    using (MySqlCommand cmd = new MySqlCommand(query, ponte))
                    using (MySqlDataReader leitor = cmd.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            Produtos p = new Produtos();

                            p.ID = leitor.GetInt32("Id");
                            p.NOME = leitor.GetString("NOME");
                            p.PRECO = leitor.GetDecimal("PRECO");
                            p.TIPO = leitor.GetString("TIPO");
                            p.PERECIVEL = leitor.GetString("PERECIVEL");

                            listaRetorno.Add(p);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao listar: " + ex.Message);
                }
            }
            return listaRetorno;
        }
    }
}
