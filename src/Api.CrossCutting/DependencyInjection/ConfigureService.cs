using Api.Domain.Entities;
using Api.Domain.Interfaces.Services;
using Api.Service.Services;
using Api.Service.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesServices(IServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientService>();

            services.AddTransient<IValidator<PatientEntity>, PatientValidator>();
        }
    }
}
