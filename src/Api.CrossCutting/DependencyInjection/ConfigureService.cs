using Api.Domain.Interfaces.Services;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesServices(IServiceCollection services)
        {
            // Registra o serviço de paciente com escopo (instância única por requisição)
            services.AddScoped<IPatientService, PatientService>();
        }
    }
}
