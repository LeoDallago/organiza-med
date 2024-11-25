using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OrganizaMed.Aplicacao.ModuloAutenticacao;
using OrganizaMed.Dominio.ModuloAutenticacao;
using OrganizaMed.Infra.Compartilhado;

namespace OrganizaMed.WebApi.Identity;

public static class IdentityDependecyInjection
{
    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddTransient<ServicoAutenticacao>();
        services.AddTransient<JsonWebTokenProvider>();
        services.AddTransient<ITenantProvider, ApiTenantProvider>();

        services.AddIdentity<Usuario, Cargo>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<OrganizaMedDbContext>()
            .AddDefaultTokenProviders();
    }

    public static void ConfigureJwt(this IServiceCollection services, IConfiguration config)
    {
        var chaveAssinaturaJwt = config["JWT_GENERATION_KEY"];
        
        if(chaveAssinaturaJwt == null)
            throw new ArgumentException("Nao foi possivel obter a chave de assinatura do token.");
        
        var chaveEmBytes = Encoding.ASCII.GetBytes(chaveAssinaturaJwt);

        var audienciaValida = config["JWT_AUDIENCE_DOMAIN"];
        
        if (audienciaValida == null)
            throw new ArgumentException("Nao foi possivel obter o dominio da audiencia");

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = true;
            x.SaveToken = true;

            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(chaveEmBytes),
                ValidAudience = audienciaValida,
                ValidIssuer = "OrganizaMed",
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true
            };
        });
    }
}