namespace SimpleAuthServer.Data.Entities
{
    public class Client : Entity
    {
        public string RedirectUri { get; private set; } = string.Empty;
    }
}