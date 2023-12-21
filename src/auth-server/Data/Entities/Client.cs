using SimpleAuthServer.Shared.Exceptions;

namespace SimpleAuthServer.Data.Entities
{
    public class Client : Entity
    {
        public Client(
             Guid clientId,
             string redirectUri,
             string clientName)
        {
            Id = clientId;
            RedirectUri = redirectUri ?? throw new ArgumentNullException(nameof(redirectUri)) ;
            ClientName = clientName ?? throw new ArgumentNullException(nameof(clientName));
        }

        public string RedirectUri { get; private set; } = string.Empty;
        public string ClientName { get; private set; } = string.Empty;

        public static Client Create(Guid clientId, string redirectUri, string clientName)
        {
            if (clientId == Guid.Empty)
                throw new BadRequestException("Client Id cannot be empty");

            return new Client(clientId, redirectUri, clientName);
        }
        
    }
}