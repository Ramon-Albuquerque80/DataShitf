using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Producao;
using Relatorios;

namespace Produto
{
    public partial class Produtos
    {

        public static void SelecaoProduto()
        {
            Console.Clear();
            Console.WriteLine("Lista de produtos:");

            ProdutoDAO dao = new ProdutoDAO();

            List<Produtos> lista = dao.ListarTodos();

            //Lista vazia
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado no sistema.");
                Console.WriteLine("Pressione qualquer tecla para voltar...");
                Console.ReadKey();
                return;
            }

            int incremento = 1;
            foreach(Produtos produto in lista)
            {
                Console.WriteLine($"{incremento} - {produto.NOME}");
                incremento++;   
            }

            Console.WriteLine("\n------------------------------");
            Console.Write("Digite o número do produto que deseja selecionar: ");

            if (int.TryParse(Console.ReadLine(), out int escolha))
            {

                if (escolha > 0 && escolha <= lista.Count)
                {
                    Produtos produtoSelecionado = lista[escolha - 1];

                    Console.Clear();
                    Console.WriteLine("✅ PRODUTO SELECIONADO!");
                    Console.WriteLine($"Você escolheu: {produtoSelecionado.NOME}");

                    Console.WriteLine("1 - Registrar a produção \n2 - Gerar Relatório");
                    char opcao = char.ToUpper(Console.ReadKey().KeyChar);

                    if (opcao == '1')
                    {

                        Registro.Apontar(produtoSelecionado);

                    }else if (opcao == '2')
                    {
                        RelatorioAnalitico.GerarAnalise(produtoSelecionado);
                    }
                    else
                    {
                        SelecaoProduto();
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    Console.ReadKey();
                    SelecaoProduto();
                }
            }
            else
            {
                Console.WriteLine("Digite apenas números!");
                Console.ReadKey();
                SelecaoProduto();
            }
        }
    }
}
