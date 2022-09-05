using AutoMapper;
using TuHogarGO.Entities;
using TuHogarGO.Features.RegistrarUsuario.Models;

namespace TuHogarGO.Automapper.Profiles
{
    public class RegistrarUsuarioProfile:Profile
    {
        public RegistrarUsuarioProfile()
        {
            CreateMap<RegistrarUsuarioRequest, Usuario>();
        }
    }
}
