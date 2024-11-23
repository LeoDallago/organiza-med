using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.WebApi.ViewModels;

public class ListarAtendimentoViewModel
{
    public Guid Id { get; set; }
    public string Tipo { get; set; }
    
    public string Medico{ get; set; }
}

public class VisualizarAtendimentoViewModel
{
    public Guid Id { get; set; }
    public string Tipo { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFim { get; set; }
    
    public ListarMedicoViewModel Medico { get; set; }
}

public class InserirAtendimentoViewModel
{
    public string Tipo { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFim { get; set; }
    public Guid MedicoId { get; set; }
}

public class EditarAtendimentoViewModel : InserirAtendimentoViewModel {}