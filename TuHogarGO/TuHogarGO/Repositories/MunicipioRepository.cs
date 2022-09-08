using TuHogarGO.DB;
using TuHogarGO.Entities;

namespace TuHogarGO.Repositories
{
    public class MunicipioRepository : Repository<Municipio>, IRepository<Municipio>
    {
        public MunicipioRepository(TuHogarDBContext dbContext) : base(dbContext)
        {
        }
    }
}
