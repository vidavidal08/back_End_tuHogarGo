using TuHogarGO.DB;
using TuHogarGO.Entities;

namespace TuHogarGO.Repositories
{
    public class EstadoRepository : Repository<Estado>, IRepository<Estado>
    {
        public EstadoRepository(TuHogarDBContext dbContext) : base(dbContext)
        {
        }
    }
}
