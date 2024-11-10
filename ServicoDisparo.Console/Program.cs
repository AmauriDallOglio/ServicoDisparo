using ServicoDisparo.Console.HangFire;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServicoDisparo.Console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            using (HttpClient httpClient = new HttpClient())
            {
                global::System.Console.WriteLine("-----------------------------------------------------");
                global::System.Console.WriteLine("Testando Api do agendandamento do usuário serviço");
                global::System.Console.WriteLine("-----------------------------------------------------");
                AgendarUsuarioServico agendarUsuarioServico = new AgendarUsuarioServico();
                var resultado = agendarUsuarioServico.ValidaConexao(httpClient);
                switch (resultado.Result)
                {
                    case "Ok":
                        global::System.Console.WriteLine("Conexao: " + resultado.Result);
                        break;
                    default:
                        global::System.Console.WriteLine("Conexao: " + resultado.Result);
                        break;
                }


                global::System.Console.WriteLine("-----------------------------------------------------");
                global::System.Console.WriteLine("Executando o agendandamento do usuário serviço");
                global::System.Console.WriteLine("-----------------------------------------------------");

                for (int i = 0; i < 10; i++)
                {


                    var resultadoAgendamento = agendarUsuarioServico.ExecutarAgendarInsercaoSemDados(httpClient);
                    switch (resultado.Result)
                    {
                        case "Ok":
                            global::System.Console.WriteLine("Conexao: " + resultadoAgendamento.Result);
                            break;
                        default:
                            global::System.Console.WriteLine("Conexao: " + resultadoAgendamento.Result);
                            break;
                    }

                    await Task.Delay(30000); // 30 segundos = 30000 milissegundos
                }

            }


        }
    }
}