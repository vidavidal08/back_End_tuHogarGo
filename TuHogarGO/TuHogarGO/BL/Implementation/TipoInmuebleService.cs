using TuHogarGO.BL.Contracts;
using TuHogarGO.Entities;
using TuHogarGO.Repositories;

namespace TuHogarGO.BL.Implementation
{
    public class TipoInmuebleService : ServiceBase<TipoInmueble>, ITipoInmuebleService
    {
        public TipoInmuebleService(IRepository<TipoInmueble> repository) : base(repository)
        {
        }
    }
}
