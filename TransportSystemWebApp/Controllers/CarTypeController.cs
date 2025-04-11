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
    public class CarTypeController : Controller
    {
        private readonly IService<CarType> _carTypeService;
        private readonly IMapper _carTypeMapper;

        public CarTypeController(IService<CarType> carTypeService, IMapper carTypeMapper)
        {
            _carTypeService = carTypeService;
            _carTypeMapper = carTypeMapper;
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddCar(CarTypeCreateDTO carDTO)
        {
            try
            {
                CarType carType = _carTypeMapper.Map<CarType>(carDTO);
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
        public async Task<ActionResult> Update([FromBody] CarTypeGetOrUpdateDTO carType)
        {
            try
            {
                CarType car = _carTypeMapper.Map<CarType>(carType);
                await _carTypeService.UpdateAsync(car);
                return Ok(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<CarTypeGetOrUpdateDTO>> GetCarTypeAsync(int id)
        {
            try
            {
                CarType carType = await _carTypeService.GetAsync(c => c.Id == id);
                CarTypeGetOrUpdateDTO carTypeDTO = _carTypeMapper.Map<CarTypeGetOrUpdateDTO>(carType);
                if (carType == null)
                {
                    return NotFound();
                }

                return Ok(carTypeDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CarTypeGetOrUpdateDTO>>> GetAllAsync()
        {
            try
            {
                IEnumerable<CarType> carTypes = await _carTypeService.GetAllAsync();
                IEnumerable<CarTypeGetOrUpdateDTO> carsDTO = _carTypeMapper.Map<IEnumerable<CarTypeGetOrUpdateDTO>>(carTypes);
                return Ok(carsDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
