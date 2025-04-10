using TransportSystemWebApp.Models;
using TransportSystemWebApp.Entities;

namespace TransportSystemWebApp.Mappers
{
    public class CityMapper : IMapper<CityDTO, City>
    {
        public City Map(CityDTO cityDTO)
        {
            return new City() { Name = cityDTO.Name };
        }
    }
}
