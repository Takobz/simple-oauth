using SimpleAuthServer.Shared.Exceptions;
using System.Security.Cryptography;

namespace SimpleAuthServer.Data.Entities
{
    ///<summary>
    /// To get full client metadata reference: https://tools.ietf.org/html/rfc6749#section-2.2
    ///</summary>
    public class Client : Entity
    {
        ///<summary>
        /// Constructor for Entity Framework
        ///</summary>
        public Client(){}

        [Obsolete("This constructor is Obselete was created before full client")]
        public Client(
             Guid clientId,
             string redirectUri,
             string clientName)
        {
            Id = clientId;
            RedirectUris = redirectUri ?? throw new ArgumentNullException(nameof(redirectUri)) ;
            ClientName = clientName ?? throw new ArgumentNullException(nameof(clientName));
        }

        public Client(
            string clientName,
            List<string> redirectUris,
            List<string> scopes,
            string clientUri,
            List<string> grantTypes,
            List<string> responseTypes,
            string tokenEndpointAuthMethod)
        {
            Id = Guid.NewGuid();
            ClientName = clientName ?? throw new ArgumentNullException(nameof(clientName));
            RedirectUris = redirectUris != null ? String.Join(" ", redirectUris) : throw new ArgumentNullException(nameof(redirectUris));
            Scope = scopes != null ? String.Join(" ", scopes) : throw new ArgumentNullException(nameof(scopes));
            ClientUri = clientUri ?? throw new ArgumentNullException(nameof(clientUri));
            GrantTypes = grantTypes != null ? String.Join(" ", grantTypes) : throw new ArgumentNullException(nameof(grantTypes));
            ResponseTypes = responseTypes != null ? String.Join(" ", responseTypes) : throw new ArgumentNullException(nameof(responseTypes));
            TokenEndpointAuthMethod = tokenEndpointAuthMethod ?? throw new ArgumentNullException(nameof(tokenEndpointAuthMethod));
            ClientSecret = GenerateClientSecret();
        }

        public string ClientName { get; private set; } = string.Empty;
        public string RedirectUris { get; private set; } = string.Empty;
        public string TokenEndpointAuthMethod { get; private set; } = string.Empty;
        public string GrantTypes { get; private set; } = string.Empty;
        public string ResponseTypes { get; private set; } = string.Empty;
        public string ClientUri { get; private set; } = string.Empty;
        public string LogoUri { get; private set; } = string.Empty;
        public string TosUri { get; private set; } = string.Empty;
        public string Scope { get; private set; } = string.Empty;
        public string Contacts { get; private set; } = string.Empty;
        public string ClientSecret { get; private set; } = string.Empty;

        public static Client Create(Guid clientId, string redirectUri, string clientName)
        {
            if (clientId == Guid.Empty)
                throw new BadRequestException("Client Id cannot be empty");

            return new Client(clientId, redirectUri, clientName);
        }

        public static Client Create(string clientName,
            List<string> redirectUris,
            List<string> scopes,
            string clientUri,
            List<string> grantTypes,
            List<string> responseTypes,
            string tokenEndpointAuthMethod)
        {
            return new Client(
                clientName,
                redirectUris,
                scopes,
                clientUri,
                grantTypes,
                responseTypes,
                tokenEndpointAuthMethod);
        }

        private static string GenerateClientSecret()
        {
            using var cryptoProvider = RandomNumberGenerator.Create();
            byte[] randomBytes = new byte[32]; // Change the size as needed
            cryptoProvider.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }
    }
}