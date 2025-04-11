using TransportSystemWebApp.Models;
using TransportSystemWebApp.Entities;
using AutoMapper;

namespace TransportSystemWebApp.Mappers;

public class CityMapperProfile : Profile
{
    public CityMapperProfile()
    {
        CreateMap<CityCreateDTO, City>();
        CreateMap<CityGetOrUpdateDTO, City>().ReverseMap();
    }
}
