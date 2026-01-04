using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public partial class Usuario
    {
        //Cria os atributos da classe Usuario
        public int ID { get; set; }
        public string NOME { get; set; }
        public string EMAIL { get; set; }
        public string SENHA { get; set; }

        //Construtor vazio
        public Usuario() { }

        //Construtor
        public Usuario(string NOME, string EMAIL, string SENHA) {

            this.NOME = NOME;
            this.EMAIL = EMAIL;
            this.SENHA = SENHA;

        }
       
        public void ExibirDados()
        {
            Console.WriteLine($"Nome: {NOME}");
            Console.WriteLine($"Email: {EMAIL}");
        }

        public static void ContaExistente()
        {

            Console.Write("Já possui uma conta?");
            char resposta = Console.ReadKey().KeyChar;

            if (resposta == 's' || resposta == 'S')
            {
                Console.WriteLine("\nPor favor, faça o login.");
                Usuario.Logar();
            }
            else if (resposta == 'n' || resposta == 'N')
            {
                Console.WriteLine("\nPor favor, realize o cadastro.");
                Usuario.NovoCadastro();
            }
            else
            {
                Console.WriteLine("\nResposta inváliada. Por favor, responda com 's' ou 'n'.");
                ContaExistente();
            }
        }
    }
}
