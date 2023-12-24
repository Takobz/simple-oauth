using Microsoft.EntityFrameworkCore;
using SimpleAuthServer.Data.Entities;

namespace SimpleAuthServer.Data.Repositories
{
    public interface IClientRepo
    {
        Task<RepoResult<Client>> GetClientAsync(Guid clientId);
        Task<RepoResult<Client>> CreateClientAsync(Client clientToBeCreates);
    }

    public class ClientRepo(IAuthServerContext context) : IClientRepo
    {
        private readonly IAuthServerContext _context = context;

        public async Task<RepoResult<Client>> GetClientAsync(Guid clientId)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == clientId);
            if (client == null)
            {
                return new RepoResult<Client>(null, isSuccess: true, isEmptyResult: true);
            }

            return new RepoResult<Client>(client, isSuccess: true, isEmptyResult: false);
        }
        
        public async Task<RepoResult<Client>> CreateClientAsync(Client clientToBeCreates)
        {
            var client = await _context.Clients.AddAsync(clientToBeCreates);
            await _context.SaveChangesAsync();
            return new RepoResult<Client>(client.Entity, isSuccess: true, isEmptyResult: false);
        }
    }
}