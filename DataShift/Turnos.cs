using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataShift
{
    public class Turnos
    {
        public static void Turno()
        {
            int opcao;

            Console.WriteLine("Selecione o turno:");
            Console.WriteLine("1 - Manhã, 2 - Tarde, 3 - Noite");

            opcao = Convert.ToInt16(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Você selecionou o turno da manhã.");
                    break;
                case 2:
                    Console.WriteLine("Você selecionou o turno da tarde.");
                    break;
                case 3:
                    Console.WriteLine("Você selecionou o turno da noite.");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}
