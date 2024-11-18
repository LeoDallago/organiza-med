namespace OrganizaMed.Dominio.Compartilhado;

public interface IRepositorioBase<TEntidade> where TEntidade : Entidade
{
    
    Task<bool> InserirAsync(TEntidade registro);
    
    void Editar(TEntidade registro);
    
    void Excluir(TEntidade registro);

    TEntidade SelecionarPorId(Guid id);
    
    Task<TEntidade> SelecionarPorIdAsync(Guid id);
    
    Task<IEnumerable<TEntidade>> SelecionarTodosAsync();
}