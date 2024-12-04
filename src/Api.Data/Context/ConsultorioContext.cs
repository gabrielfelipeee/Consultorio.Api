using Api.Data.Mappings;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class ConsultorioContext : DbContext
    {
        public ConsultorioContext(DbContextOptions<ConsultorioContext> options) : base(options)
        { }

        public DbSet<AppointmentEntity> Appointments { get; set; }
        public DbSet<SpecialtyEntity> Specialties { get; set; }
        public DbSet<PatientEntity> Patients { get; set; }
        public DbSet<ProfessionalEntity> Professionals { get; set; }
        public DbSet<ProfessionalSpecialtyEntity> ProfessionalsSpecialties { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Garante que as configurações padrões de mapeamento do sejam preservadas
            base.OnModelCreating(builder);


            builder.Entity<AppointmentEntity>(new AppointmentMap().Configure);
            builder.Entity<PatientEntity>(new PatientMap().Configure);
            builder.Entity<ProfessionalEntity>(new ProfessionalMap().Configure);
            builder.Entity<SpecialtyEntity>(new SpecialtyMap().Configure);
        }
    }
}
