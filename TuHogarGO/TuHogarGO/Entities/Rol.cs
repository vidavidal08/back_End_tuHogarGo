using System.ComponentModel.DataAnnotations.Schema;

namespace TuHogarGO.Entities
{
    [Table("roles")]
    public class Rol: IEntityBase
    {
        [Column("idRole")]
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
