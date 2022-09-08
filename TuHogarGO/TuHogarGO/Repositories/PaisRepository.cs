using TuHogarGO.DB;
using TuHogarGO.Entities;

namespace TuHogarGO.Repositories
{
    public class PaisRepository : Repository<Pais>, IRepository<Pais>
    {
        public PaisRepository(TuHogarDBContext dbContext) : base(dbContext)
        {
        }
    }
}
