using SimpleAuthServer.Data.Repositories;
using SimpleAuthServer.Models.ClientService;

namespace SimpleAuthServer.Services 
{
    public interface IClientsService
    {
        Task<GetAndValidateClientResponse> GetAndValidateClientAsync(GetAndValidateClientRequest request);
    }

    public class ClientService(IClientRepo clientRepo) : IClientsService
    {
        private readonly IClientRepo _clientRepo = clientRepo;

        public async Task<GetAndValidateClientResponse> GetAndValidateClientAsync(GetAndValidateClientRequest request)
        {
            return await Task.FromResult(new GetAndValidateClientResponse(new Client(request.ClientId, request.RedirectUri)));
        }
    }
}