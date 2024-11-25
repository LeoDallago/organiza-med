using FluentResults;
using OrganizaMed.Dominio.ModuloAtendimento;

namespace OrganizaMed.Aplicacao.ModuloAtendimento;

public class ServicoAtendimento(IRepositorioAtendimento repositorioAtendimento)
{
    public async Task<Result<Atendimento>> InserirAsync(Atendimento atendimento)
    {
        var validator = new ValidaAtendimento();
        var validationResult = await validator.ValidateAsync(atendimento);

        if (!validationResult.IsValid)
        {
            var erros = validationResult
                .Errors
                .Select(x => x.ErrorMessage)
                .ToList();
            
            return Result.Fail(erros);
        }

        if (!atendimento.ValidarHorario(atendimento.HoraInicio, atendimento.HoraFim))
            return Result.Fail("Horario invalido");
        
        await repositorioAtendimento.InserirAsync(atendimento);
        
        return Result.Ok(atendimento);
    }

    public async Task<Result<Atendimento>> EditarAsync(Atendimento atendimento)
    {
        var validator = new ValidaAtendimento();
        var validationResult = await validator.ValidateAsync(atendimento);

        if (!validationResult.IsValid)
        {
            var erros = validationResult
                .Errors
                .Select(x => x.ErrorMessage)
                .ToList();
            
            return Result.Fail(erros);
        }
        
        await repositorioAtendimento.Editar(atendimento);
        
        return Result.Ok(atendimento);
    }

    public async Task<Result<Atendimento>> ExcluirAsync(Guid id)
    {
        var atendimento = await repositorioAtendimento.SelecionarPorIdAsync(id);
        
        await repositorioAtendimento.Excluir(atendimento);
        
        return Result.Ok();
    }

    public async Task<Result<List<Atendimento>>> SelecionarTodosAsync()
    {
        var atendimentos = await repositorioAtendimento.SelecionarTodosAsync();
        
        return Result.Ok(atendimentos);
    }

    public async Task<Result<Atendimento>> SelecionarPorIdAsync(Guid id)
    {
        var atendimento = await repositorioAtendimento.SelecionarPorIdAsync(id);
        
        return Result.Ok(atendimento);
    }
}