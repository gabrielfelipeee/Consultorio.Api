using Api.Domain.Dtos.Patient;
using FluentValidation;

namespace Api.Service.Validators
{
    public class PatientBaseValidator<T> : AbstractValidator<T> where T : PatientBaseDto
    {
        public PatientBaseValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O nome do paciente é obrigatório.")
                .MinimumLength(3).WithMessage("O nome deve ter pelo menos 3 caracteres.")
                .MaximumLength(100).WithMessage("O nome pode ter no máximo 100 caracteres.");

            RuleFor(p => p.Cpf)
                .NotEmpty().WithMessage("O CPF do paciente é obrigatório.")
                .Length(11).WithMessage("O CPF fornecido não é válido.")
                .Matches(@"^\d{11}$").WithMessage("O CPF deve conter apenas números.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("O email do paciente é obrigatório.")
                .EmailAddress().WithMessage("O formato do email é inválido.")
                .MaximumLength(100).WithMessage("O email pode ter no máximo 100 caracteres");

            RuleFor(p => p.Telephone)
                .NotEmpty().WithMessage("O telefone do paciente é obrigatório.")
                .Matches(@"^\d{10,11}$").WithMessage("O formato do telefone é inválido.");
        }
    }
}
