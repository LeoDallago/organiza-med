using AutoMapper;
using OrganizaMed.Dominio.ModuloAtendimento;
using OrganizaMed.WebApi.ViewModels;

namespace OrganizaMed.WebApi.Config.Mapping;

public class AtendimentoProfile : Profile
{
    public AtendimentoProfile()
    {
        CreateMap<Atendimento, ListarAtendimentoViewModel>()
            .ForMember(dest => dest.Medico,
                opt => opt.MapFrom(src => src.Medico.Nome));
        CreateMap<Atendimento, VisualizarAtendimentoViewModel>();

        CreateMap<InserirAtendimentoViewModel, Atendimento>();
        CreateMap<EditarAtendimentoViewModel, Atendimento>();
    }
}