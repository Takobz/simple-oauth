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
        public DbSet<Client> Clients { get; set; }

        public AuthServerContext(){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../SimpleOAuthDatabase.db");
        }
    }
}