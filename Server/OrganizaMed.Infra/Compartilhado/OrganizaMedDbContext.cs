using Microsoft.EntityFrameworkCore;
using OrganizaMed.Dominio.Compartilhado;

namespace OrganizaMed.Infra.Compartilhado;

public class OrganizaMedDbContext : DbContext, IContextoPersistencia
{
    public OrganizaMedDbContext(DbContextOptions options) : base(options) { }
    
    
    public async Task<bool> GravarAsync()
    {
        await SaveChangesAsync();
        return true;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}