using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TransportSystemWebApp.Entities;
using TransportSystemWebApp.Models;

namespace TransportSystemWebApp.Mappers
{
    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile()
        {
            CreateMap<OrderCreateDTO, Order>();
            CreateMap<OrderUpdateDTO, Order>();
            CreateMap<Order, OrderGetDTO>();
        }
    }
}
