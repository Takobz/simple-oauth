namespace SimpleAuthServer.Models.ClientService
{
    public class GetAndValidateClientResponse
    {
        public GetAndValidateClientResponse(Client client)
        {
            Client = client;
        }

        public GetAndValidateClientResponse() { }

        public Client Client { get; private set; }
        public bool IsClientValid 
        {
            get 
            {
                return Client != null && string.IsNullOrEmpty(Client.ClientId); 
            } 
        }
    }
}