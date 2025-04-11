using TransportSystemWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using TransportSystemWebApp.Entities;
using TransportSystemWebApp.Models;
using TransportSystemWebApp.Mappers;
using AutoMapper;

namespace TransportSystemWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : Controller
    {
        private readonly IService<City> _cityService;
        private readonly IMapper _cityMapper;

        public CityController(IService<City> cityService, IMapper cityMapper)
        {
            _cityService = cityService;
            _cityMapper = cityMapper;
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddCity([FromBody] CityCreateDTO cityDTO)
        {
            try
            {
                City city = _cityMapper.Map<City>(cityDTO);
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
        public async Task<ActionResult> Update([FromBody] CityGetOrUpdateDTO city)
        {
            try
            {
                City cityUpdate = _cityMapper.Map<City>(city);
                await _cityService.UpdateAsync(cityUpdate);
                return Ok(city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<CityGetOrUpdateDTO>> GetCityAsync(int id)
        {
            try
            {
                City city = await _cityService.GetAsync(c => c.Id == id);
                CityGetOrUpdateDTO cityGet = _cityMapper.Map<CityGetOrUpdateDTO>(city);

                if (city == null)
                {
                    return NotFound();
                }

                return Ok(cityGet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CityGetOrUpdateDTO>>> GetAllAsync()
        {
            try 
            {
                IEnumerable<City> cities = await _cityService.GetAllAsync();
                IEnumerable<CityGetOrUpdateDTO> citiesDTO = _cityMapper.Map<IEnumerable<CityGetOrUpdateDTO>>(cities);
                return Ok(citiesDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
