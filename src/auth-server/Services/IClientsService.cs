using SimpleAuthServer.Models.ClientService;

namespace SimpleAuthServer.Services 
{
    public interface IClientsService
    {
        Task<GetAndValidateClientResponse> GetAndValidateClientAsync(GetAndValidateClientRequest request);
    }

    public class ClientService : IClientsService
    {
        //Add Repository
        public async Task<GetAndValidateClientResponse> GetAndValidateClientAsync(GetAndValidateClientRequest request)
        {
            return await Task.FromResult(new GetAndValidateClientResponse(new Client(request.ClientId, request.RedirectUri)));
        }
    }
}