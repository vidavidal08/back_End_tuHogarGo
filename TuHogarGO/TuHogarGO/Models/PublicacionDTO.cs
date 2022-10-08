namespace TuHogarGO.Models
{
    public class PublicacionDTO
    {
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int TipoInmuebleId { get; set; }
        public double Precio { get; set; }
        public int Recamaras { get; set; }
        public int Banos { get; set; }
        public int MediosBanos { get; set; }
        public int Garage { get; set; }
        public int SuperficieTerreno { get; set; }
        public int SuperficieConstruida { get; set; }
        public int Jardin { get; set; }
        public int MunicipioId { get; set; }
    }
}