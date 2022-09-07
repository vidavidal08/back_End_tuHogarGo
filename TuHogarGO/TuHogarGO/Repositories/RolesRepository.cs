using TuHogarGO.DB;
using TuHogarGO.Entities;

namespace TuHogarGO.Repositories
{
    public class RolesRepository : Repository<Rol>, IRepository<Rol>
    {
        public RolesRepository(TuHogarDBContext dbContext) : base(dbContext)
        {
        }
    }
}
