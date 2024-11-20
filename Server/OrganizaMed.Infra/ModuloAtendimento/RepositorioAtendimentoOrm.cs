using Microsoft.EntityFrameworkCore;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.ModuloAtendimento;
using OrganizaMed.Infra.Compartilhado;

namespace OrganizaMed.Infra.ModuloAtendimento;

public class RepositorioAtendimentoOrm : RepositorioBase<Atendimento>, IRepositorioAtendimento
{
    public RepositorioAtendimentoOrm(IContextoPersistencia contexto) : base(contexto)
    {
    }

    public async Task<List<Atendimento>> Filtrar(Func<Atendimento, bool> predicate)
    {
        var atendimentos = await registros.ToListAsync();
        
        return atendimentos.Where(predicate).ToList();
    }
}