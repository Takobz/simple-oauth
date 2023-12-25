using SimpleAuthServer.Data.Repositories;
using SimpleAuthServer.Models.ClientService;
using SimpleAuthServer.Data.Entities;

namespace SimpleAuthServer.Services 
{
    public interface IClientsService
    {
        Task<ClientGetResponse> GetAndValidateClientAsync(GetAndValidateClientRequest request);
        Task<RegisterClientResponse> RegisterClientAsync(RegisterClientRequest request); //should I use DTOs here?
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

        public async Task<RegisterClientResponse> RegisterClientAsync(RegisterClientRequest request)
        {
            //TODO: make sure we have the same fields as Client.Create() needs.
            throw new NotImplementedException();
        }
    }
}