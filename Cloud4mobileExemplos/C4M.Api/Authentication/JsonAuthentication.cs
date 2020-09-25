namespace C4M.Api.Authentication
{
    public class JsonAuthentication
    {
        public string consumer_key;
        public string nonce;
        public string signature;
        public long timestamp;
        public string version;
    }
}