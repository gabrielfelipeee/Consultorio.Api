using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<ConsultorioContext>
    {
        public ConsultorioContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Port=3306;Database=consultorio;Uid=root;Pwd=14589632@Gg";

            var optionsBuilder = new DbContextOptionsBuilder<ConsultorioContext>();

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return new ConsultorioContext(optionsBuilder.Options);
        }
    }
}
