using Api.CrossCutting.DependencyInjection;
using Api.CrossCutting.Middleware;

namespace Api.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            {
                //  vai ignorar essas referências cíclicas e não causar uma exceção ou um loop infinito
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

                // Configura o serializador para ignorar qualquer propriedade que tenha o valor null
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            // Configurações de injeção de dependências
            ConfigureRepoitory.ConfigureDependenciesRepository(builder.Services);
            ConfigureService.ConfigureDependenciesServices(builder.Services);
            ConfigureAutoMapper.ConfigureDependenciesAutoMapper(builder.Services);
            ConfigureFluentValidation.ConfigureDependenciesConfigureFluentValidation(builder.Services);

            builder.Logging.AddConsole();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.MapControllers();

            app.UseMiddleware<ControllerExceptionMiddleware>();

            app.Run();
        }
    }
}
