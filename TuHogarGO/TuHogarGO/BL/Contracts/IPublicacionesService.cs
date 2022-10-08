using TuHogarGO.Entities;

namespace TuHogarGO.BL.Contracts
{
    public interface IPublicacionesService: IServiceBase<Publicacion>
    {
        Task<IList<Publicacion>> GetPublicacionesByMunicipioId(int municipioId);
        Task<IList<Publicacion>> GetPublicacionesByTipoInmuebleId(int tipoInmuebleId);
        Task<IList<Publicacion>> GetPublicacionesByUserId(int userId);
    }
}