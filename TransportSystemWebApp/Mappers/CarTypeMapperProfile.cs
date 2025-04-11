using AutoMapper;
using TransportSystemWebApp.Entities;
using TransportSystemWebApp.Models;

namespace TransportSystemWebApp.Mappers;

public class CarTypeMapperProfile :Profile
{
    public CarTypeMapperProfile()
    {
        CreateMap<CarTypeCreateDTO, CarType>();
        CreateMap<CarTypeGetOrUpdateDTO, CarType>().ReverseMap();
    }
}
