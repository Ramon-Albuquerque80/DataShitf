using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public partial class Usuario
    {
        //Método para realizar novo cadastro de usuário
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

            //Realiza a verificação se as senhas correspondem
            if(senhausuario == confirmasenha)
            {

                Usuario NovoUsuario = new Usuario(nomeusuario, emailusuario, senhausuario);
                Console.WriteLine(NovoUsuario.NOME + ", seu cadastro foi realizado com êxito!");
                //Exibe os dados do novo usuário
                NovoUsuario.ExibirDados();

                //Tenta salvar no banco de dados
                try
                {
                    //Cria o objeto DAO
                    UsuarioDAO dao = new UsuarioDAO();

                    //Salva no banco
                    dao.CadastrarUsuario(NovoUsuario);

                    Console.WriteLine("\nSucesso! " + NovoUsuario.NOME + ", seu cadastro foi salvo no banco de dados!");
                }
                //Captura possíveis erros ao salvar no banco
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
