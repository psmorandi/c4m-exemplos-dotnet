namespace ExemploListarDispositivos
{
    using System;
    using C4M.Api.Authentication;
    using RestSharp;
    using RestSharp.Authenticators;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exemplo para listar os dispositivos ativos com os detalhes do grupo e dados da coleta de bateria.");

            const string url = "https://api.cloud4mobile.com.br/devices?status=1&$expand=Group,LastBatteryData";
            Console.WriteLine($"URL: {url}");

            // consumer key e secret podem ser obitidos aqui: https://admin.cloud4mobile.com.br
            const string consumerKey = "<insira_aqui>";
            const string consumerSecret = "<insira_aqui>";

            var token = TokenGenerator.GetBearerToken(url, "GET", consumerKey, consumerSecret);

            var client = new RestClient("https://api.cloud4mobile.com.br") { Authenticator = new JwtAuthenticator(token) }; // Authorization: Bearer <token>
            var request = new RestRequest("devices?status=1&$expand=Group,LastBatteryData", DataFormat.Json);
            var result = client.ExecuteAsGet<string>(request, "GET");
            Console.WriteLine(result.Content);
            Console.ReadKey();
        }
    }
}