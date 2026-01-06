using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Digests;
using Produto;

namespace Producao
{
    public class Registro
    {

        public static void Apontar(Produtos produtoSelecionado)
        {

            Console.Clear();
            Console.WriteLine("Registro da produção\n");
            Console.WriteLine($"Produto selecionado: {produtoSelecionado.NOME} ID: {produtoSelecionado.ID}");
            Console.WriteLine();

            DateTime DataAtual = DateTime.Now;

            Console.WriteLine($"Data: {DataAtual:dd/MM/yyyy}");
            Console.Write("Deseja usar esta data? (s/n)\n");
            Console.WriteLine();

            char resposta = char.ToUpper(Console.ReadKey().KeyChar);

            if(resposta == 'N') {

                Console.WriteLine("\nDigite a data: (DD/MM/AAAA)");
                string DataManual = Console.ReadLine();

                if(!DateTime.TryParse(DataManual, out DataAtual))
                {
                    Console.WriteLine("Data inválida! Data de hoje será utilizada.");
                    DataAtual = DateTime.Now;
                }
            }
            else
            {
                Console.WriteLine("Insira os horários de produção");
            }

            Console.Write("Inicio: ");
            TimeSpan Inicio;

            while (!TimeSpan.TryParse(Console.ReadLine(), out Inicio)){

                Console.WriteLine("Formato inválido! Tente novamento (ex: 08:00)");

            }
            
            Console.Write("Fim: ");
            TimeSpan Fim;

            while (!TimeSpan.TryParse(Console.ReadLine(), out Fim))
            {
                Console.WriteLine("Formato inválido! Tente novamente (ex: 17:00)");
            }

            TimeSpan TempoTotal = Fim - Inicio;

            if(TempoTotal.TotalMinutes < 0)
            {
                TempoTotal = TempoTotal.Add(new TimeSpan(24, 0, 0));
            }

            Console.WriteLine("\n--- OCORRÊNCIAS ---");
            Console.WriteLine("Houve algum imprevisto? (Digite abaixo ou ENTER para pular):");
            string obs = Console.ReadLine();

            try
            {
                ProducaoDAO dao = new ProducaoDAO();
                dao.SalvarRegistro(DataAtual, Inicio, Fim, TempoTotal, produtoSelecionado.ID, obs);
                Console.WriteLine("\n\nSucesso! Produção registrada.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\nErro: " + ex.Message);
            }
        }
    }
}
