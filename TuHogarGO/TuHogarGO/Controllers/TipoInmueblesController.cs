using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TuHogarGO.BL.Contracts;
using TuHogarGO.Entities;
using TuHogarGO.Infraestructura.Validaciones;
using TuHogarGO.Models;

namespace TuHogarGO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoInmueblesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITipoInmuebleService _tipoInmuebleService;
        public TipoInmueblesController(IMapper mapper, ITipoInmuebleService tipoInmuebleService)
        {
            _mapper = mapper;
            _tipoInmuebleService = tipoInmuebleService;
        }
        [HttpGet]
        [Route("api/[controller]/")]
        public IList<TipoInmuebleDTO> Get()
        {
            var queryResult = _tipoInmuebleService.GetAll();
            var result = _mapper.Map<IList<TipoInmuebleDTO>>(queryResult);
            return result;
        }
        [HttpGet]
        [Route("api/[controller]/{tipoInmuebleId}")]
        public TipoInmuebleDTO GetById(int tipoInmuebleId)
        {
            var entity = _tipoInmuebleService.GetById(tipoInmuebleId);
            var result = _mapper.Map<TipoInmuebleDTO>(entity);
            return result;
        }
        [HttpPost]
        [Route("api/[controller]/")]
        public async Task<ValidationResult> Post(TipoInmuebleDTO item)
        {
            var entity = _mapper.Map<TipoInmueble>(item);
            var result = await _tipoInmuebleService.Save(entity);
            return result;
        }
    }
}
