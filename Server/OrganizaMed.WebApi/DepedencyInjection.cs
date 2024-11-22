using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrganizaMed.Aplicacao.ModuloAtendimento;
using OrganizaMed.Aplicacao.ModuloMedico;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.ModuloAtendimento;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.Infra.Compartilhado;
using OrganizaMed.Infra.ModuloAtendimento;
using OrganizaMed.Infra.ModuloMedico;
using OrganizaMed.WebApi.Config.Mapping;

namespace OrganizaMed.WebApi;

public static class DepedencyInjection
{

    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlServer");

        services.AddDbContext<IContextoPersistencia, OrganizaMedDbContext>(optionsBuilder =>
        {
            optionsBuilder.UseSqlServer(connectionString, dbOptions =>
            {
                dbOptions.EnableRetryOnFailure();
            });
        });
    }
    
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IRepositorioMedico, RepositorioMedicoOrm>();
        services.AddScoped<ServicoMedico>();

        services.AddScoped<IRepositorioAtendimento, RepositorioAtendimentoOrm>();
        services.AddScoped<ServicoAtendimento>();
    }

    public static void ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<MedicoProfile>();
            config.AddProfile<AtendimentoProfile>();
        });
    }
}