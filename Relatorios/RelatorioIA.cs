using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Spectre.Console;

namespace Relatorios
{
    public class RelatorioIA
    {
        // 🔒 SEGURANÇA
        private static readonly string API_KEY = Environment.GetEnvironmentVariable("GEMINI_API_KEY");

        // URL Fixa do Modelo Flash
        private const string URL_API = "https://generativelanguage.googleapis.com/v1beta/models/gemini-flash-latest:generateContent";

        public static async Task<string> GerarRelatorioInteligente(string nomeProduto, List<DadosDetalhados> historico)
        {
            // Verificação de Segurança
            if (string.IsNullOrEmpty(API_KEY))
            {
                return "ERRO DE SEGURANÇA: A API Key não foi encontrada.\n" +
                       "Crie uma Variável de Ambiente no Windows chamada 'GEMINI_API_KEY'.";
            }

            try
            {
                var dadosRecentes = historico.Take(15).ToList();

                StringBuilder promptBuilder = new StringBuilder();
                promptBuilder.AppendLine($"Analise a produção de: '{nomeProduto}'.");
                promptBuilder.AppendLine("Identifique padrões e causas.");
                promptBuilder.AppendLine("Responda em português, técnico, direto e SEM emojis.");
                promptBuilder.AppendLine("DADOS:");

                foreach (var item in dadosRecentes)
                {
                    string obs = string.IsNullOrEmpty(item.Comentarios) ? "-" : item.Comentarios;
                    promptBuilder.AppendLine($"- {item.Data:dd/MM}: {item.TempoTotal:hh\\:mm}h. Obs: {obs}");
                }

                var payload = new
                {
                    contents = new[] { new { parts = new[] { new { text = promptBuilder.ToString() } } } }
                };

                string jsonEnvio = JsonConvert.SerializeObject(payload);

                using (HttpClient client = new HttpClient())
                {
                    var content = new StringContent(jsonEnvio, Encoding.UTF8, "application/json");
                    string urlCompleta = $"{URL_API}?key={API_KEY}";

                    HttpResponseMessage response = await client.PostAsync(urlCompleta, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResposta = await response.Content.ReadAsStringAsync();
                        JObject json = JObject.Parse(jsonResposta);
                        return (string)json["candidates"][0]["content"]["parts"][0]["text"];
                    }
                    else
                    {
                        return $"Erro na API: {response.StatusCode}";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Erro interno: " + ex.Message;
            }
        }
    }
}