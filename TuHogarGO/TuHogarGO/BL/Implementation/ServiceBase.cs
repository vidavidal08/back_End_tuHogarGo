using TuHogarGO.Repositories;
using TuHogarGO.Infraestructura.Validaciones;
using TuHogarGO.BL.Contracts;

namespace TuHogarGO.BL.Implementation
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : Entities.IEntityBase
    {
        protected IRepository<T> _repository;
        public ServiceBase(IRepository<T> repository)
        {
            _repository = repository;
        }
        public virtual async Task<ValidationResult> Save(T item, bool persistToDB = true)
        {
            var validationResult = new ValidationResult();
            if (item.Id != 0)
            {
                validationResult = await ValidateBeforeUpdate(item);
                if (validationResult.IsValid)
                {
                    await ExecuteBeforeUpdate(item);
                    _repository.Update(item);
                    await ExecuteAfterUpdate(item);
                }
            }
            else
            {
                validationResult = await ValidateBeforeInsert(item);
                if (validationResult.IsValid)
                {
                    await ExecuteBeforeInsert(item);
                    _repository.Create(item);
                    await ExecuteAfterInsert(item);
                }
            }
            if (persistToDB)
            {
                await _repository.SaveChangesAsync();
            }
            return validationResult;
        }
        protected virtual async Task<ValidationResult> ValidateBeforeInsert(T item)
        {
            return await Task.FromResult(new ValidationResult());
        }
        protected virtual async Task<ValidationResult> ValidateBeforeUpdate(T item)
        {
            return await Task.FromResult(new ValidationResult());
        }
        protected virtual async Task<ValidationResult> ValidateBeforeDelete(T item)
        {
            return await Task.FromResult(new ValidationResult());
        }
        protected virtual async Task<bool> ExecuteBeforeInsert(T item)
        {
            return await Task.FromResult(true);
        }
        protected virtual async Task<bool> ExecuteBeforeUpdate(T item)
        {
            return await Task.FromResult(true);
        }
        protected virtual async Task<bool> ExecuteBeforeDelete(T item)
        {
            return await Task.FromResult(true);
        }
        protected virtual async Task<bool> ExecuteAfterInsert(T item)
        {
            return await Task.FromResult(true);
        }
        protected virtual async Task<bool> ExecuteAfterUpdate(T item)
        {
            return await Task.FromResult(true);
        }
        protected virtual async Task<bool> ExecuteAfterDelete(T item)
        {
            return await Task.FromResult(true);
        }

    }
}
