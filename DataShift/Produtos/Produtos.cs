using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produto
{
    public partial class Produtos
    {

        //Dados necessários para cadastrar novos produtos
        private string NOME { get; set; }
        private double PRECO { get; set; }
        private string TIPO { get; set; }
        private string PERECIVEL { get; set; }

        //Construtor para Produtos
        private Produtos(string NOME, double PRECO, string TIPO, string PERECIVEL)
        {

            //this faz referência aos atributos da classe e não aos parâmetros do construtor
            this.NOME = NOME;
            this.PRECO = PRECO;
            this.TIPO = TIPO;
            this.PERECIVEL = PERECIVEL;

        }

        //Função para exibir o produto cadastrado
        private void ExibeProduto()
        {
            
            Console.WriteLine("\nProduto cadastrado com sucesso!");
            Console.WriteLine($"Nome: {NOME}");
            Console.WriteLine($"Preço unitário: R${PRECO:F2}");
            Console.WriteLine($"Tipo: {TIPO}");
            Console.WriteLine($"Perecível: {PERECIVEL}\n");

        }
    }
}
