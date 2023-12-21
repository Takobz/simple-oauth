namespace SimpleAuthServer.Models.ClientService
{
    public class GetAndValidateClientResponse(Client client)
    {
        public Client Client { get; private set; } = client;
        public bool IsClientValid 
        {
            get 
            {
                return Client != null && string.IsNullOrEmpty(Client.ClientId); 
            } 
        }
    }
}