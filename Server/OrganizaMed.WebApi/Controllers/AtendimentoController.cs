using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganizaMed.Aplicacao.ModuloAtendimento;
using OrganizaMed.Dominio.ModuloAtendimento;
using OrganizaMed.WebApi.ViewModels;

namespace OrganizaMed.WebApi.Controllers;

[Route("api/atendimentos")]
[ApiController]
public class AtendimentoController(ServicoAtendimento servicoAtendimento, IMapper mapper) : ControllerBase
{
   [HttpGet]
   public async Task<IActionResult> Get()
   {
      var resultado = await servicoAtendimento.SelecionarTodosAsync();

      var viewModel = mapper.Map<ListarAtendimentoViewModel[]>(resultado.Value);
      
      return Ok(viewModel);
   }

   [HttpGet("{id:guid}")]
   public async Task<IActionResult> GetById(Guid id)
   {
      var resultado = await servicoAtendimento.SelecionarPorIdAsync(id);
      
      if (resultado.IsFailed)
         return StatusCode(500);
          
      else if (resultado.IsSuccess && resultado.Value is null)
         return NotFound(resultado.Errors);
        
      var viewModel = mapper.Map<VisualizarAtendimentoViewModel>(resultado.Value);
        
      return Ok(viewModel);
   }

   [HttpPost]
   public async Task<IActionResult> Post(InserirAtendimentoViewModel inserirAtendimentoViewModel)
   {
      var atendimento = mapper.Map<Atendimento>(inserirAtendimentoViewModel);
      
      var resultado = await servicoAtendimento.InserirAsync(atendimento);
      
      if(resultado.IsFailed)
         return BadRequest(resultado.Errors);
      
      return Ok(inserirAtendimentoViewModel);
   }

   [HttpPut("{id:guid}")]
   public async Task<IActionResult> Put(Guid id, EditarAtendimentoViewModel editarAtendimentoViewModel)
   {
      var atendimentoSelecionado = await servicoAtendimento.SelecionarPorIdAsync(id);
      if (atendimentoSelecionado.IsFailed)
         return NotFound(atendimentoSelecionado.Errors);
      
      var atendimento = mapper.Map(editarAtendimentoViewModel, atendimentoSelecionado.Value);
      var resultado = await servicoAtendimento.EditarAsync(atendimento);
      
      if(resultado.IsFailed)
         return BadRequest(resultado.Errors);
      
      return Ok(resultado);
   }

   [HttpDelete("{id:guid}")]
   public async Task<IActionResult> Delete(Guid id)
   {
      var atendimento = await servicoAtendimento.ExcluirAsync(id);
      if(atendimento.IsFailed)
         return BadRequest(atendimento.Errors);
        
      return Ok();
   }
}