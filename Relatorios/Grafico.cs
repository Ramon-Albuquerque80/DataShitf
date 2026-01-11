using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Producao;
using Spectre.Console;
using DataShift.Produtos;
using System.Linq;

namespace Relatorios
{

    public class DadosGrafico
    {
        public DateTime Data { get; set; }
        public double MinutosTotais { get; set; }

        public static void GerarGrafico(List<DadosGrafico> dados, Produtos ProdutoSelecionado)
        {
            Console.Clear();
            AnsiConsole.Write(new FigletText(ProdutoSelecionado.NOME).Color(Color.Cyan1));

            var table = new Table();
            table.AddColumn("Data");
            table.AddColumn("Minutos");
            foreach (var item in dados)
            {
                table.AddRow(item.Data.ToString("dd/MM"), item.MinutosTotais.ToString());
            }
            AnsiConsole.Write(table);

            Console.WriteLine("\nPressione Enter para voltar...");
            Console.ReadLine();
        }
    }
}