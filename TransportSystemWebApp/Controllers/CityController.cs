using TransportSystemWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using TransportSystemWebApp.Entities;
using TransportSystemWebApp.Models;
using TransportSystemWebApp.Mappers;

namespace TransportSystemWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : Controller
    {
        private readonly IService<City> _cityService;
        private readonly IMapper<CityDTO, City> _cityMapper;

        public CityController(IService<City> cityService, IMapper<CityDTO, City> cityMapper)
        {
            _cityService = cityService;
            _cityMapper = cityMapper;
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddCity(CityDTO cityDTO)
        {
            try
            {
                City city = _cityMapper.Map(cityDTO);
                await _cityService.AddAsync(city);

                return Ok(city);
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
                City removeCity = await _cityService.GetAsync(c=> c.Id == id);
                await _cityService.DeleteAsync(removeCity);
                return Ok(removeCity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            
            
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] City city)
        {
            try
            {
                await _cityService.UpdateAsync(city);
                return Ok(city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<City>> GetCityAsync(int id)
        {
            try
            {
                var city = await _cityService.GetAsync(c=>c.Id == id);
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
        public async Task<ActionResult<City>> GetAllAsync()
        {
            try 
            {
                return Ok(await _cityService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
