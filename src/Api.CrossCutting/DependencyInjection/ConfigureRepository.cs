using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepoitory
    {
        public static void ConfigureDependenciesRepository(IServiceCollection services)
        {
            var connectionString = "Server=localhost;Port=3306;Database=consultorio;Uid=root;Pwd=14589632@Gg";

            services.AddDbContext<ConsultorioContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
        }
    }
}
