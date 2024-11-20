using FluentValidation;

namespace OrganizaMed.Dominio.ModuloAtendimento;

public class ValidaAtendimento : AbstractValidator<Atendimento>
{
    public ValidaAtendimento()
    {
        RuleFor(x => x.Tipo)
            .NotEmpty().WithMessage("O TIPO de consulta deve ser obrigatorio");
        RuleFor(x => x.Medico)
            .NotEmpty().WithMessage("0 MEDICO responsavel deve ser obrigatorio");
        RuleFor(x => x.HoraInicio)
            .NotEmpty().WithMessage("O HORARIO DE INICIO deve ser obrigatorio");
        RuleFor(x => x.HoraFim)
            .NotEmpty().WithMessage("O HORARIO DE TERMINO deve ser obrigatorio");
    }
}