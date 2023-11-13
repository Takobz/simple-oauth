namespace SimpleAuthServer.Models.ClientService
{
    public class Client 
    {
        public Client(string clientId, string redirectUri)
        {
            ClientId = clientId;
            RedirectUri = redirectUri;
        }

        public string ClientId { get; private set; } = string.Empty;
        public string RedirectUri { get; private set; } = string.Empty;
    }
}