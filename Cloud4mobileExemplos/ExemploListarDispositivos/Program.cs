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

            const string baseUrl = "https://api.cloud4mobile.com.br";
            const string resource = "devices";
            const string parameters = "status=1&$expand=Group,LastBatteryData";
            var url = $"{baseUrl}/{resource}?{parameters}";
            Console.WriteLine($"URL: {url}");
            const string method = "GET";
            
            // consumer key e secret podem ser obitidos aqui: https://admin.cloud4mobile.com.br
            const string consumerKey = "<insira_aqui>";
            const string consumerSecret = "<insira_aqui>";

            var token = TokenGenerator.GetBearerToken(url, method, consumerKey, consumerSecret);

            var client = new RestClient(baseUrl) { Authenticator = new JwtAuthenticator(token) };
            var request = new RestRequest($"{resource}?{parameters}", DataFormat.Json);
            var result = client.ExecuteAsGet<string>(request, "GET");
            Console.WriteLine(result.Content);
            Console.ReadKey();
        }
    }
}