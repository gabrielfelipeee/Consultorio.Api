using Api.Data.Context;
using Api.Data.Implementation;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepoitory
    {
        public static void ConfigureDependenciesRepository(IServiceCollection services)
        {
            // Registra o repositório genérico, para que qualquer tipo de entidade possa ser injetado
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IPatientRepository, PatientImplementation>();



            var connectionString = "Server=localhost;Port=3306;Database=consultorio;Uid=root;Pwd=14589632@Gg";

            services.AddDbContext<ConsultorioContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
        }
    }
}
