using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mappings
{
    public class AppointmentMap : BaseMap<AppointmentEntity>
    {
        public AppointmentMap() : base("appointments")
        { }

        // Sobrescreve o método Configure da classe BaseMap para aplicar configurações específicas da entidade.
        public override void Configure(EntityTypeBuilder<AppointmentEntity> builder)
        {
            // Chama o método Configure da classe base para aplicar o mapeamento genérico
            base.Configure(builder);

            builder.Property(x => x.ApppointmentDateTime)
                   .HasColumnName("appointment_datetime");
            builder.Property(x => x.Status)
                   .HasColumnName("status")
                   .HasDefaultValue(1);
            builder.Property(x => x.Price)
                   .HasColumnName("price")
                   .HasPrecision(7, 2); // Pode armazenar 7 até digitos, e 2 à direita da vírgula

            // Relacionamentos (muitos para um)
            builder.Property(x => x.PatientId)
                   .HasColumnName("id_patient")
                   .IsRequired();
            builder.HasOne(x => x.Patient) // Uma consulta tem um paciente
                   .WithMany(x => x.Appointments) // Um pacinte pode ter várias consultas
                   .HasForeignKey(x => x.PatientId);

            builder.Property(x => x.ProfessionalId)
                    .HasColumnName("id_professional")
                    .IsRequired();
            builder.HasOne(x => x.Professional)
                   .WithMany(x => x.Appointments)
                   .HasForeignKey(x => x.ProfessionalId);

            builder.Property(x => x.SpecialtyId)
                    .HasColumnName("id_specialty")
                    .IsRequired();
            builder.HasOne(x => x.Specialty)
                   .WithMany(x => x.Appointments)
                   .HasForeignKey(x => x.SpecialtyId);
        }
    }
}
