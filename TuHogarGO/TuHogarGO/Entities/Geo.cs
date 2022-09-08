using System.ComponentModel.DataAnnotations.Schema;

namespace TuHogarGO.Entities
{
    [Table("pais")]
    public class Pais : EntityBase
    {
        public string Nombre { get; set; }
        public ICollection<Estado> Estados { get; set; }
    }
    [Table("estado")]
    public class Estado : EntityBase
    {
        public string Nombre { get; set; }
        public int PaisId { get; set; }
        public Pais Pais { get; set; }
        public ICollection<Municipio> Municipios { get; set; }
    }
    [Table("municipio")]
    public class Municipio: EntityBase
    {
        public string Nombre { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
    }
}
