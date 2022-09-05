using MediatR;
using Microsoft.AspNetCore.Mvc;
using TuHogarGO.BL.Contracts;
using TuHogarGO.Features.RegistrarUsuario.Models;
using TuHogarGO.Infraestructura.Auth;
using TuHogarGO.Models.Auth;

namespace TuHogarGO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsuarioService _userService;
        private readonly IMediator _mediator;
        public UsersController(IUsuarioService userService, IMediator mediator)
        {
            _userService = userService;
            _mediator = mediator;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
        [HttpPost]
        [Route("RegistrarUsuario")]
        public async Task<IActionResult> RegistrarUsuario(RegistrarUsuarioRequest request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtAction(nameof(RegistrarUsuario), response);
        }
    }
}
