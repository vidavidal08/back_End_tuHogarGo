using TuHogarGO.BL.Contracts;
using TuHogarGO.Entities;
using TuHogarGO.Repositories;

namespace TuHogarGO.BL.Implementation
{
    public class EstadoService : ServiceBase<Estado>, IEstadoService
    {
        public EstadoService(IRepository<Estado> repository) : base(repository)
        {
        }

        public IList<Estado> GetEstadoByPaisId(int id)
        {
            return _repository.Query().Where(x=>x.PaisId == id).ToList();   
        }
    }
}
