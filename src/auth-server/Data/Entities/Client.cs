namespace SimpleAuthServer.Data.Entities
{
    public class Client : Entity
    {
        public Client(Guid clientId, string redirectUri)
        {
            Id = clientId;
            RedirectUri = redirectUri;
        }

        public string RedirectUri { get; private set; } = string.Empty;

        public static Client Create(Guid clientId, string redirectUri)
         => new (clientId, redirectUri);
        
    }
}