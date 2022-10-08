using System.ComponentModel.DataAnnotations.Schema;

namespace TuHogarGO.Entities
{
    [Table("publicaciones")]
    public class Publicacion: EntityBase
    {
        [Column("UsuarioId")]
        public int UsuarioId { get; set; }
        [Column("titulo")]
        public string Titulo { get; set; }
        [Column("descripcion")]
        public string Descripcion { get; set; }
        [Column("TipoInmuebleId")]
        public int TipoInmuebleId { get; set; }
        [Column("precio")]
        public double Precio { get; set; }
        [Column("recamaras")]
        public int Recamaras { get; set; }
        [Column("banos")]
        public int Banos { get; set; }
        [Column("mediosBanos")]
        public int MediosBanos { get; set; }
        [Column("garage")]
        public int Garage { get; set; }
        [Column("superficieTerreno")]
        public int SuperficieTerreno { get; set; }
        [Column("superficieConstruida")]
        public int SuperficieConstruida { get; set; }
        [Column("jardin")]
        public int Jardin { get; set; }
        [Column("MunicipioId")]
        public int MunicipioId { get; set; }
    }
}
