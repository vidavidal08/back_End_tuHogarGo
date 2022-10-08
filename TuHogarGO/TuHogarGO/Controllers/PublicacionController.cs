using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TuHogarGO.BL.Contracts;
using TuHogarGO.Infraestructura.Validaciones;
using TuHogarGO.Models;

namespace TuHogarGO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionesController : ControllerBase
    {
        private readonly IPublicacionesService _publicacionesService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PublicacionesController(IMapper mapper,IMediator mediator, IPublicacionesService publicacionesService)
        {
            _mediator = mediator;
            _publicacionesService = publicacionesService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("api/[controller]/{PublicacionId}")]
        public async Task<PublicacionDTO> GetPublicacionById(int publicacionId)
        {
            var item = _publicacionesService.GetById(publicacionId);
            var result = _mapper.Map<PublicacionDTO>(item);

            return await Task.FromResult(result);
        }
        [HttpGet]
        [Route("api/[controller]/ByMunicipioId/{MunicipioId}")]
        public async Task<IList<PublicacionDTO>> GetPublicacionesByMunicipioId(int municipioId)
        {
            var items = await _publicacionesService.GetPublicacionesByMunicipioId(municipioId);
            var result = _mapper.Map<IList<PublicacionDTO>>(items);

            return await Task.FromResult(result);
        }
        [HttpGet]
        [Route("api/[controller]/ByUserId/{UserId}")]
        public async Task<IList<PublicacionDTO>> GetPublicacionesByUserId(int userId)
        {
            var items = await _publicacionesService.GetPublicacionesByUserId(userId);
            var result = _mapper.Map<IList<PublicacionDTO>>(items);

            return await Task.FromResult(result);
        }
        [HttpGet]
        [Route("api/[controller]/ByTipoInmuebleId/{TipoInmuebleId}")]
        public async Task<IList<PublicacionDTO>> GetPublicacionesByTipoInmuebleId(int tipoInmuebleId)
        {
            var items = await _publicacionesService.GetPublicacionesByTipoInmuebleId(tipoInmuebleId);
            var result = _mapper.Map<IList<PublicacionDTO>>(items);

            return await Task.FromResult(result);
        }
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<ValidationResult> Post([FromBody] PublicacionDTO item)
        {
            var itemEntity = _mapper.Map<Entities.Publicacion>(item);
            var validationsResult = await _publicacionesService.Save(itemEntity);

            return validationsResult;
        }
    }
}
