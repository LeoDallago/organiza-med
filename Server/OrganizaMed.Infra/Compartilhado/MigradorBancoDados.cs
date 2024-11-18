using Microsoft.EntityFrameworkCore;

namespace OrganizaMed.Infra.Compartilhado;

public static class MigradorBancoDados
{
    public static bool AtualizarBancoDados(DbContext dbContext)
    {
        var migracoesPendentes = dbContext.Database.GetPendingMigrations().Count();
        
        dbContext.Database.Migrate();
        return true;
    }
}