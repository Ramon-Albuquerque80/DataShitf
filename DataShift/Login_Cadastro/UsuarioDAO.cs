using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Login
{
    public class UsuarioDAO
    {
        //String de conexão com banco de dados
        private string Conexao = "Server=localhost;Database=CadastroLogin;Uid=root;Pwd=senha1234321;";

        //Método para cadastrar usuário no banco de dados
        public void CadastrarUsuario(Usuario user)
        {
            //Usa o 'using' para garantir que a conexão será fechada corretamente
            using(MySqlConnection ponte = new MySqlConnection(Conexao))
            {
            try
            {
                //Abre a conexão
                ponte.Open();
                string query = "INSERT INTO usuarios (NOME, EMAIL, SENHA) VALUES (@NOME, @EMAIL, @SENHA)";

                //Cria o comando SQL
                MySqlCommand cmd = new MySqlCommand(query, ponte);

                //Adiciona os parâmetros para evitar SQL Injection
                cmd.Parameters.AddWithValue("@NOME", user.NOME);
                cmd.Parameters.AddWithValue("@EMAIL", user.EMAIL);
                cmd.Parameters.AddWithValue("@SENHA", user.SENHA);

                //Executa o comando
                cmd.ExecuteNonQuery();
            }
                //Captura qualquer erro que ocorra durante o processo
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao cadastrar usuário: " + ex.Message);
                    //Relança a exceção para tratamento posterior, se necessário
                    throw;
                }
            }
        }
        //Método para verificar login de usuário
        public bool VerificarLogin(Usuario user)
        {
            //Usa p 'using' garantir que a conexão será fechada corretamente
            using (MySqlConnection ponte = new MySqlConnection(Conexao))
            {
                //Tenta abrir a conexão e executar p comando
                try
                {
                    //Abre a conexão
                    ponte.Open();

                    // Procura email e senha correspondentes
                    string query = "SELECT * FROM usuarios WHERE email = @email AND senha = @senha";

                    //Cria o comando SQL
                    MySqlCommand cmd = new MySqlCommand(query, ponte);
                    //Adiciona os parâmetros para evitar SQL Injection
                    cmd.Parameters.AddWithValue("@email", user.EMAIL);
                    cmd.Parameters.AddWithValue("@senha", user.SENHA);

                    //Executa o comando e obtém o leitor de dados
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
