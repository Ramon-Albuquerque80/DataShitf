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
            decimal precoproduto = Convert.ToDecimal(Console.ReadLine());

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

                try
                {
                    ProdutoDAO dao = new ProdutoDAO();
                    // Manda salvar no banco
                    dao.CadastrarProduto(NovoProduto);
                    // Se chegou aqui, é porque salvou!
                    Console.WriteLine("Sucesso! O produto foi salvo no banco de dados!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ops! Houve um erro ao salvar no banco: " + ex.Message);
                }

                Console.WriteLine("Deseja cadastrar outro produto? (s/n)");
                char resposta = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (resposta == 's' || resposta == 'S')
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
            else if(produtoperecivel == 'n' || produtoperecivel == 'N')
            {
                string perecivel = "Não";
                Produtos NovoProduto = new Produtos(nomeproduto, precoproduto, tipoproduto, perecivel);
                NovoProduto.ExibeProduto();

                try
                {
                    ProdutoDAO dao = new ProdutoDAO();
                    // Manda salvar no banco
                    dao.CadastrarProduto(NovoProduto);
                    // Se chegou aqui, é porque salvou!
                    Console.WriteLine("Sucesso! O produto foi salvo no banco de dados!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ops! Houve um erro ao salvar no banco: " + ex.Message);
                }

                Console.WriteLine("Deseja cadastrar outro produto? (s/n)");
                char resposta = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (resposta == 's' || resposta == 'S')
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
            else
            {
                Console.WriteLine("Resposta inválida. Por favor, responda com 's' ou 'n'.");
                CadastroProduto();
            }
        }
    }
}
