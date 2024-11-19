using OrganizaMed.Dominio.Compartilhado;

namespace OrganizaMed.Dominio.ModuloAtendimento;

public interface IRepositorioAtendimento : IRepositorioBase<Atendimento>
{
    Task<List<Atendimento>> Filtrar(Func<Atendimento, bool> predicate);
}