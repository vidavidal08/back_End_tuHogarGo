using AutoMapper;
using TuHogarGO.BL.Contracts;
using TuHogarGO.Entities;
using TuHogarGO.Features.RegistrarUsuario.Models;
using TuHogarGO.Infraestructura.Validaciones;

namespace TuHogarGO.Features.RegistrarUsuario.Command
{
    public class RegistrarUsuarioCommand : MediatR.RequestHandler<RegistrarUsuarioRequest, RegistrarUsuarioReponse>
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;
        public RegistrarUsuarioCommand(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }
        protected override RegistrarUsuarioReponse Handle(RegistrarUsuarioRequest request)
        {
            var response = new RegistrarUsuarioReponse();
            response.ValidationResult = ValidateRequest(request);

            if(response.ValidationResult.IsValid)
            {
                var usuario = _mapper.Map<RegistrarUsuarioRequest, Usuario>(request);
                try
                {
                    response.ValidationResult = _usuarioService.Save(usuario).Result;
                }
                catch(Exception ex)
                {
                    response.Success = false;
                    response.ValidationResult.Errors.Add(new ValidationResultItem("Exception", ex.Message));
                }
            }

            return response;
        }
        private ValidationResult ValidateRequest(RegistrarUsuarioRequest request)
        {
            var response = new ValidationResult();

            if (request == null)
            {
                response.Errors.Add(new ValidationResultItem("Request", "Es necesario llenar los datos de regsitro."));
                return response;
            }
            if(string.IsNullOrEmpty(request.Email))
            {
                response.Errors.Add(new ValidationResultItem(nameof(request.Email), "El email es requerido."));
            }
            if (string.IsNullOrEmpty(request.Pass))
            {
                response.Errors.Add(new ValidationResultItem(nameof(request.Pass), "La contraseña es requerida."));
            }
            if (string.IsNullOrEmpty(request.Nombre))
            {
                response.Errors.Add(new ValidationResultItem(nameof(request.Nombre), "El Nombre es requerido."));
            }
            if (request.PlanId<1)
            {
                response.Errors.Add(new ValidationResultItem(nameof(request.PlanId), "El Plan es requerido."));
            }

            return response;
        }
    }
}
