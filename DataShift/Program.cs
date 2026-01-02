using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login;
using Produto;

namespace DataShift
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Realiza o cadastramento de usuários no sistema utilizando a classe Usuario
            Usuario.ContaExistente();

            //Realiza o cadastramento de produtos utilizando a classe Produtos de maneira recursiva
            //Produtos.CadastroProduto();

            //Turnos.Turno();
            
          

        }
    }
}
