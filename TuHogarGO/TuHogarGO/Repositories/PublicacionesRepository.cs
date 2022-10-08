using TuHogarGO.DB;
using TuHogarGO.Entities;

namespace TuHogarGO.Repositories
{
    public class PublicacionesRepository : Repository<Publicacion>, IRepository<Publicacion>
    {
        public PublicacionesRepository(TuHogarDBContext dbContext) : base(dbContext)
        {
        }
    }
}