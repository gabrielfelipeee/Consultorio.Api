using Api.CrossCutting.Mappings.Patient;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureAutoMapper
    {
        public static void ConfigureDependenciesAutoMapper(IServiceCollection services)
        {
            // Configurações do AutoMapper
            var config = new MapperConfiguration(config =>
            {
                // Mapeamento de Patient
                config.AddProfile(new DtoToModelProfile());
                config.AddProfile(new EntityToDtoProfile());
                config.AddProfile(new ModelToEntityProfile());
            });
            IMapper mapper = config.CreateMapper();  // Cria o mapeador
            services.AddSingleton(mapper);  // Registra o mapeador como Singleton
        }
    }
}
