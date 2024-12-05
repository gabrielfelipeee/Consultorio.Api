using Api.Domain.Entities;
using Api.Service.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesServices(IServiceCollection services)
        {
            services.AddTransient<IValidator<PatientEntity>, PatientValidator>();
        }
    }
}
