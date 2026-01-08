using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataShift.Login_Cadastro; 
using Produto;
using Turnos;
using System.Windows.Forms;

namespace DataShift
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Login_Cadastro.TelaLogin());
            //Realiza o cadastramento de usuários no sistema utilizando a classe Usuario
            //Usuario.ContaExistente();

            //Turno.Decisao();

            //Realiza o cadastramento de produtos utilizando a classe Produtos de maneira recursiva
            //Produtos.Decisao();     

        }
    }
}
