using ShopListApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ShopListApp.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Lobby> Lobbys { get; set; }
        public DbSet<LobbyUser> LobbyUsers { get; set; }
        public DbSet<LobbyProduct> LobbyProducts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LobbyUser>()
                .HasKey(lu => new { lu.LobbyId, lu.UserId });
            modelBuilder.Entity<LobbyUser>()
                .HasOne(l => l.Lobby)
                .WithMany(lu => lu.LobbyUsers)
                .HasForeignKey(l => l.LobbyId);
            modelBuilder.Entity<LobbyUser>()
                .HasOne(u => u.User)
                .WithMany(lu => lu.LobbyUsers)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<LobbyProduct>()
                .HasKey(lp => new { lp.LobbyId, lp.ProductId });
            modelBuilder.Entity<LobbyProduct>()
                .HasOne(l => l.Lobby)
                .WithMany(lp => lp.LobbyProducts)
                .HasForeignKey(l => l.LobbyId);
            modelBuilder.Entity<LobbyProduct>()
                .HasOne(u => u.Product)
                .WithMany(lp => lp.LobbyProducts)
                .HasForeignKey(u => u.ProductId);
        }
    }
}
