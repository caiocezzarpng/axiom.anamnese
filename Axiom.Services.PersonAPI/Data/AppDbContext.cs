using Axiom.Services.PersonAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Axiom.Services.PersonAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonDetails> PersonDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da relação 1:1 entre Person e PersonDetails
            modelBuilder.Entity<Person>()
                .HasOne(p => p.PersonDetails)
                .WithOne(pd => pd.Person)
                .HasForeignKey<PersonDetails>(pd => pd.PersonId);
        }

    }
}