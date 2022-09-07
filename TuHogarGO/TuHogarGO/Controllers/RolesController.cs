using MediatR;
using Microsoft.AspNetCore.Mvc;
using TuHogarGO.BL.Contracts;
using TuHogarGO.Entities;
using TuHogarGO.Infraestructura.Validaciones;

namespace TuHogarGO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesBL _rolesBL;
        private readonly IMediator _mediator;
        public RolesController(IMediator mediator, IRolesBL roles)
        {
            _mediator = mediator;
            _rolesBL = roles;
        }
        [HttpGet]
        public IList<Rol> GetRoles()
        {
            return _rolesBL.GetAll();
        }
        [HttpPost]
        public async Task<ValidationResult> PostRoles(Rol item)
        {
            var response = await _rolesBL.Save(item, true);
            return response;
        }
    }
}
