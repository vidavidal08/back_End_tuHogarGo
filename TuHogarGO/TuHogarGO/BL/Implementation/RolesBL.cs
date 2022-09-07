using TuHogarGO.BL.Contracts;
using TuHogarGO.Entities;
using TuHogarGO.Repositories;

namespace TuHogarGO.BL.Implementation
{
    public class RolesBL : ServiceBase<Rol>, IRolesBL
    {
        public RolesBL(IRepository<Rol> repository) : base(repository)
        {
        }
        public IList<Rol> GetAll()
        {
            return _repository.Query().ToList();
        }
    }
}
