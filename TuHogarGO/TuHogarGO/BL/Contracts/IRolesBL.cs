using TuHogarGO.Entities;

namespace TuHogarGO.BL.Contracts
{
    public interface IRolesBL : IServiceBase<Rol>
    {
        IList<Rol> GetAll();
    }
}