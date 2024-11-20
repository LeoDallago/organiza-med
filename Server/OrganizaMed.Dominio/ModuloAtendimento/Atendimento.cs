using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.Dominio.ModuloAtendimento;

public class Atendimento : Entidade
{
    public string Tipo { get; set; }
    public DateTime HoraInicio { get; set; }
    public DateTime HoraFim { get; set; }
    public Medico  Medico { get; set; }

    public Atendimento()
    {
        
    }

    public Atendimento(string tipo, DateTime horaInicio, DateTime horaFim, Medico medico)
    {
        Tipo = tipo;
        HoraInicio = horaInicio;
        HoraFim = horaFim;
        this.Medico = medico;
    }
}