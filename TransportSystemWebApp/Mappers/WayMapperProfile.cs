using AutoMapper;
using TransportSystemWebApp.Entities;
using TransportSystemWebApp.Models;

namespace TransportSystemWebApp.Mappers;

public class WayMapperProfile : Profile
{
    public WayMapperProfile()
    {
        CreateMap<WayCreateDTO, Way>();
        CreateMap<WayUpdateDTO, Way>();
        CreateMap<Way, WayGetDTO>();
    }
}
