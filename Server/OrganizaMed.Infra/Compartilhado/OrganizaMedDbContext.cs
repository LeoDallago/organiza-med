using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.Infra.ModuloMedico;

namespace OrganizaMed.Infra.Compartilhado;

public class OrganizaMedDbContext : DbContext, IContextoPersistencia
{
    public DbSet<Medico> Medico { get; set; }
    
    public OrganizaMedDbContext(DbContextOptions options) : base(options) { }

    public OrganizaMedDbContext()
    {
        
    }
    
    public async Task<bool> GravarAsync()
    {
        await SaveChangesAsync();
        return true;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new MapeadorMedicoOrm());
        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config.GetConnectionString("SqlServer");

        optionsBuilder.UseSqlServer(connectionString);

        base.OnConfiguring(optionsBuilder);
    }
}