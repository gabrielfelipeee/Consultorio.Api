using Api.Domain.Dtos.Appointment;
using FluentValidation;

namespace Api.Service.Validators.Appointment
{
    public class AppointmentUpdateDtoValidator : AppointmentBaseValidator<AppointmentUpdateDto>
    {
        public AppointmentUpdateDtoValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("O ID do paciente deve ser maior que 0.");
        }
    }
}
