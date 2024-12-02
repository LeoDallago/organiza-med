using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.Dominio.ModuloAtendimento;

public class Atendimento : Entidade
{
    public string Tipo { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFim { get; set; }
    
    public Guid MedicoId { get; set; }
    public Medico?  Medico { get; set; }

    public Atendimento()
    {
        
    }

    public Atendimento(string tipo, TimeSpan horaInicio, TimeSpan horaFim, Guid medicoId, Medico? medico)
    {
        Tipo = tipo;
        HoraInicio = horaInicio;
        HoraFim = horaFim;
        MedicoId = medicoId;
        Medico = medico;
    }


    public bool ValidarHorario(TimeSpan horaInicio, TimeSpan horaFim)
    {
        if(horaInicio > horaFim)
            return true;
        
        return false;
    }
}