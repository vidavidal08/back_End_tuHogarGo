using TuHogarGO.BL.Contracts;
using TuHogarGO.Entities;
using TuHogarGO.Repositories;

namespace TuHogarGO.BL.Implementation
{
    public class PlanesService : ServiceBase<Plan>, IPlanesService
    {
        public PlanesService(IRepository<Plan> repository) : base(repository)
        {
        }
        public IList<Plan> GetAll()
        {
            return _repository.Query().ToList();
        }
    }
}
