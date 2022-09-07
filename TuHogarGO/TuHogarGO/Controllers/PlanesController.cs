using MediatR;
using Microsoft.AspNetCore.Mvc;
using TuHogarGO.BL.Contracts;
using TuHogarGO.Entities;
using TuHogarGO.Infraestructura.Validaciones;

namespace TuHogarGO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPlanesService _planesService;
        public PlanesController(IMediator mediatr, IPlanesService planesService)
        {
            _mediator = mediatr;
            _planesService = planesService;
        }
        [HttpGet]
        public IList<Plan> GetAll()
        {
            return _planesService.GetAll();
        }
        [HttpPost]
        public async Task<ValidationResult> Post(Plan item)
        {
            ValidationResult result = new ValidationResult();
            try
            {
                result = await _planesService.Save(item, true);
            }
            catch(Exception ex)
            {

            }

            return result;
        }

    }
}
