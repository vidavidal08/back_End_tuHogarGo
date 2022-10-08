using TuHogarGO.BL.Contracts;
using TuHogarGO.Entities;
using TuHogarGO.Repositories;

namespace TuHogarGO.BL.Implementation
{
    public class PublicacionesService : ServiceBase<Publicacion>, IPublicacionesService
    {
        public PublicacionesService(IRepository<Publicacion> repository) : base(repository)
        {
        }
        public async Task<IList<Publicacion>> GetPublicacionesByUserId(int userId)
        {
            var result = new List<Publicacion>();

            result = _repository.Query().Where(x => x.UsuarioId == userId).ToList();

            return await Task.FromResult(result);
        }
        public async Task<IList<Publicacion>> GetPublicacionesByMunicipioId(int municipioId)
        {
            var result = new List<Publicacion>();

            result = _repository.Query().Where(x => x.MunicipioId == municipioId).ToList();

            return await Task.FromResult(result);
        }
        public async Task<IList<Publicacion>> GetPublicacionesByTipoInmuebleId(int tipoInmuebleId)
        {
            var result = new List<Publicacion>();

            result = _repository.Query().Where(x => x.TipoInmuebleId == tipoInmuebleId).ToList();

            return await Task.FromResult(result);
        }
    }
}
