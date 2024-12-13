using Api.Service.Services.Validations;
using Api.Service.Validators.Appointment;
using Api.Service.Validators.Patient;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureFluentValidation
    {
        public static void ConfigureDependenciesConfigureFluentValidation(IServiceCollection services)
        {
            services.AddScoped<AppointmentValidationService>();

            // Registra validadores do FluentValidation automaticamente com base nos tipos encontrados no mesmo assembly
            services.AddValidatorsFromAssemblyContaining<PatientCreateDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<PatientUpdateDtoValidator>();

            services.AddValidatorsFromAssemblyContaining<AppointmentCreateDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<AppointmentUpdateDtoValidator>();
        }
    }
}
