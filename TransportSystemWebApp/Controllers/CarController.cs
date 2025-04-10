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
        private readonly IMapper<CarDTO, Car> _carMapper;

        public CarController(IService<Car> carService, IMapper<CarDTO, Car> carMapper)
        {
            _carService = carService;
            _carMapper = carMapper;
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddCar([FromBody] CarDTO carDTO)
        {
           // Console.WriteLine(carDTO.CarTypeId);
            try
            {
                Car car = _carMapper.Map(carDTO);
                await _carService.AddAsync(car);

                return Ok(car);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ INNER EXCEPTION:");
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
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
        public async Task<ActionResult> Update([FromBody] CarDTO carDTO)
        {
            try
            {
                Car car = _carMapper.Map(carDTO);
                await _carService.UpdateAsync(car);
                return Ok(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Car>> GetCityAsync(int id)
        {
            try
            {
                var car = await _carService.GetAsync(c => c.Id == id);
                if (car == null)
                {
                    return NotFound();
                }

                return Ok(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Car>> GetAllAsync()
        {
            try
            {
                return Ok(await _carService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
