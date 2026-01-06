using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnos
{
    public partial class Turno
    {

        public static void TurnoCadastro()
        {
            Console.Clear();
            Console.WriteLine("Cadastramento de turno");

            Console.Write("Periodo:");
            string Periodo = Console.ReadLine();

            Console.WriteLine("DIgite os horários em formato HH:MM");
            Console.Write("Hirário de inicio: ");
            TimeSpan Inicio;

            //Enquanto TimeSpan não conseguir converter, continue perguntando
            while (!TimeSpan.TryParse(Console.ReadLine(), out Inicio))
            {
                // Se cair aqui dentro, é porque o usuário digitou errado
                Console.WriteLine("Horário inválido! Tente no formato 00:00 ");
            }

            Console.Write("Horário de Fim: ");
            TimeSpan Fim;

            while(!TimeSpan.TryParse(Console.ReadLine(), out Fim))
            {
                Console.WriteLine("Horário inválido! Tente no formato 00:00 ");
            }

            Console.Write("Líder responsável:");
            string Lider = Console.ReadLine();

            Turno NovoTurno = new Turno(Lider, Periodo, Inicio, Fim);

            try
            {
                TurnoDAO dao = new TurnoDAO();
                dao.CadastrarTurno(NovoTurno);
                Console.WriteLine("\n✅ Turno cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao salvar: " + ex.Message);
            }

            Console.WriteLine("Deseja selecionar um turno? (s/n)");
            char resposta = char.ToUpper(Console.ReadKey().KeyChar);

            if(resposta == 'S')
            {
                TurnoSelecao();
            }else if(resposta == 'N')
            {
                Console.Write("Deseja cadastrar outro turno? (s/n)");
                char resp = char.ToUpper(Console.ReadKey().KeyChar);

                if(resp == 'S')
                {
                    TurnoCadastro();
                }
                else
                {
                    //Tenho que vincular essa ocasião ha algum método
                    Console.WriteLine("Então se foda");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida!");
                return;
                //Tenho que vincular essa ocasião ha algum tipo de retorno
            }

        }
    
    }
}
