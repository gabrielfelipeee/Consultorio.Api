using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mappings
{
    public class PatientMap : BaseMap<PatientEntity>
    {
        public PatientMap() : base("patients")
        { }

        public override void Configure(EntityTypeBuilder<PatientEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                   .HasColumnName("name")
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(x => x.Cpf)
                   .HasColumnName("cpf")
                   .HasMaxLength(11)
                   .IsRequired();
            builder.Property(x => x.Email)
                   .HasColumnName("email")
                   .HasMaxLength(100);
            builder.Property(x => x.Telephone)
                   .HasColumnName("telephone")
                   .HasMaxLength(11);
        }
    }
}
