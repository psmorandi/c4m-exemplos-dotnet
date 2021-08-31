namespace ExemploGeracaoBearerToken
{
    using System;
    using C4M.Api.Authentication;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Exemplo de geração de token de autenticação.");

            const string Url = "https://api.cloud4mobile.com.br/devices?status=1";

            // consumer key e secret podem ser obitidos aqui: https://admin.cloud4mobile.com.br
            const string ConsumerKey = "<insira_aqui>";
            const string ConsumerSecret = "<insira_aqui>";

            var token = TokenGenerator.GetBearerToken(Url, "GET", ConsumerKey, ConsumerSecret);

            Console.WriteLine("---");
            Console.WriteLine("HTTP header a ser utilizado: ");
            Console.WriteLine($"Authentication: Bearer {token}");
            Console.ReadKey();
        }
    }
}