using Microsoft.EntityFrameworkCore;
using ProjetoParaEstudo.Entity;

namespace ProjetoParaEstudo.Persistence
{
    public class DevEventDbContext : DbContext
    {

        public DevEventDbContext(DbContextOptions<DevEventDbContext> options) : base(options)
        {
            
        }

        public DbSet<DevEvent> DevEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.Entity<DevEvent>(e =>
            {
                e.ToTable("Dev_Events");

                e.HasKey(d => d.Id);

                e.Property(d => d.Title)
                .HasColumnName("Titulos")
             

                e.Property(d => d.Description) 
                .HasColumnName("Descrição");

                e.Property(d => d.StartDate)
                .HasColumnName("Data de inicio");

                e.Property(d => d.EndDate)
                .HasColumnName("Data de fim");

                e.Property(d => d.IsDeleted)
                .HasColumnName("Foi cancelado");
            });
        }

    }
}
