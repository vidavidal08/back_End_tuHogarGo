using TuHogarGO.Entities;
using TuHogarGO.Infraestructura.Validaciones;

namespace TuHogarGO.BL.Contracts
{
    public interface IServiceBase<T> where T : IEntityBase
    {
        Task<ValidationResult> Save(T item, bool persistToDB = true);
        IList<T> GetAll();
        T GetById(int Id);
    }
}