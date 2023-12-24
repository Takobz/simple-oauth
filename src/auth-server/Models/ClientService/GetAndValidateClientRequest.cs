namespace SimpleAuthServer.Models.ClientService
{
    public class GetAndValidateClientRequest(Guid clientId, string redirectUri)
    {
        public Guid ClientId { get; private set; } = clientId;
        public string RedirectUri { get; private set; } = redirectUri;
    }
}