using TransportSystemWebApp.Entities;
using TransportSystemWebApp.Models;
using AutoMapper;

namespace TransportSystemWebApp.Mappers;

public class CarMapperProfile : Profile
{
    public CarMapperProfile()
    {
        CreateMap<CarCreateDTO, Car>();
        CreateMap<CarUpdateDTO, Car>();
        CreateMap<Car, CarGetDTO>();
    }

}
