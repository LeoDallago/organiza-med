using FluentValidation;

namespace OrganizaMed.Dominio.ModuloAtendimento;

public class ValidaAtendimento : AbstractValidator<Atendimento>
{
    public ValidaAtendimento()
    {
        RuleFor(x => x.Tipo)
            .NotEmpty().WithMessage("O TIPO de consulta é ser obrigatorio");
        RuleFor(x => x.MedicoId)
            .NotEmpty().WithMessage("0 MEDICO responsavel é ser obrigatorio");
        RuleFor(x => x.HoraInicio)
            .NotEmpty().WithMessage("O HORARIO DE INICIO é ser obrigatorio");
        RuleFor(x => x.HoraFim)
            .NotEmpty().WithMessage("O HORARIO DE TERMINO é ser obrigatorio");
    }
}