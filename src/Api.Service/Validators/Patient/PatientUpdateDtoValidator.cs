using Api.Domain.Dtos.Patient;
using FluentValidation;

namespace Api.Service.Validators.Patient
{
    public class PatientUpdateDtoValidator : PatientBaseValidator<PatientUpdateDto>
    {
        public PatientUpdateDtoValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("O ID do paciente deve ser maior que 0.");
        }
    }
}
