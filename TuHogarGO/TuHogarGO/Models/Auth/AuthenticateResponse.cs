using TuHogarGO.Entities;

namespace TuHogarGO.Models.Auth
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Usuario user, string token)
        {
            Id = user.Id;
            Nombre = user.Nombre;
            Apellidos = user.Apellidos;
            Email = user.Email;
            Token = token;
        }

    }
}
