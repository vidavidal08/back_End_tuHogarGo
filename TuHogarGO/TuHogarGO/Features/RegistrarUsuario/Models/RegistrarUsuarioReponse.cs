using TuHogarGO.Infraestructura.Validaciones;

namespace TuHogarGO.Features.RegistrarUsuario.Models
{
    public class RegistrarUsuarioReponse
    {
        public bool Success { get; set; }
        public int UsuarioId { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
