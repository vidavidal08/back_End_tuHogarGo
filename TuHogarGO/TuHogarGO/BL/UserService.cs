using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TuHogarGO.Entities;
using TuHogarGO.Infraestructura.Config;
using TuHogarGO.Models.Auth;
using TuHogarGO.Repositories;

namespace TuHogarGO.BL
{
    public interface IUsuarioService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
    }
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuariosRepository _usuariosRepository;

        private readonly AppSettings _appSettings;
        public UsuarioService(IOptions<AppSettings> appSettings, IUsuariosRepository usuariosRepository)
        {
            _appSettings = appSettings.Value;
            _usuariosRepository = usuariosRepository;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _usuariosRepository.Query().FirstOrDefault(x => x.Email == model.Email && x.Pass == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<Usuario> GetAll()
        {
           
               var  _users = _usuariosRepository.GetAll().ToList();
            
            return _users;
        }

        public Usuario GetById(int id)
        {
            return _usuariosRepository.Find(id);
        }
        private string generateJwtToken(Usuario user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(type:"id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
