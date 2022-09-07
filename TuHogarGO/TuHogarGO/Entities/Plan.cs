using System.ComponentModel.DataAnnotations.Schema;

namespace TuHogarGO.Entities
{
    [Table("planes")]
    public class Plan: IEntityBase
    {
        [Column("idPlan")]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        [Column("dias_duracion")]
        public int DiasDuracion { get; set; }
        public string Precio { get; set; }
    }
}
