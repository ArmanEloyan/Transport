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
    public class CarController : Controller
    {
        private readonly IService<Car> _carService;
        private readonly IMapper _carMapper;

        public CarController(IService<Car> carService, IMapper carMapper)
        {
            _carService = carService;
            _carMapper = carMapper;
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddCar([FromBody] CarCreateDTO carCreateDTO)
        {
            try
            {
                Car car = _carMapper.Map<Car>(carCreateDTO);
                await _carService.AddAsync(car);

                return Ok(car);
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
                Car car = await _carService.GetAsync(c => c.Id == id);
                await _carService.DeleteAsync(car);
                return Ok(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] CarUpdateDTO carUpdateDTO)
        {
            try
            {
                Car car = _carMapper.Map<Car>(carUpdateDTO);
                await _carService.UpdateAsync(car);
                return Ok(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<CarGetDTO>> GetCarAsync(int id)
        {
            try
            {
                Car car = await _carService.GetAsync(c => c.Id == id);
                if (car == null)
                {
                    return NotFound();
                }
                CarGetDTO carGetDTO = _carMapper.Map<CarGetDTO>(car);
                return Ok(carGetDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CarGetDTO>>> GetAllAsync()
        {
            try
            {
                IEnumerable<Car> cars = await _carService.GetAllAsync();
                IEnumerable<CarGetDTO> carsDTO = _carMapper.Map<IEnumerable<CarGetDTO>>(cars);
                return Ok(carsDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
