using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataShift.Login_Cadastro  
{
    public class UsuarioDAO
    {
        //String de conexão com banco de dados
        private string Conexao = "Server=localhost;Database=CadastroLogin;Uid=root;Pwd=senha1234321;";

        public bool VerificarLogin(Usuario user)
        {
            using (MySqlConnection ponte = new MySqlConnection(Conexao))
            {
              
                try
                {
                    //Abre a conexão
                    ponte.Open();

                    // Procura email e senha correspondentes
                    string query = "SELECT * FROM usuarios WHERE email = @email AND senha = @senha";

                    //Cria o comando SQL
                    MySqlCommand cmd = new MySqlCommand(query, ponte);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@senha", user.Senha);

                    MySqlDataReader leitor = cmd.ExecuteReader();
                    return leitor.HasRows;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao verificar login: " + ex.Message);
                }
            }
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            string conexaoString = "server=localhost;database=CadastroLogin;uid=root;pwd=senha1234321";

            string query = "INSERT INTO usuarios (NOME, EMAIL, SENHA) VALUES (@nome, @email, @senha)";

            using (MySqlConnection conexao = new MySqlConnection(conexaoString))
            {
                try
                {
                    conexao.Open();
                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@nome", usuario.Nome);
                        comando.Parameters.AddWithValue("@email", usuario.Email);
                        comando.Parameters.AddWithValue("@senha", usuario.Senha);

                        comando.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Se der erro, joga o erro para quem chamou tratar
                    throw new Exception("Erro ao cadastrar no banco: " + ex.Message);
                }
            }
        }

    }
}
