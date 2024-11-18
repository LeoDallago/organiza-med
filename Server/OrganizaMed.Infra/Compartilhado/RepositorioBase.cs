using Microsoft.EntityFrameworkCore;
using OrganizaMed.Dominio.Compartilhado;

namespace OrganizaMed.Infra.Compartilhado;

public class RepositorioBase<TEntidade> where TEntidade : Entidade
{
    protected OrganizaMedDbContext dbContext;
    protected DbSet<TEntidade> registros;

    public RepositorioBase(IContextoPersistencia contexto)
    {
        this.dbContext = (OrganizaMedDbContext)contexto;
        this.registros = dbContext.Set<TEntidade>();
    }

    public async Task<bool> InserirAsync(TEntidade registro)
    {
        await registros.AddAsync(registro);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public void Editar(TEntidade registro)
    {
        registros.Update(registro);
        dbContext.SaveChanges();
    }

    public void Excluir(TEntidade registro)
    {
        registros.Remove(registro);
        dbContext.SaveChanges();
    }

    public virtual TEntidade SelecionarPorId(Guid id)
    {
        return registros.SingleOrDefault(x => x.Id == id);
    }

    public async virtual Task<TEntidade> SelecionarPorIdAsync(Guid id)
    {
        return await registros.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<TEntidade>> SelecionarTodosAsync()
    {
        return await registros.ToListAsync();
    }
}