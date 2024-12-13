using Api.CrossCutting.Mappings.Appointment;
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
                config.AddProfile(new DtoToModelPatientProfile());
                config.AddProfile(new EntityToDtoPatientProfile());
                config.AddProfile(new ModelToEntityPatientProfile());

                // Mapeamento de Appointment
                config.AddProfile(new DtoToModelAppointmentProfile());
                config.AddProfile(new EntityToDtoAppointmentProfile());
                config.AddProfile(new ModelToEntityAppointmentProfile());
            });
            IMapper mapper = config.CreateMapper();  // Cria o mapeador
            services.AddSingleton(mapper);  // Registra o mapeador como Singleton
        }
    }
}
