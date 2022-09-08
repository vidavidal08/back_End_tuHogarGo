using TuHogarGO.Entities;

namespace TuHogarGO.BL.Contracts
{
    public interface IEstadoService: IServiceBase<Estado>
    {
        IList<Estado> GetEstadoByPaisId(int id);
    }
}