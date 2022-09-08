using AutoMapper;
using TuHogarGO.Entities;
using TuHogarGO.Models.Geo;

namespace TuHogarGO.Automapper.Profiles
{
    public class GeoProfile: Profile
    {
        public GeoProfile()
        {
            CreateMap<Pais, PaisDTO>();
            CreateMap<Estado, EstadoDTO>();
            CreateMap<Municipio, MunicipioDTO>();
            
            CreateMap<PaisDTO, Pais>();
            CreateMap<EstadoDTO, Estado>();
            CreateMap<MunicipioDTO, Municipio>();
        }
    }
}
