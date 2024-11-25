using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganizaMed.Aplicacao.ModuloMedico;
using OrganizaMed.Dominio.ModuloAutenticacao;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.WebApi.ViewModels;

namespace OrganizaMed.WebApi.Controllers;


[Route("api/medicos")]
[ApiController]
[Authorize]
public class MedicoController(ServicoMedico servicoMedico, IMapper mapper, ITenantProvider tenantProvider) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var resultado = await servicoMedico.SelecionarTodosAsync();
        
        var viewModel = mapper.Map<ListarMedicoViewModel[]>(resultado.Value);
        
        return Ok(viewModel);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var resultado = await servicoMedico.SelecionarPorIdAsync(id);
        
        if (resultado.IsFailed)
            return StatusCode(500);
          
        else if (resultado.IsSuccess && resultado.Value is null)
            return NotFound(resultado.Errors);
        
        var viewModel = mapper.Map<VisualizarMedicoViewModel>(resultado.Value);
        
        return Ok(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post(InserirMedicoViewModel inserirMedicoViewModel)
    {
        
        var medico = mapper.Map<Medico>(inserirMedicoViewModel);
        medico.UsuarioId = tenantProvider.UsuarioId.GetValueOrDefault();

        if (await servicoMedico.IdentificarMedicosIguais(medico))
            return BadRequest("Medico ja inserido!");
        
        
        var resultado = await servicoMedico.InserirAsync(medico);

        if (resultado.IsFailed)
        {
            return BadRequest(resultado.Errors);
        }
        
        return Ok(inserirMedicoViewModel);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, EditarMedicoViewModel editarMedicoViewModel)
    {
        var medicoSelecionado = await servicoMedico.SelecionarPorIdAsync(id);
        if(medicoSelecionado.IsFailed)
            return NotFound(medicoSelecionado.Errors);
        
        var medico = mapper.Map(editarMedicoViewModel, medicoSelecionado.Value);
        var resultado = await servicoMedico.EditarAsync(medico);
        
        if(resultado.IsFailed)
            return BadRequest(resultado.Errors);
        
        return Ok(resultado);

    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var medico = await servicoMedico.ExcluirAsync(id);
        if(medico.IsFailed)
            return BadRequest(medico.Errors);
        
        return Ok();
    }
}