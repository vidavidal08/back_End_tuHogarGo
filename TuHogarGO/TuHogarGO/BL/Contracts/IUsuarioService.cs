using TuHogarGO.Entities;
using TuHogarGO.Models.Auth;

namespace TuHogarGO.BL.Contracts
{
    public interface IUsuarioService: IServiceBase<Usuario>
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
    }
}
