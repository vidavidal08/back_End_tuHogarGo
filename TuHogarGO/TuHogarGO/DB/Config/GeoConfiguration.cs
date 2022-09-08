using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TuHogarGO.Entities;

namespace TuHogarGO.DB.Config
{
    public class PaisConfig : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("pais").Property(x => x.Id).UseMySqlIdentityColumn();
        }
    }
    public class EstadoConfig : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("estado").Property(x => x.Id).UseMySqlIdentityColumn();
        }
    }
    public class MunicipioConfig : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.ToTable("municipio").Property(x => x.Id).UseMySqlIdentityColumn();
        }
    }
}
