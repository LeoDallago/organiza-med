using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganizaMed.Aplicacao.ModuloAutenticacao;
using OrganizaMed.Dominio.ModuloAutenticacao;
using OrganizaMed.WebApi.Identity;
using OrganizaMed.WebApi.ViewModels;

namespace OrganizaMed.WebApi.Controllers;


[Microsoft.AspNetCore.Components.Route("api/auth")]
[ApiController]
public class AutenticacaoController(
    ServicoAutenticacao servicoAutenticacao,
    JsonWebTokenProvider jsonWebTokenProvider,
    IMapper mapper
    ) : ControllerBase
{
    private readonly ServicoAutenticacao _servicoAutenticacao = servicoAutenticacao;
    private readonly JsonWebTokenProvider _jsonWebTokenProvider = jsonWebTokenProvider;
    private readonly IMapper _mapper = mapper;

    [HttpPost("registrar")]
    public async Task<IActionResult> Registrar(RegistrarUsuarioViewModel viewModel)
    {
        var usuario = _mapper.Map<Usuario>(viewModel);
        var usuarioResult = await _servicoAutenticacao.RegistrarAsync(usuario, viewModel.Password);

        if (!usuarioResult.IsSuccess)
            return BadRequest(usuarioResult.Errors);
        
        var tokenViewModel = _jsonWebTokenProvider.GerarTokenAcesso(usuario);
        
        return Ok(tokenViewModel);
    }

    [HttpPost("autenticar")]
    public async Task<IActionResult> Autenticar(AutenticarUsuarioViewModel viewModel)
    {
        var usuarioResult = await _servicoAutenticacao.Autenticar(viewModel.UserName, viewModel.Password);
        
        if(usuarioResult.IsFailed)
            return BadRequest(usuarioResult.Errors);
        
        var usuario = usuarioResult.Value;
        
        var tokenViewModel = _jsonWebTokenProvider.GerarTokenAcesso(usuario);
        
        return Ok(tokenViewModel);
    }

    [HttpPost("sair")]
    [Authorize]
    public async Task<IActionResult> Sair()
    {
        await _servicoAutenticacao.Sair();
        return Ok();
    }
}