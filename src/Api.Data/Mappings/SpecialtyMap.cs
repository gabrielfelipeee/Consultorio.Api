using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mappings
{
    public class SpecialtyMap : BaseMap<SpecialtyEntity>
    {
        public SpecialtyMap() : base("specialties")
        { }

        public override void Configure(EntityTypeBuilder<SpecialtyEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                   .HasColumnName("name")
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(x => x.IsActive)
                   .HasColumnName("is_active");
        }
    }
}
