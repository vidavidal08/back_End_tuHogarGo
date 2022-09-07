namespace TuHogarGO.DB.Config
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TuHogarGO.Entities;
    public class PlanesConfig : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.ToTable("planes").Property(x => x.Id).UseMySqlIdentityColumn();
        }
    }
}
