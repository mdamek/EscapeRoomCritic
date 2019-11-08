using EscapeRoomCritic.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EscapeRoomCritic.Infrastructure
{
    public class EscapeRoomCriticDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public EscapeRoomCriticDbContext(DbContextOptions options) : base(options) { }
    }
}
