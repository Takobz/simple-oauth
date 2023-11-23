using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SimpleAuthServer.Data.Entities
{
    public class Entity
    {
        public Guid Id { get; protected set; }
    }
}