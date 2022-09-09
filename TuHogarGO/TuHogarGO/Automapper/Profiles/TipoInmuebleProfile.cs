using AutoMapper;
using TuHogarGO.Entities;
using TuHogarGO.Models;

namespace TuHogarGO.Automapper.Profiles
{
    public class TipoInmuebleProfile: Profile
    {
        public TipoInmuebleProfile()
        {
            CreateMap<TipoInmueble, TipoInmuebleDTO>();
            CreateMap<TipoInmuebleDTO, TipoInmueble>();
        }
    }
}
