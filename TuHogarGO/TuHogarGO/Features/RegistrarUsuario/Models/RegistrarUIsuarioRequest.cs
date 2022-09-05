namespace TuHogarGO.Features.RegistrarUsuario.Models
{
    public class RegistrarUsuarioRequest:MediatR.IRequest<RegistrarUsuarioReponse>
    {
        public int RolId { get; set; }
        public int PlanId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int PaisId { get; set; }
        public int EstadoId { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
    }
}
