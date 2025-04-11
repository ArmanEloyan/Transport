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
    public class OrderController : Controller
    {
        private readonly IService<Order> _orderTypeService;
        private readonly IMapper _orderMapper;

        public OrderController(IService<Order> orderService, IMapper orderMapper)
        {
            _orderTypeService = orderService;
            _orderMapper = orderMapper;
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddOrder([FromBody] OrderCreateDTO orderDTO)
        {
            try
            {
                Order order = _orderMapper.Map<Order>(orderDTO);
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
        public async Task<ActionResult> Update([FromBody] OrderUpdateDTO order)
        {
            try
            {
                Order orderUpdate = _orderMapper.Map<Order>(order);
                await _orderTypeService.UpdateAsync(orderUpdate);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<OrderGetDTO>> GetCityAsync(int id)
        {
            try
            {
                Order order = await _orderTypeService.GetAsync(c => c.Id == id);
                OrderGetDTO orderGetDTO = _orderMapper.Map<OrderGetDTO>(order);
                if (order == null)
                {
                    return NotFound();
                }

                return Ok(orderGetDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllAsync()
        {
            try
            {
                IEnumerable<Order> orders = await _orderTypeService.GetAllAsync();
                IEnumerable<OrderGetDTO> ordersDTO = _orderMapper.Map<IEnumerable<OrderGetDTO>>(orders);
                return Ok(ordersDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
