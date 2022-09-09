using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TuHogarGO.Entities;

namespace TuHogarGO.DB.Config
{
    public class TipoInmuebleConfig : IEntityTypeConfiguration<TipoInmueble>
    {
        public void Configure(EntityTypeBuilder<TipoInmueble> builder)
        {
            builder.ToTable("tipoinmueble").Property(x => x.Id).UseMySqlIdentityColumn();
        }
    }
}
