namespace ExemploAtualizarAliasDispositivo
{
    using System;
    using C4M.Api.Authentication;
    using RestSharp;
    using RestSharp.Authenticators;

    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Exemplo para atualizar o nome do dispositivo.");

            //id do dispositivo aparece na URL dos detalhes: https://console.cloud4mobile.com.br/Devices/{id}/Details
            //ou retorno da consulta dos dispositivos: https://help.cloud4mobile.com.br/hc/pt-br/articles/360054296694-Listar-Dispositivos-v1
            var url = "https://api.cloud4mobile.com.br/devices/<id_dispositivo>/alias";
            Console.WriteLine($"URL: {url}");

            // consumer key e secret podem ser obitidos aqui: https://admin.cloud4mobile.com.br
            const string consumerKey = "<insira_aqui>";
            const string consumerSecret = "<insira_aqui>";

            var token = TokenGenerator.GetBearerToken(url, "PUT", consumerKey, consumerSecret);

            var client = new RestClient("https://api.cloud4mobile.com.br") { Authenticator = new JwtAuthenticator(token) }; // Authorization: Bearer <token>
            var request = new RestRequest("devices/<id_dispositivo>/alias", Method.PUT, DataFormat.Json)
                .AddJsonBody("DISP. VENDEDOR A");
            var result = client.Execute<string>(request);
            Console.WriteLine(result.Content);
            Console.ReadKey();
        }
    }
}