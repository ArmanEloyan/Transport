using TransportSystemWebApp.Models;
using TransportSystemWebApp.Entities;

namespace TransportSystemWebApp.Mappers
{
    public class WaysMapper// : IMapper<IEnumerable<WayDTO>, IEnumerable<WayDTO>>
    {
       //private readonly WayMapper _wayMapper;

       // public WaysMapper(WaysMappe wayMapper)
       // {
       //     _wayMapper = wayMapper;
       // }
        public IEnumerable<WayDTO> Map(IEnumerable<Way> inValue)
        {
            WayMapper _wayMapper = new WayMapper();
            List<WayDTO> wayDTOs = new List<WayDTO>();
            foreach (var way in inValue)
            {
                WayDTO wayDTO = _wayMapper.MapBack(way);
                wayDTOs.Add(wayDTO);
                //wayDTOs.Add(new WayDTO
                //{
                //    Id = way.Id,
                //    CityFromId = way.CityFromId,
                //    CityToId = way.CityToId,
                //    Distance = way.Distance,
                //    Duration = way.Duration
                //});
            }
            return wayDTOs;
        }
    }
}
