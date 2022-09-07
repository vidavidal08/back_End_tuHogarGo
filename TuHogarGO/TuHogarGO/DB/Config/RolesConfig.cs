using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TuHogarGO.Entities;

namespace TuHogarGO.DB.Config
{
    public class RolesConfig : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("roles").Property( x => x.Id).UseMySqlIdentityColumn();
        }
    }
}
