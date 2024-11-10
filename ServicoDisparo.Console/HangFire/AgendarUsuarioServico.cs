using System.Net.Http.Headers;
using System.Text;

namespace ServicoDisparo.Console.HangFire
{
    public class AgendarUsuarioServico
    {

        public async Task<string> ValidaConexao(HttpClient httpClient)
        {
            string apiUrl = "https://localhost:7250/api/Usuario/Conexao";
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            return content;
        }


        public async Task<string> ExecutarAgendarInsercaoSemDados(HttpClient httpClient)
        {
            global::System.Console.WriteLine("-----------------------------------------------------");
            global::System.Console.WriteLine("Iniciando chamada para API: Hangfire/AgendarInsercaoSemDados ");
            global::System.Console.WriteLine("-----------------------------------------------------");

            try
            {
                // Configurar o handler para aceitar qualquer certificado SSL
                var handler = new HttpClientHandler
                {
                    // Ignorar erros de certificado SSL no ambiente de desenvolvimento
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                };

                using (var client = new HttpClient(handler))
                {
          
                    string apiUrl = "https://127.0.0.1:7250/api/Usuario/AgendarInsercaoSemDados";
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
           


                    global::System.Console.WriteLine("Executa a requisição POST com corpo vazio para " + apiUrl);
  
                    var response = await client.PostAsync(apiUrl, new StringContent("", Encoding.UTF8, "application/json"));
             
                    // Lê o conteúdo da resposta
                    var content = await response.Content.ReadAsStringAsync();

                    // Verifica se a resposta foi bem-sucedida
                    if (response.IsSuccessStatusCode)
                    {
                        global::System.Console.WriteLine("Resposta do servidor:");
                        global::System.Console.WriteLine(content);
                    }
                    else
                    {
                        global::System.Console.WriteLine($"Erro: {response.StatusCode}");
                        global::System.Console.WriteLine($"Detalhes do erro: {content}");
                    }

                    return content;
                }
            }
            catch (HttpRequestException httpEx)
            {
                global::System.Console.WriteLine($"Erro de requisição HTTP: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                global::System.Console.WriteLine($"Erro geral: {ex.Message}");
            }

            global::System.Console.WriteLine("Finalizando execução do método Executar.");
            return string.Empty;
        }
    }
}
