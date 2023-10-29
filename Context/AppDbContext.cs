using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PokéCoin.Models;

namespace PokéCoin.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasData(
                new Usuarios
                {

                    ID = 1,
                    Nome = "Primeiro Usuário",
                    Email = "email@email.com",
                    Senha = "senha123",
                    DataNascimento = DateTime.Now
                }
                );

        }
    }
}
