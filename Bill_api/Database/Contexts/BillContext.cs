using Bill_api.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bill_api.Database.Contexts
{
    public class BillContext:DbContext
    {
        public DbSet<BillProvider>? BillProviders { get; set; }
        public DbSet<Bill>? Bills { get; set; }
        public DbSet<PayingPerson>? PayingPersons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("BillDatabase"),
                o => o.UseNodaTime());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Create fluent api for all models usabe from this context.
            modelBuilder.Entity<Bill>().Property(s => s.Id)
                .HasColumnName("Id")
                .HasDefaultValue(0)
                .IsRequired();

        }
    }
}
