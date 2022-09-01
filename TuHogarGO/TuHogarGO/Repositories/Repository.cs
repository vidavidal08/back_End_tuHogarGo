using System.Data.Entity;
using TuHogarGO.DB;

namespace TuHogarGO.Repositories
{
    public interface IRepository<T>
    {
        public T Find(int Id);
        IQueryable<T> Query();
        void Create(T entity);
        T Read(object keys);
        void Update(T entity);
        void Delete(T entity);
    }
    public abstract class Repository<T> where T : class
    {
        protected TuHogarDBContext _dbContext;
        public Repository(TuHogarDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public T Find(int Id)
        {
            var item = _dbContext.Find<T>(Id);
            return item;
        }
        public virtual IQueryable<T> Query()
        {
            return _dbContext.Set<T>();
        }

        public virtual void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public virtual T Read(object keys)
        {
            return _dbContext.Set<T>().Find(keys);
        }

        public virtual void Update(T entity)
        {
            _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
        public virtual void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public virtual async Task<int> SaveChangesAsync()
        {
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
