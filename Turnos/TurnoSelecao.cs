using Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnos
{
    public partial class Turno
    {

        public static void TurnoSelecao()
        {

            Console.Clear();
            Console.WriteLine("Seleção de turnos");
            Console.WriteLine("Turnos disponíveis:");

            TurnoDAO NovoTurno = new TurnoDAO();

            List<Turno> Lista = NovoTurno.ListarTodos();

            //Lista vazia
            if (Lista.Count == 0)
            {
                Console.WriteLine("Nenhum turno cadastrado no sistema.");
                Console.WriteLine("Pressione qualquer tecla para voltar...");
                Console.ReadKey();
                return;
            }

            int incremento = 1;
            foreach (Turno turno in Lista)
            {
                Console.WriteLine($"{incremento} -" + $" {turno.Periodo}");
                incremento++;
            }

            Console.WriteLine("\n------------------------------");
            Console.Write("Digite o número do turno que deseja selecionar: ");

            if (int.TryParse(Console.ReadLine(), out int escolha))
            {

                if (escolha > 0 && escolha <= Lista.Count)
                {
                    Turno TurnoSelecionado = Lista[escolha - 1];

                    Console.Clear();
                    Console.WriteLine("✅ TURNO SELECIONADO!");
                    Console.WriteLine($"Você escolheu: {TurnoSelecionado.Periodo}");

                    Console.WriteLine("\nPressione Enter para continuar...");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    Console.ReadKey();
                    TurnoSelecao();
                }
            }
            else
            {
                Console.WriteLine("Digite apenas números!");
                Console.ReadKey();
                TurnoSelecao();
            }
        }
    }
}
