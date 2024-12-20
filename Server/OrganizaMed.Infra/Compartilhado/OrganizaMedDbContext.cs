﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.ModuloAtendimento;
using OrganizaMed.Dominio.ModuloAutenticacao;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.Infra.ModuloAtendimento;
using OrganizaMed.Infra.ModuloMedico;

namespace OrganizaMed.Infra.Compartilhado;

public class OrganizaMedDbContext : IdentityDbContext<Usuario, Cargo, Guid>, IContextoPersistencia
{
    public DbSet<Medico> Medico { get; set; }
    public DbSet<Atendimento> Atendimento { get; set; }
    
    private readonly ITenantProvider? _tenantProvider;
    private readonly Guid UsuarioId;

    public OrganizaMedDbContext(DbContextOptions options, ITenantProvider? tenantProvider) : base(options)
    {
        UsuarioId = tenantProvider.UsuarioId.GetValueOrDefault();
    }

    public OrganizaMedDbContext() 
    {
        _tenantProvider = null;
    }
    
    public async Task<bool> GravarAsync()
    {
        await SaveChangesAsync();
        return true;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.ApplyConfiguration(new MapeadorAtendimentoOrn());
       modelBuilder.Entity<Atendimento>().HasQueryFilter(a => a.UsuarioId == UsuarioId);
        
        modelBuilder.ApplyConfiguration(new MapeadorMedicoOrm());
       modelBuilder.Entity<Medico>().HasQueryFilter(m => m.UsuarioId == UsuarioId);
        
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