namespace TuHogarGO.DB.Config
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TuHogarGO.Entities;
    public class PublicacionConfig : IEntityTypeConfiguration<Publicacion>
    {
        public void Configure(EntityTypeBuilder<Publicacion> builder)
        {
            builder.ToTable("publicaciones").Property(x => x.Id).UseMySqlIdentityColumn();
        }
    }
}
