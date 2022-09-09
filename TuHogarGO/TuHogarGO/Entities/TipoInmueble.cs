using System.ComponentModel.DataAnnotations.Schema;

namespace TuHogarGO.Entities
{
    [Table("tipoinmueble")]
    public class TipoInmueble: EntityBase
    {
        public string Nombre { get; set; }
    }
}
