namespace C4M.Api.Authentication
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using Newtonsoft.Json;

    public static class TokenGenerator
    {
        private static readonly Random Random = new Random();

        public static string GetBearerToken(string url, string method, string consumerKey, string consumerSecret)
        {
            var jsonHttpAut = new JsonAuthentication
                              {
                                  consumer_key = consumerKey,
                                  nonce = GetNonce(),
                                  timestamp = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                                  version = "1.0"
                              };
            jsonHttpAut.signature = CalcSha256Hash(
                consumerSecret,
                consumerSecret + jsonHttpAut.consumer_key + jsonHttpAut.nonce + jsonHttpAut.timestamp +
                jsonHttpAut.version + method.ToUpperInvariant() + url.ToUpperInvariant());

            var token = JsonConvert.SerializeObject(jsonHttpAut);

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
        }

        private static string CalcSha256Hash(string key, string input)
        {
            using (var hmac256 = new HMACSHA256())
            {
                hmac256.Key = Encoding.UTF8.GetBytes(key);
                hmac256.Initialize();
                return
                    Convert.ToBase64String(
                        hmac256.ComputeHash(Encoding.UTF8.GetBytes(input)));
            }
        }

        private static string GetNonce()
        {
            var random = BitConverter.GetBytes(GetRandomNumber(1, 1000));
            return Convert.ToBase64String(random);
        }

        private static int GetRandomNumber(double minimum, double maximum)
        {
            return Convert.ToInt32(Random.NextDouble() * (maximum - minimum) + minimum);
        }
    }
}