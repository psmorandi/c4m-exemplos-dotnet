namespace ExemploGeracaoBearerToken
{
    using System;
    using C4M.Api.Authentication;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Exemplo de geração de token de autenticação.");

            var url = "https://api.cloud4mobile.com.br/devices?status=1";
            var method = "GET";
            var consumerKey = "<insira_aqui>";
            var consumerSecret = "<insira_aqui>";

            var token = TokenGenerator.GetBearerToken(url, method, consumerKey, consumerSecret);

            Console.WriteLine("---");
            Console.WriteLine("HTTP header a ser utilizado: ");
            Console.WriteLine($"Authentication: Bearer {token}");
            Console.ReadKey();
        }
    }
}