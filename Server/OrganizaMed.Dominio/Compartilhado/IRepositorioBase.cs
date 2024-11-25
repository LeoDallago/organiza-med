namespace OrganizaMed.Dominio.Compartilhado;

public interface IRepositorioBase<TEntidade> where TEntidade : Entidade
{
    
    Task<bool> InserirAsync(TEntidade registro);
    
    Task Editar(TEntidade registro);
    
    Task Excluir(TEntidade registro);

    TEntidade SelecionarPorId(Guid id);
    
    Task<TEntidade> SelecionarPorIdAsync(Guid id);
    
    Task<List<TEntidade>> SelecionarTodosAsync();
}