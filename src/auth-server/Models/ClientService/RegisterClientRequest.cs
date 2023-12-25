using SimpleAuthServer.Models.DTOs;

namespace SimpleAuthServer.Models.ClientService
{
    public class RegisterClientRequest
    {
        public string ClientId { get; private set; } = string.Empty;
        public string ClientName { get; private set; } = string.Empty;
        public IEnumerable<string> RedirectUris { get; private set; } = Enumerable.Empty<string>();
        public IEnumerable<string> Scopes { get; private set; } = Enumerable.Empty<string>();
        public string ClientUri { get; private set; } = string.Empty;

        public static RegisterClientRequest CreateRequest(ClientRegistrationRequest requestDTO)
        {
            return new RegisterClientRequest
            {
                ClientName = requestDTO.ClientName,
                RedirectUris = requestDTO.RedirectUris.ToList(),
                Scopes = requestDTO.Scopes.ToList(),
                ClientUri = requestDTO.ClientUri
            };
        }
    }
}