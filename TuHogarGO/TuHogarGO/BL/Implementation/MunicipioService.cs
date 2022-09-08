using TuHogarGO.BL.Contracts;
using TuHogarGO.Entities;
using TuHogarGO.Repositories;

namespace TuHogarGO.BL.Implementation
{
    public class MunicipioService : ServiceBase<Municipio>, IMunicipioService
    {
        public MunicipioService(IRepository<Municipio> repository) : base(repository)
        {
        }

        public IList<Municipio> GetMunicipiosByEstadoId(int id)
        {
            return _repository.Query().Where(x => x.EstadoId == id).ToList();
        }
    }
}
