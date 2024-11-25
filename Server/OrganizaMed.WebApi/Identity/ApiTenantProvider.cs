using System.Security.Claims;
using OrganizaMed.Dominio.ModuloAutenticacao;

namespace OrganizaMed.WebApi.Identity;

public class ApiTenantProvider : ITenantProvider
{
    public IHttpContextAccessor contextAccessor;
    
    public ApiTenantProvider(IHttpContextAccessor contextAccessor)
    {
        this.contextAccessor = contextAccessor;
    }
    public Guid? UsuarioId
    {
        get
        {
            var claimId = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);

            if (claimId == null)
                return null;
            
            return Guid.Parse(claimId.Value);
        }
        
        
    }
}