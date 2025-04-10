using Microsoft.AspNetCore.Mvc;
using TransportSystemWebApp.Entities;
using TransportSystemWebApp.Mappers;
using TransportSystemWebApp.Models;
using TransportSystemWebApp.Services;

namespace TransportSystemWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarTypeController : Controller
    {
        private readonly IService<CarType> _carTypeService;
        private readonly IMapper<CarTypeDTO, CarType> _carTypeMapper;

        public CarTypeController(IService<CarType> carTypeService, IMapper<CarTypeDTO, CarType> carTypeMapper)
        {
            _carTypeService = carTypeService;
            _carTypeMapper = carTypeMapper;
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddCar(CarTypeDTO carDTO)
        {
            try
            {
                CarType carType = _carTypeMapper.Map(carDTO);
                await _carTypeService.AddAsync(carType);

                return Ok(carType);
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
                CarType carType = await _carTypeService.GetAsync(c => c.Id == id);
                await _carTypeService.DeleteAsync(carType);
                return Ok(carType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] CarType carType)
        {
            try
            {
                await _carTypeService.UpdateAsync(carType);
                return Ok(carType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<CarType>> GetCityAsync(int id)
        {
            try
            {
                var carType = await _carTypeService.GetAsync(c => c.Id == id);
                if (carType == null)
                {
                    return NotFound();
                }

                return Ok(carType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<CarType>> GetAllAsync()
        {
            try
            {
                return Ok(await _carTypeService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
