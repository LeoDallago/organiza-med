using Microsoft.EntityFrameworkCore;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.Infra.Compartilhado;

namespace OrganizaMed.Infra.ModuloMedico;

public class RepositorioMedicoOrm : RepositorioBase<Medico>, IRepositorioMedico
{
    public RepositorioMedicoOrm(IContextoPersistencia contexto) : base(contexto)
    {
    }

    public override async Task<Medico> SelecionarPorIdAsync(Guid id)
    {
        return  registros.SingleOrDefault(x =>x.Id == id);
    }

    public Task<IEnumerable<Medico>> SelecionarTodosAsync()
    {
        throw new NotImplementedException();
    }

    
    public override Medico SelecionarPorId(Guid id)
    {
        return  registros.SingleOrDefault(x =>x.Id == id);
    }
    
    public async Task<List<Medico>> Filtrar(Func<Medico, bool> predicate)
    {
        var medicos = await registros.ToListAsync();
        
        return medicos.Where(predicate).ToList();
    }
}