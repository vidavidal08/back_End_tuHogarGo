using TuHogarGO.DB;
using TuHogarGO.Entities;

namespace TuHogarGO.Repositories
{
    public interface IUsuariosRepository: IRepository<Usuario>
    {
        Usuario GetUsuarioByEmail(string email);
        bool ExistsUsuarioByEmail(string email);
        IQueryable<Usuario> GetAll();
    }
    public class UsuariosRepository : Repository<Usuario>, IUsuariosRepository
    {
        public UsuariosRepository(TuHogarDBContext dbContext) : base(dbContext)
        {
        }

        public bool ExistsUsuarioByEmail(string email)
        {
            return Query().Any(x => x.Email == email);
        }

        public Usuario GetUsuarioByEmail(string email)
        {
            if(ExistsUsuarioByEmail(email))
                return Query().FirstOrDefault(x => x.Email == email);
            else return null;
        }
        public IQueryable<Usuario> GetAll()
        {
            return Query();
        }
    }
}
