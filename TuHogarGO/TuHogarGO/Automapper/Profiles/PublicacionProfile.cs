using AutoMapper;
using TuHogarGO.Entities;
using TuHogarGO.Models;

namespace TuHogarGO.Automapper.Profiles
{
    public class PublicacionProfile : Profile
    {
        public PublicacionProfile()
        {
            CreateMap<Publicacion, PublicacionDTO>();
            CreateMap<PublicacionDTO, Publicacion>();
        }
    }
}
