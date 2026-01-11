using System;
using System.Collections.Generic;
using System.Linq; // Essencial para cálculos como Média
using Spectre.Console; // A biblioteca de gráficos
using DataShift.Produtos;

namespace Relatorios
{
    public class RelatorioAnalitico
    {
        // Este é o método que o seu menu está tentando chamar
        public static void GerarAnalise(Produtos produtoSelecionado)
        {
            Console.Clear();

            //Título
            AnsiConsole.Write(
                new FigletText(produtoSelecionado.NOME)
                .Color(Color.Cyan1));

            AnsiConsole.MarkupLine("[bold yellow]Carregando dados...[/]");

            //Busca os dados no Banco
            RelatorioDAO dao = new RelatorioDAO();
            List<DadosGrafico> dados = dao.BuscarDadosParaGrafico(produtoSelecionado.ID);

            if (dados.Count == 0)
            {
                AnsiConsole.MarkupLine($"\n[red]Não existem registros de produção para {produtoSelecionado.NOME}.[/]");
                Console.WriteLine("Cadastre uma produção na opção 1 antes de ver o gráfico.");
                Console.WriteLine("\nPressione Enter para voltar...");
                Console.ReadLine();
                return;
            }

            //Cálculo (Média)
            double media = dados.Average(d => d.MinutosTotais);

            //Configuração do Gráfico (Spectre.Console)
            AnsiConsole.MarkupLine("\n[bold underline]GRÁFICO DE TEMPO GASTO (MINUTOS)[/]");

            var grafico = new BarChart()
                .Width(80)
                .Label($"Histórico: {produtoSelecionado.NOME}")
                .CenterLabel();

            // Adiciona cada barra no gráfico
            foreach (var item in dados)
            {
                // Define a cor: Verde se for rápido (abaixo da média), Vermelho se for lento
                Color corBarra = item.MinutosTotais > media ? Color.Red : Color.Green;

                grafico.AddItem(
                    item.Data.ToString("dd/MM"),       // Nome da barra (Data)
                    Math.Round(item.MinutosTotais, 0), // Tamanho da barra (Tempo)
                    corBarra                           // Cor
                );
            }

            //PLOTA na tela
            AnsiConsole.Write(grafico);

            // Rodapé com estatísticas simples
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine($"Média de tempo: {Math.Round(media, 0)} minutos");
            Console.WriteLine($"Total de registros: {dados.Count}");

            List<DadosDetalhados> dadosCompletos = dao.BuscarHistoricoCompleto(produtoSelecionado.ID);

            AnsiConsole.WriteLine();

            // Painel de Carregamento (Spinner)
            AnsiConsole.Status()
                .Spinner(Spinner.Known.Star)
                .Start("[yellow]Conectando ao cérebro da IA para analisar a produção...[/]", ctx =>
                {
                    // Chama o nosso AnalistaIA
                    // O .GetAwaiter().GetResult() força o código a esperar a resposta
                    string analise = RelatorioIA.GerarRelatorioInteligente(produtoSelecionado.NOME, dadosCompletos)
                                     .GetAwaiter().GetResult();

                    // Mostra o resultado
                    Console.WriteLine();
                    AnsiConsole.MarkupLine("\n[bold cyan]RELATÓRIO INTEIGENTE:[/]");

                    var panel = new Panel(analise);
                    panel.Border = BoxBorder.Rounded;
                    panel.Padding = new Padding(1, 1, 1, 1);
                    panel.Header = new PanelHeader("Análise Qualitativa");

                    AnsiConsole.Write(panel);
                });

            Console.WriteLine("\nPressione Enter para voltar...");
            Console.ReadLine();

            // Opcional: Chama o menu de volta se quiser
            //Produtos.SelecaoProduto();
        }
    }
}
