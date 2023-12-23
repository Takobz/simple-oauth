using Microsoft.EntityFrameworkCore;
using SimpleAuthServer.Data.Entities;

#pragma warning disable CS8618
namespace SimpleAuthServer.Data
{
    public interface IAuthServerContext
    {
        public DbSet<Client> Clients { get; set; }
    }

    public class AuthServerContext : DbContext, IAuthServerContext
    {

        private readonly IWebHostEnvironment _env;
        public AuthServerContext(IWebHostEnvironment env)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
        }

        public DbSet<Client> Clients { get; set; }

        public AuthServerContext(){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(_env.ContentRootPath, "Data/Database/SimpleOAuthDatabase01.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}