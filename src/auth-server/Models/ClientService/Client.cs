namespace SimpleAuthServer.Models.ClientService
{
    public class Client(string clientId, string redirectUri) 
    {
        public string ClientId { get; private set; } = clientId;
        public string RedirectUri { get; private set; } = redirectUri;
    }
}