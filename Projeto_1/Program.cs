using System;

namespace Projeto_1
{
    internal class Program
    {
        //enum Notas
        //{
        //    minimo = 0, Media = 5, Maximo = 10
        //}

        //struct Cadastro
        //{
        //    public string nome;
        //    public int idade;
        //    public string rg;
        //    public string cpf;
        //}

        static void Main(string[] args)
        {

            
            int numero;

            Console.Write("Digite um valor:");
            numero = Convert.ToInt32(Console.ReadLine());

            #region Inverte Nomes
            string n1, n2, n3, n4, troca;            

            Console.WriteLine($"O valor digitado é: {numero}");

            Console.Write("Nome 1:");
            n1 = Console.ReadLine();

            Console.Write("Nome 2:");
            n2 = Console.ReadLine();

            Console.Write("Nome 3:");
            n3 = Console.ReadLine();

            Console.Write("Nome 4:");
            n4 = Console.ReadLine();


            troca = n4;
            n4 = n1;
            n1 = troca;
            troca = n3;
            n3 = n2;
            n2 = troca;


            Console.WriteLine($"Ordem invertida: {n1}, {n2}, {n3}, {n4}");
            #endregion
        }
    }
}
