using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataShift.Produtos
{
    public class ProdutoDAO
    {
        private string Conexao = "Server=localhost;Database=DataShiftDB;Uid=root;Pwd=senha1234321;";

        public void CadastrarProduto(Produtos produto, int idTurno)
        {
            using (MySqlConnection ponte = new MySqlConnection(Conexao))
            {
                try
                {
                    ponte.Open();

                    string query = "INSERT INTO produtos (Nome, Preco, Categoria, Perecivel, TURNO_ID) VALUES (@NOME, @PRECO, @TIPO, @PERECIVEL, @TURNO_ID)";

                    MySqlCommand cmd = new MySqlCommand(query, ponte);
                    cmd.Parameters.AddWithValue("@NOME", produto.NOME);
                    cmd.Parameters.AddWithValue("@PRECO", produto.PRECO);

                    cmd.Parameters.AddWithValue("@TIPO", produto.TIPO);
                    cmd.Parameters.AddWithValue("@PERECIVEL", produto.PERECIVEL);

                    cmd.Parameters.AddWithValue("@TURNO_ID", idTurno);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao cadastrar produto: " + ex.Message);
                    throw;
                }
            }
        }

        public void AtualizarProduto(Produtos p)
        {
            using (MySqlConnection ponte = new MySqlConnection(Conexao))
            {
                try
                {
                    ponte.Open();
                    string query = "UPDATE produtos SET Nome = @nome, Preco = @preco, Categoria = @tipo, Perecivel = @perecivel WHERE Id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, ponte))
                    {
                        cmd.Parameters.AddWithValue("@nome", p.NOME);
                        cmd.Parameters.AddWithValue("@preco", p.PRECO);
                        cmd.Parameters.AddWithValue("@tipo", p.TIPO);
                        cmd.Parameters.AddWithValue("@perecivel", p.PERECIVEL);
                        cmd.Parameters.AddWithValue("@id", p.ID);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao atualizar produto: " + ex.Message);
                }
            }
        }

        public void ExcluirProduto(int id)
        {
            using (MySqlConnection ponte = new MySqlConnection(Conexao))
            {
                try
                {
                    ponte.Open();
                    string query = "DELETE FROM produtos WHERE Id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, ponte))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao excluir produto: " + ex.Message);
                }
            }
        }

        public List<Produtos> ListarPorTurno(int idTurno)
        {
            List<Produtos> listaRetorno = new List<Produtos>();

            using (MySqlConnection ponte = new MySqlConnection(Conexao))
            {
                try
                {
                    ponte.Open();
                    string query = "SELECT * FROM produtos WHERE TURNO_ID = @idTurno";

                    using (MySqlCommand cmd = new MySqlCommand(query, ponte))
                    {
                        cmd.Parameters.AddWithValue("@idTurno", idTurno);

                        using (MySqlDataReader leitor = cmd.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                Produtos p = new Produtos();
                                p.ID = leitor.GetInt32("Id");
                                p.NOME = leitor.GetString("Nome");
                                p.PRECO = leitor.GetDecimal("Preco");

                                // Atenção: O banco devolve a coluna "Categoria", mas sua classe chama "TIPO"
                                p.TIPO = leitor.GetString("Categoria");

                                p.PERECIVEL = leitor.GetString("Perecivel");

                                listaRetorno.Add(p);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao listar produtos do turno: " + ex.Message);
                }
            }
            return listaRetorno;
        }
    }
}