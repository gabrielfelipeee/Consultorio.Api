using Api.Data.Context;
using Api.Data.Implementation;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepoitory
    {
        public static void ConfigureDependenciesRepository(IServiceCollection services, IConfiguration configuration)
        {
            // Registra o repositório genérico, para que qualquer tipo de entidade possa ser injetado
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IPatientRepository, PatientImplementation>();


            var connectionString = configuration.GetConnectionString("Default");

            services.AddDbContext<ConsultorioContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
        }
    }
}
