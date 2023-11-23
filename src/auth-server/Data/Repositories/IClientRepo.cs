using Microsoft.EntityFrameworkCore;
using SimpleAuthServer.Data.Entities;

namespace SimpleAuthServer.Data.Repositories
{
    public interface IClientRepo
    {
        Task<RepoResult<Client>> GetClientAsync(Guid clientId);
    }

    public class ClientRepo : IClientRepo
    {
        private readonly IAuthServerContext _context;

        public ClientRepo(IAuthServerContext context)
        {
            _context = context;
        }

        public async Task<RepoResult<Client>> GetClientAsync(Guid clientId)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == clientId);
            if (client == null)
            {
                return new RepoResult<Client>(null, isSuccess: true, isEmptyResult: true);
            }

            return new RepoResult<Client>(client, isSuccess: true, isEmptyResult: false);
        }
    }
}