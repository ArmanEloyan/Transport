using Microsoft.AspNetCore.Mvc;
using TransportSystemWebApp.Entities;
using TransportSystemWebApp.Mappers;
using TransportSystemWebApp.Models;
using TransportSystemWebApp.Services;

namespace TransportSystemWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WayController : Controller
    {
        private readonly IService<Way> _wayService;
        private readonly IMapper<WayDTO, Way> _wayMapper;

        public WayController(IService<Way> wayService, IMapper<WayDTO, Way> wayMapper)
        {
            _wayService = wayService;
            _wayMapper = wayMapper;
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddWay(WayDTO wayDTO)
        {
            if(wayDTO.CityFromId == wayDTO.CityToId)
            {
                return BadRequest("CityFrom and CityTo cannot be the same");
            }

            try
            {
                Way way = _wayMapper.Map(wayDTO);
                await _wayService.AddAsync(way);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Way way = await _wayService.GetAsync(c => c.Id == id);
                await _wayService.DeleteAsync(way);
                return Ok(way);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] Way way)
        {
            if (way.CityFromId == way.CityToId)
            {
                return BadRequest("CityFrom and CityTo cannot be the same");
            }

            try
            {
                await _wayService.UpdateAsync(way);
                return Ok(way);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Way>> GetCityAsync(int id)
        {
            try
            {
                var city = await _wayService.GetAsync(c => c.Id == id);
                if (city == null)
                {
                    return NotFound();
                }

                return Ok(city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Way>> GetAllAsync()
        {
            //WaysMapper mapper = new WaysMapper();
            //try
            //{
            //    IEnumerable<WayDTO> wayDTOs = mapper.Map(await _wayService.GetAllAsync());
            //    return Ok(wayDTOs);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}

          //  WaysMapper mapper = new WaysMapper();
            try
            {
              //  IEnumerable<WayDTO> wayDTOs = mapper.Map(await _wayService.GetAllAsync());
                return Ok(await _wayService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
