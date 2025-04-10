using Microsoft.AspNetCore.Mvc;
using TransportSystemWebApp.Entities;
using TransportSystemWebApp.Mappers;
using TransportSystemWebApp.Models;
using TransportSystemWebApp.Services;

namespace TransportSystemWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IService<Order> _orderTypeService;
        private readonly IMapper<OrderDTO, Order> _orderMapper;

        public OrderController(IService<Order> orderService, IMapper<OrderDTO, Order> orderMapper)
        {
            _orderTypeService = orderService;
            _orderMapper = orderMapper;
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddOrder([FromQuery] OrderDTO orderDTO)
        {
            try
            {
                Order order = _orderMapper.Map(orderDTO);
                await _orderTypeService.AddAsync(order);

                return Ok(order);
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
                Order order = await _orderTypeService.GetAsync(c => c.Id == id);
                await _orderTypeService.DeleteAsync(order);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] Order order)
        {
            try
            {
                await _orderTypeService.UpdateAsync(order);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Order>> GetCityAsync(int id)
        {
            try
            {
                Order order = await _orderTypeService.GetAsync(c => c.Id == id);
                if (order == null)
                {
                    return NotFound();
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Order>> GetAllAsync()
        {
            try
            {
                return Ok(await _orderTypeService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
