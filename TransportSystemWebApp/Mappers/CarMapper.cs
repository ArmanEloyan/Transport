using TransportSystemWebApp.Entities;
using TransportSystemWebApp.Models;

namespace TransportSystemWebApp.Mappers
{
    public class CarMapper : IMapper<CarDTO, Car>
    {
        public Car Map(CarDTO carDTO)
        {
            return new Car()
            {
                Mark = carDTO.Mark,
                Model = carDTO.Model,
                Year = carDTO.Year,
                CarTypeId = carDTO.CarTypeId
            };
        }
    }
}
