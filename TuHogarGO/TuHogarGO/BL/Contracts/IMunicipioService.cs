using TuHogarGO.Entities;

namespace TuHogarGO.BL.Contracts
{
    public interface IMunicipioService: IServiceBase<Municipio>
    {
        IList<Municipio> GetMunicipiosByEstadoId(int id);
    }
}