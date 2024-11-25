using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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
        services.AddTransient<ServicoMedico>();

        services.AddScoped<IRepositorioAtendimento, RepositorioAtendimentoOrm>();
        services.AddTransient<ServicoAtendimento>();
    }

    public static void ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<MedicoProfile>();
            config.AddProfile<AtendimentoProfile>();
            config.AddProfile<UsuarioProfile>();
        });
    }

    public static void SwaggerConfig(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
       services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Organiza Med",
                Version = "v1"
            });
    
            options.MapType<TimeSpan>(() => new Microsoft.OpenApi.Models.OpenApiSchema
            {
                Type = "string",
                Format = "time-span",
                Example = new Microsoft.OpenApi.Any.OpenApiString("00:00:00")
            });
    
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                Description = "Por favor informe o Token padrao {Bearer token}",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT"
            });
    
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });
    }
}