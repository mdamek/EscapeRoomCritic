using EscapeRoomCritic.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EscapeRoomCritic.Infrastructure
{
    public sealed class EscapeRoomCriticDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<EscapeRoom> EscapeRooms {get; set;}
        public DbSet<Review> Reviews { get; set; }

    public EscapeRoomCriticDbContext(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
