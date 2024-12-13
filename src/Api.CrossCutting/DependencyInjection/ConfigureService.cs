using Api.Domain.Dtos.Appointment;
using Api.Domain.Dtos.Patient;
using Api.Domain.Interfaces.Services;
using Api.Service.Services;
using Api.Service.Services.Validations;
using Api.Service.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesServices(IServiceCollection services)
        {
            // Registra o serviço de paciente com escopo (instância única por requisição)
            services.AddScoped<IPatientService, PatientService>();

            services.AddScoped<IAppointmentService, AppointmentService>();


            // Serviços de validação

            services.AddScoped(typeof(EntityValidationService<>)); 

            services.AddScoped<EntityFluentValidationService<PatientCreateDto, PatientUpdateDto>>();

            services.AddScoped<EntityFluentValidationService<AppointmentCreateDto, AppointmentUpdateDto>>();
            services.AddScoped<AppointmentValidationService>();

        }
    }
}
