using TransportSystemWebApp.Entities;
using TransportSystemWebApp.Models;

namespace TransportSystemWebApp.Mappers
{
    public class WayMapper : IMapper<WayDTO, Way>
    {
        public Way Map(WayDTO wayDTO)
        {
            return new Way()
            {
                CityFromId = wayDTO.CityFromId,
                CityToId = wayDTO.CityToId,
                StartPrice = wayDTO.StartPrice
            };
        }

        public WayDTO MapBack(Way way)
        {
            return new WayDTO()
            {
               // Id = way.Id,
                CityFromId = way.CityFromId,
                CityToId = way.CityToId,
                StartPrice = way.StartPrice
            };
        }
    }
}
