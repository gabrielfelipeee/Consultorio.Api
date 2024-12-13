using Api.Domain.Dtos.Appointment;
using FluentValidation;

namespace Api.Service.Validators.Appointment
{
    public class AppointmentBaseValidator<T> : AbstractValidator<T> where T : AppointmentBaseDto
    
    {
        public AppointmentBaseValidator()
        {
            RuleFor(a => a.AppointmentDateTime)
              .NotEmpty()
              .WithMessage("A data é obrigatória.")
              .Must(date => date >= DateTime.Now)
              .WithMessage("A data deve ser igual ou maior que a data atual.");

            RuleFor(a => a.Status)
                .NotEmpty()
                .WithMessage("O status é obrigatório.")
                .Must(status => status == 0 || status == 1)
                .WithMessage("O status deve ser 0 (inativo) ou 1 (ativo).");

            RuleFor(a => a.Price)
                .NotEmpty()
                .WithMessage("O preço é obrigatório.")
                .GreaterThan(0)
                .WithMessage("O preço deve ser maior que zero.");

            RuleFor(a => a.PatientId)
                .GreaterThan(0)
                .WithMessage("O ID do paciente deve ser maior que zero.");

            RuleFor(a => a.SpecialtyId)
                .GreaterThan(0)
                .WithMessage("O ID da especialidade deve ser maior que zero.");

            RuleFor(a => a.ProfessionalId)
                .GreaterThan(0)
                .WithMessage("O ID do profissional deve ser maior que zero.");
        }
    }
}
