using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mappings
{
    public class ProfessionalMap : BaseMap<ProfessionalEntity>
    {
        public ProfessionalMap() : base("professionals")
        { }

        public override void Configure(EntityTypeBuilder<ProfessionalEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                   .HasColumnName("name")
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(x => x.IsActive)
                   .HasColumnName("is_active")
                   .IsRequired();

            // Relacionamentos (muitos para muitos)
            builder.HasMany(x => x.Specialties) // Um Professional pode ter várias Specialties
                   .WithMany(x => x.Professionals) // Uma Specialty pode estar associada a vários Professionals
                   .UsingEntity<ProfessionalSpecialtyEntity>( // Tabela intermediária para o relacionamento

                    x => x.HasOne(p => p.Specialty) // Cada registro da tabela intermediária possui uma especialidade
                          .WithMany() // Specialty está relacionada a muitos registros na tabela intermediária
                          .HasForeignKey(x => x.SpecialtyId), // Chave estrangeira para Specialty

                    x => x.HasOne(p => p.Professional) // Cada registro da tabela intermediária possui um profissional
                          .WithMany() // Professional está relacionada a muitos registros na tabela intermediária
                          .HasForeignKey(x => x.ProfessionalId), // Chave estrangeira para Professional

                    // Configuração da tabela intermediária.
                    x =>
                    {
                        x.ToTable("professional_specialty");
                        x.HasKey(x => new { x.SpecialtyId, x.ProfessionalId }); // Chave primária composta

                        x.Property(x => x.SpecialtyId)
                         .HasColumnName("id_specialty")
                         .IsRequired();
                        x.Property(x => x.ProfessionalId)
                         .HasColumnName("id_professional")
                         .IsRequired();
                    }
                   );
        }
    }
}
