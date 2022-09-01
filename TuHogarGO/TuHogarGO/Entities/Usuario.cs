using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TuHogarGO.Entities
{
    [Table("usuarios")]
    public class Usuario
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public int PlanId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int PaisId { get; set; }
        public int EstadoId { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Pass { get; set; }
    }
}
