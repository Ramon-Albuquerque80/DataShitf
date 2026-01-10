using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Producao;

namespace Produto
{
    public partial class Produtos
    {

        //Dados necessários para cadastrar novos produtos
        public int ID { get; set; }
        public string NOME { get; set; }
        public decimal PRECO { get; set; }
        public string TIPO { get; set; }    
        public string PERECIVEL { get; set; }
        public int TURNO_ID { get; set; }

        //Construtor para Produtos
        public Produtos(string NOME, decimal PRECO, string TIPO, string PERECIVEL)
        {

            //this faz referência aos atributos da classe e não aos parâmetros do construtor
            this.NOME = NOME;
            this.PRECO = PRECO;
            this.TIPO = TIPO;
            this.PERECIVEL = PERECIVEL;

        }

        public Produtos() { }

        public static void Decisao()
        {

            Console.Write("\nDeseja cadastrar ou selecionar um produto existente? (c/s)");
            char resposta = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (resposta == 'c' || resposta == 'C')
            {
                CadastroProduto();
            }
            else if (resposta == 's' || resposta == 'S')
            {
                //Lógica para selecionar um produto existente
                SelecaoProduto();
            }
            else
            {

                Console.WriteLine("Resposta inválida. Por favor, responda com 'c' ou 's'.");
                Decisao();
            }
        }

        //Função para exibir o produto cadastrado
        public void ExibeProduto()
        {
            
            Console.WriteLine("\nProduto cadastrado com sucesso!");
            Console.WriteLine($"Nome: {NOME}");
            Console.WriteLine($"Preço unitário: R${PRECO:F2}");
            Console.WriteLine($"Tipo: {TIPO}");
            Console.WriteLine($"Perecível: {PERECIVEL}\n");

        }
    }
}
