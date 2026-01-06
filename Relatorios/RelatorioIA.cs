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
        // ✅ Chave que você forneceu (Hardcoded para funcionar AGORA)
        private const string API_KEY = "AIzaSyDPw2lnTKB6znI3c_3mf5IcuksvSnusF7Q";

        // ✅ URL CORRETA BASEADA NA SUA LISTA (Usando o 'latest' para não quebrar no futuro)
        private const string URL_API = "https://generativelanguage.googleapis.com/v1beta/models/gemini-flash-latest:generateContent";

        // Importante: Verifique se sua classe de dados é 'DadosDetalhado' ou 'DadosDetalhados' (com S)
        // Se der erro vermelho no nome abaixo, adicione o 's' no final.
        public static async Task<string> GerarRelatorioInteligente(string nomeProduto, List<DadosDetalhados> historico)
        {
            try
            {
                // Pega os últimos 15 registros para não estourar o limite de texto
                var dadosRecentes = historico.Take(15).ToList();

                StringBuilder promptBuilder = new StringBuilder();
                // Contexto para a IA
                promptBuilder.AppendLine($"Você é um Gerente de Produção Industrial em 2026. Analise os dados do produto: '{nomeProduto}'.");
                promptBuilder.AppendLine("Identifique padrões, dias de baixa produtividade e causas (baseado nas observações).");
                promptBuilder.AppendLine("Responda em português, com tom profissional, em no máximo 4 linhas.");
                promptBuilder.AppendLine("\n--- DADOS DE PRODUÇÃO ---");

                foreach (var item in dadosRecentes)
                {
                    string obs = string.IsNullOrEmpty(item.Comentarios) ? "-" : item.Comentarios;
                    promptBuilder.AppendLine($"- Data: {item.Data:dd/MM} | Tempo: {item.TempoTotal:hh\\:mm}h | Obs: {obs}");
                }

                // Monta o JSON no formato que o Gemini 2.0/3.0 espera
                var payload = new
                {
                    contents = new[]
                    {
                        new { parts = new[] { new { text = promptBuilder.ToString() } } }
                    }
                };

                string jsonEnvio = JsonConvert.SerializeObject(payload);

                using (HttpClient client = new HttpClient())
                {
                    var content = new StringContent(jsonEnvio, Encoding.UTF8, "application/json");
                    string urlCompleta = $"{URL_API}?key={API_KEY}";

                    // Envia para o Google
                    HttpResponseMessage response = await client.PostAsync(urlCompleta, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResposta = await response.Content.ReadAsStringAsync();
                        JObject json = JObject.Parse(jsonResposta);

                        // Caminho padrão de resposta do Gemini
                        return (string)json["candidates"][0]["content"]["parts"][0]["text"];
                    }
                    else
                    {
                        // Se der erro, mostra o motivo técnico
                        string erroDetalhado = await response.Content.ReadAsStringAsync();
                        return $"FALHA NA API ({response.StatusCode}):\n{erroDetalhado}";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Erro interno no C#: " + ex.Message;
            }
        }
    }
}