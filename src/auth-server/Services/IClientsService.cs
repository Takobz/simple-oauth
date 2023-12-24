using SimpleAuthServer.Data.Repositories;
using SimpleAuthServer.Models.ClientService;

namespace SimpleAuthServer.Services 
{
    public interface IClientsService
    {
        Task<ClientGetResponse> GetAndValidateClientAsync(GetAndValidateClientRequest request);
    }

    public class ClientService(IClientRepo clientRepo) : IClientsService
    {
        private readonly IClientRepo _clientRepo = clientRepo;

        public async Task<ClientGetResponse> GetAndValidateClientAsync(GetAndValidateClientRequest request)
        {
            var clientRepoResult = await _clientRepo.GetClientAsync(request.ClientId);
            if (clientRepoResult.IsEmptyResult)
            {
                return await Task.FromResult(ClientGetResponse.EmptyResponse());
            }
            
            return await Task.FromResult(ClientGetResponse.FromClient(clientRepoResult.Result));
        }
    }
}