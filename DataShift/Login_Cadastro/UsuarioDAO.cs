using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Login
{
    public class UsuarioDAO
    {

        private string Conexao = "Server=localhost;Database=CadastroLogin;Uid=root;Pwd=senha1234321;";

        public void CadastrarUsuario(Usuario user)
        {
                    
            using(MySqlConnection ponte = new MySqlConnection(Conexao))
            {
            try
            {
                ponte.Open();
                string query = "INSERT INTO usuarios (NOME, EMAIL, SENHA) VALUES (@NOME, @EMAIL, @SENHA)";

                MySqlCommand cmd = new MySqlCommand(query, ponte);

                cmd.Parameters.AddWithValue("@NOME", user.NOME);
                cmd.Parameters.AddWithValue("@EMAIL", user.EMAIL);
                cmd.Parameters.AddWithValue("@SENHA", user.SENHA);

                cmd.ExecuteNonQuery();
            }

                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao cadastrar usuário: " + ex.Message);
                    throw;
                }
            }
        }
        public bool VerificarLogin(Usuario user)
        {
            using (MySqlConnection ponte = new MySqlConnection(Conexao))
            {
                try
                {
                    ponte.Open();

                    // Procura alguém que tenha O MESMO email E A MESMA senha
                    string query = "SELECT * FROM usuarios WHERE email = @email AND senha = @senha";

                    MySqlCommand cmd = new MySqlCommand(query, ponte);
                    cmd.Parameters.AddWithValue("@email", user.EMAIL);
                    cmd.Parameters.AddWithValue("@senha", user.SENHA);

                    MySqlDataReader leitor = cmd.ExecuteReader();

                    // HasRows retorna 'true' se encontrou alguma linha (usuário existe)
                    return leitor.HasRows;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao verificar login: " + ex.Message);
                }
            }
        }

    }
}
