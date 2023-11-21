using Microsoft.EntityFrameworkCore;
using SimpleAuthServer.Data.Entities;

#pragma warning disable CS8618
namespace SimpleAuthServer.Data
{
    public class AuthServerContext : DbContext 
    {
        public DbSet<Client> Clients { get; set; }

        public AuthServerContext(){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../SimpleOAuthDatabase.db");
        }
    }
}