using Microsoft.EntityFrameworkCore;
using TuHogarGO.Entities;

namespace TuHogarGO.DB
{
    public class TuHogarDBContext: DbContext
    {
        protected readonly IConfiguration Configuration;
        public TuHogarDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<TipoInmueble> TipoInmuebles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            // options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            options.UseMySQL(connectionString);
        }
    }
}