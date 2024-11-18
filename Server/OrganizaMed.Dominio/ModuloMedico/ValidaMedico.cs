using FluentValidation;

namespace OrganizaMed.Dominio.ModuloMedico;

public class ValidaMedico : AbstractValidator<Medico>
{
    public ValidaMedico()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O NOME e obrigatorio")
            .MinimumLength(2).WithMessage("O nome deve ter no minimo 2 caracteres");

        RuleFor(x => x.Telefone)
            .NotEmpty().WithMessage("O TELEFONE e obrigatorio");
        
        RuleFor(x => x.Cpf)
            .NotEmpty().WithMessage("O CPF e obrigatorio")
            .Length(11).WithMessage("O CPF deve ter 11 caracteres");
        
        RuleFor(x => x.Crm)
            .NotEmpty().WithMessage("O CRM e obrigatorio")
            .Length(7).WithMessage("O CRM deve ter 7 caracteres");
    }
}