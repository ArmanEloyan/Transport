using System.ComponentModel.DataAnnotations;
using TransportSystemWebApp.Entities;
using TransportSystemWebApp.Models;

namespace TransportSystemWebApp.Mappers
{
    public class OrderMapper : IMapper<OrderDTO, Order>
    {
        public Order Map(OrderDTO orderDTO)
        {
            return new Order()
            {
                Email = orderDTO.Email,
                Price = orderDTO.Price,
                WayId = orderDTO.WayId,
                CarId = orderDTO.CarId,
                TransportType = orderDTO.TransportType,
                RecieveDate = orderDTO.RecieveDate
            };

        }
    }
}
