using FluentResults;
using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.Aplicacao.ModuloMedico;

public class ServicoMedico(IRepositorioMedico repositorioMedico)
{


    public async Task<Result<Medico>> InserirAsync(Medico medico)
    {
        var validator = new ValidaMedico();
        var validationResult = await validator.ValidateAsync(medico);

        if (!validationResult.IsValid)
        {
            var erros = validationResult
                .Errors
                .Select(x => x.ErrorMessage)
                .ToList();
            
            return Result.Fail(erros);
        }
        
        await repositorioMedico.InserirAsync(medico);
        
        return Result.Ok(medico);
    }

    public async Task<Result<Medico>> EditarAsync(Medico medico)
    {
        var validator = new ValidaMedico();
        var validationResult = await validator.ValidateAsync(medico);

        if (!validationResult.IsValid)
        {
            var erros = validationResult
                .Errors
                .Select(x => x.ErrorMessage)
                .ToList();
            
            return Result.Fail(erros);
        }
        repositorioMedico.Editar(medico);
        
        return Result.Ok(medico);
    }

    public async Task<Result<Medico>> ExcluirAsync(Guid id)
    {
        var medico = await repositorioMedico.SelecionarPorIdAsync(id);
        
        repositorioMedico.Excluir(medico);
        
        return Result.Ok();
    }

    public async Task<Result<List<Medico>>> SelecionarTodosAsync()
    {
        var medicos = await repositorioMedico.SelecionarTodosAsync();
        
        return Result.Ok(medicos);
    }

    public async Task<Result<Medico>> SelecionarPorIdAsync(Guid id)
    {
        var medico = await repositorioMedico.SelecionarPorIdAsync(id);
        
        return Result.Ok(medico);
    }

    public async Task<bool> IdentificarMedicosIguais(Medico medico)
    {
        var medicos = await repositorioMedico.SelecionarTodosAsync();

        return medicos.Any(medicoInserido => medico.Nome == medicoInserido.Nome && medico.Crm == medicoInserido.Crm);
    }
}