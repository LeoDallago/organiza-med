using Microsoft.EntityFrameworkCore;
using OrganizaMed.Dominio.Compartilhado;

namespace OrganizaMed.Infra.Compartilhado;

public class RepositorioBase<TEntidade> where TEntidade : Entidade
{
    protected IContextoPersistencia dbContext;
    protected DbSet<TEntidade> registros;

    public RepositorioBase(IContextoPersistencia contexto)
    {
        this.dbContext = contexto;
        this.registros = ((DbContext)dbContext).Set<TEntidade>();
    }

    public bool Inserir(TEntidade registro)
    {
        registros.AddAsync(registro);
        dbContext.GravarAsync();
        return true;
    }
    
    public async Task<bool> InserirAsync(TEntidade registro)
    {
        await registros.AddAsync(registro);
        await dbContext.GravarAsync();
        return true;
    }

    public async Task Editar(TEntidade registro)
    {
        registros.Update(registro);
       await dbContext.GravarAsync();
    }

    public async Task Excluir(TEntidade registro)
    {
        registros.Remove(registro);
        await dbContext.GravarAsync();
    }

    public virtual TEntidade SelecionarPorId(Guid id)
    {
        return registros.SingleOrDefault(x => x.Id == id);
    }

    public async virtual Task<TEntidade> SelecionarPorIdAsync(Guid id)
    {
        return await registros.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async virtual Task<List<TEntidade>> SelecionarTodosAsync()
    {
        return await registros.ToListAsync();
    }
}