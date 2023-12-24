using SimpleAuthServer.Data.Entities;

namespace SimpleAuthServer.Models.ClientService
{
    public class ClientGetResponse
    {
        public string ClientId { get; private set; } = string.Empty;
        public string ClientName { get; private set; } = string.Empty;
        public IEnumerable<string> RedirectUris { get; private set; } = Enumerable.Empty<string>();
        public IEnumerable<string> Scopes { get; private set; } = Enumerable.Empty<string>();
        public string ClientUri { get; private set; } = string.Empty;
        public bool IsNullOrEmpty { get; private set; }

        public static ClientGetResponse FromClient(Client client)
        {
            return new ClientGetResponse
            {
                ClientId = client.Id.ToString(),
                ClientName = client.ClientName,
                ClientUri = client.ClientUri,
                RedirectUris = client.RedirectUris.Split(" "),
                Scopes = client.Scope.Split(" ")
            };
        }

        public static ClientGetResponse EmptyResponse()
        {
            return new ClientGetResponse
            {
                IsNullOrEmpty = true
            };
        }
    }
}