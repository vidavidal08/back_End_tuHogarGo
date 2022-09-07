using TuHogarGO.DB;
using TuHogarGO.Entities;

namespace TuHogarGO.Repositories
{
    public class PlanesRepository : Repository<Plan>, IRepository<Plan>
    {
        public PlanesRepository(TuHogarDBContext dbContext) : base(dbContext)
        {
        }
    }
}
