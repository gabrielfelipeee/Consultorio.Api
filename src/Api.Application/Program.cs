using Api.CrossCutting.DependencyInjection;

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
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            // Configurações de injeção de dependências
            ConfigureRepoitory.ConfigureDependenciesRepository(builder.Services);
            ConfigureService.ConfigureDependenciesServices(builder.Services);
            ConfigureAutoMapper.ConfigureDependenciesAutoMapper(builder.Services);
            ConfigureFluentValidation.ConfigureDependenciesConfigureFluentValidation(builder.Services);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.MapControllers();

            app.Run();
        }
    }
}
