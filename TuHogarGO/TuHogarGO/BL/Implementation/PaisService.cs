using TuHogarGO.BL.Contracts;
using TuHogarGO.Entities;
using TuHogarGO.Repositories;

namespace TuHogarGO.BL.Implementation
{
    public class PaisService : ServiceBase<Pais>, IPaisService
    {
        public PaisService(IRepository<Pais> repository) : base(repository)
        {
        }
    }
}
