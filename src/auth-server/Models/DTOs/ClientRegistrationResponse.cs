using SimpleAuthServer.Data.Entities;

namespace SimpleAuthServer.Models.DTOs
{
    public class ClientRegistrationResponse
    {
        public string ClientId { get; private set; } = string.Empty;
        public string ClientSecret { get; private set; } = string.Empty;
        public string ClientName { get; private set; } = string.Empty;
        public IEnumerable<string> RedirectUris { get; private set; } = Enumerable.Empty<string>();
        public IEnumerable<string> Scopes { get; private set; } = Enumerable.Empty<string>();
        public string ClientUri { get; private set; } = string.Empty;

        public static ClientRegistrationResponse FromClient(Client client)
        {
            return new ClientRegistrationResponse
            {
                ClientId = client.Id.ToString(),
                ClientSecret = client.ClientSecret,
                ClientName = client.ClientName,
                ClientUri = client.ClientUri,
                RedirectUris = client.RedirectUris.Split(" "),
                Scopes = client.Scope.Split(" ")
            };
        }
    }
}