using AutoMapper;
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
        private readonly IMapper _wayMapper;

        public WayController(IService<Way> wayService, IMapper wayMapper)
        {
            _wayService = wayService;
            _wayMapper = wayMapper;
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddWay(WayCreateDTO wayDTO)
        {
            if(wayDTO.CityFromId == wayDTO.CityToId)
            {
                return BadRequest("CityFrom and CityTo cannot be the same");
            }

            try
            {
                Way way = _wayMapper.Map<Way>(wayDTO);
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
        public async Task<ActionResult> Update([FromBody] WayUpdateDTO way)
        {
            if (way.CityFromId == way.CityToId)
            {
                return BadRequest("CityFrom and CityTo cannot be the same");
            }

            try
            {
                Way wayUpdate = _wayMapper.Map<Way>(way);
                await _wayService.UpdateAsync(wayUpdate);
                return Ok(way);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<WayGetDTO>> GetCityAsync(int id)
        {
            try
            {
                Way way = await _wayService.GetAsync(c => c.Id == id);
                WayGetDTO wayGetDTO = _wayMapper.Map<WayGetDTO>(way);
                if (way == null)
                {
                    return NotFound();
                }

                return Ok(way);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<WayGetDTO>>> GetAllAsync()
        {
            try
            {
                IEnumerable<Way> ways = await _wayService.GetAllAsync();
                IEnumerable<WayGetDTO> waysDTO = _wayMapper.Map<IEnumerable<WayGetDTO>>(ways);
                return Ok(waysDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
