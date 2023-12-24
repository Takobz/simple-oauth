using SimpleAuthServer.Models.DTOs;

namespace SimpleAuthServer.Models.ClientService
{
    public class ClientRegistrationServiceResponse(ClientRegistrationResponse client)
    {
        public ClientRegistrationResponse Client { get; private set; } = client;
        public bool IsClientValid 
        {
            get 
            {
                return Client != null && string.IsNullOrEmpty(Client.ClientId); 
            } 
        }
    }

    public class ClientGetServiceResponse(ClientRegistrationResponse client)
    {
        public ClientRegistrationResponse Client { get; private set; } = client;
        public bool IsClientValid 
        {
            get 
            {
                return Client != null && string.IsNullOrEmpty(Client.ClientId); 
            } 
        }
    }
}