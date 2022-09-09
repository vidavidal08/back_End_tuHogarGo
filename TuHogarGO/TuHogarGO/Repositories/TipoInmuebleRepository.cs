using TuHogarGO.DB;
using TuHogarGO.Entities;

namespace TuHogarGO.Repositories
{
    public class TipoInmuebleRepository : Repository<TipoInmueble>, IRepository<TipoInmueble>
    {
        public TipoInmuebleRepository(TuHogarDBContext dbContext) : base(dbContext)
        {
        }
    }
}
