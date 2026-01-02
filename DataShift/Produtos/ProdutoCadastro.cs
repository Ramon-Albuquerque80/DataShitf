using Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produto
{
    public partial class Produtos
    {

        public static void CadastroProduto()
        {

            Console.WriteLine("Cadastro de Produto");

            Console.Write("Nome do produto: ");
            string nomeproduto = Console.ReadLine();

            Console.Write("Preço unitário do produto: R$");
            double precoproduto = Convert.ToDouble(Console.ReadLine());

            Console.Write("Categoria do produto: ");
            string tipoproduto = Console.ReadLine();

            Console.Write("O produto é perecível? (s/n): ");
            char produtoperecivel = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (produtoperecivel == 's' || produtoperecivel == 'S')
            {

                string perecivel = "Sim";
                Produtos NovoProduto = new Produtos(nomeproduto, precoproduto, tipoproduto, perecivel);
                NovoProduto.ExibeProduto();
            }
            else
            {
                string perecivel = "Não";
                Produtos NovoProduto = new Produtos(nomeproduto, precoproduto, tipoproduto, perecivel);
                NovoProduto.ExibeProduto();
            }

            Console.WriteLine("Deseja cadastrar outro produto? (s/n)");
            char resposta = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if(resposta == 's' || resposta == 'S')
            {
                Console.WriteLine();
                CadastroProduto();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Cadastramento encerrado!");
            }
        }
    }
}
