using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public partial class Usuario
    {
        public static void Logar()
        {
            Console.Write("Email:");
            string email = Console.ReadLine();

            Console.Write("Senha:");
            string senha = Console.ReadLine();

            try
            {

                Usuario tentativa = new Usuario();
                tentativa.EMAIL = email;
                tentativa.SENHA = senha;
                UsuarioDAO dao = new UsuarioDAO();

                bool verifica = dao.VerificarLogin(tentativa);

                if (verifica)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nLOGIN REALIZADO COM SUCESSO!");
                    Console.WriteLine("Bem-vindo ao sistema.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nE-mail ou senha incorretos!");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao tentar logar: " + ex.Message);
            }

            Console.WriteLine("\nPressione Enter para continuar...");
            Console.ReadLine();
        
        }
    }
}
