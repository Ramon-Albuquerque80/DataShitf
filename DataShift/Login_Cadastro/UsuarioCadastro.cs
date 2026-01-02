using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public partial class Usuario
    {

        public static void NovoCadastro()
        {

            Console.WriteLine("----- Cadastro de Usuário -----");

            Console.Write("Nome:");
            string nomeusuario = Console.ReadLine();

            Console.Write("Email:");
            string emailusuario = Console.ReadLine();

            Console.Write("Senha:");
            string senhausuario = Console.ReadLine();

            Console.Write("Confirme a senha:");
            string confirmasenha = Console.ReadLine();

            if(senhausuario == confirmasenha)
            {

                Usuario NovoUsuario = new Usuario(nomeusuario, emailusuario, senhausuario);
                Console.WriteLine(NovoUsuario.NOME + ", seu cadastro foi realizado com êxito!");
                NovoUsuario.ExibirDados();

                try
                {
                    UsuarioDAO dao = new UsuarioDAO();

                    // Manda salvar no banco
                    dao.CadastrarUsuario(NovoUsuario);

                    // Se chegou aqui, é porque salvou!
                    Console.WriteLine("\nSucesso! " + NovoUsuario.NOME + ", seu cadastro foi salvo no banco de dados!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nOps! Houve um erro ao salvar no banco: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Senha incorreta!");

            }
        }
    }
}
