using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TuHogarGO.BL.Contracts;
using TuHogarGO.Infraestructura.Validaciones;
using TuHogarGO.Models.Geo;

namespace TuHogarGO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoController : ControllerBase
    {
        private readonly IPaisService _paisService;
        private readonly IEstadoService _estadoService;
        private readonly IMunicipioService _municipioService;
        private readonly IMapper _mapper;
        public GeoController(IMapper mapper, IPaisService paisService, 
            IEstadoService estadoService, 
            IMunicipioService municipioService)
        {
            _paisService = paisService;
            _estadoService = estadoService;
            _municipioService = municipioService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("api/[controller]/Paises")]
        public IList<PaisDTO> GetPaises()
        {
            var items = _paisService.GetAll();
            var result = _mapper.Map<IList<PaisDTO>>(items);
            return result;
        }
        [HttpGet]
        [Route("api/[controller]/Estados")]
        public IList<EstadoDTO> GetEstados()
        {
            var items = _estadoService.GetAll();
            var result = _mapper.Map<IList<EstadoDTO>>(items);
            return result;
        }
        [HttpGet]
        [Route("api/[controller]/{PaisId}/Estados")]
        public IList<EstadoDTO> GetEstadosByPaisId(int PaisId)
        {
            var items = _estadoService.GetEstadoByPaisId(PaisId);
            var result = _mapper.Map<IList<EstadoDTO>>(items);
            return result;
        }
        [HttpGet]
        [Route("api/[controller]/Municipios")]
        public IList<MunicipioDTO> GetMunicipios()
        {
            var items = _municipioService.GetAll();
            var result = _mapper.Map<IList<MunicipioDTO>>(items);
            return result;
        }
        [HttpGet]
        [Route("api/[controller]/{EstadoId}/Municipios")]
        public IList<MunicipioDTO> GetMunicípiosByEstadoId(int EstadoId)
        {
            var items = _municipioService.GetMunicipiosByEstadoId(EstadoId);
            var result = _mapper.Map<IList<MunicipioDTO>>(items);
            return result;
        }
        [HttpGet]
        [Route("api/[controller]/{Id}/Pais")]
        public PaisDTO Pais(int Id = 0)
        {
            var item = _paisService.GetById(Id);
            var result = _mapper.Map<PaisDTO>(item);
            return result;
        }
        [HttpGet]
        [Route("api/[controller]/{Id}/Estado")]
        public EstadoDTO Estado(int Id = 0)
        {
            var item = _estadoService.GetById(Id);
            var result = _mapper.Map<EstadoDTO>(item);
            return result;
        }
        [HttpGet]
        [Route("api/[controller]/{Id}/Municipio")]
        public MunicipioDTO Municipio(int Id = 0)
        {
            var item = _municipioService.GetById(Id);
            var result = _mapper.Map<MunicipioDTO>(item);
            return result;
        }
        [HttpPost]
        [Route("api/[controller]/Pais")]
        public async Task<ValidationResult> PostPais([FromBody] PaisDTO item)
        {
            var itemEntity = _mapper.Map<Entities.Pais>(item);
            var validationsResult = await _paisService.Save(itemEntity);

            return validationsResult;
        }
        [HttpPost]
        [Route("api/[controller]/{PaisId}/Estado")]
        public async Task<ValidationResult> PostEstado(int PaisId, [FromBody] EstadoDTO item)
        {
            var itemEntity = _mapper.Map<Entities.Estado>(item);
            itemEntity.PaisId = PaisId;
            var validationsResult = await _estadoService.Save(itemEntity);

            return validationsResult;
        }
        [HttpPost]
        [Route("api/[controller]/{EstadoId}/Municipio")]
        public async Task<ValidationResult> PostMunicipio(int EstadoId, [FromBody] MunicipioDTO item)
        {
            var itemEntity = _mapper.Map<Entities.Municipio>(item);
            itemEntity.EstadoId = EstadoId;
            var validationsResult = await _municipioService.Save(itemEntity);

            return validationsResult;
        }
    }
}
