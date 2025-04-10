using TransportSystemWebApp.Entities;
using TransportSystemWebApp.Models;

namespace TransportSystemWebApp.Mappers
{
    public class CarTypeMapper : IMapper<CarTypeDTO, CarType>
    {
        public CarType Map(CarTypeDTO carTypeDTO)
        {
            return new CarType()
            {
                Name = carTypeDTO.Name,
                Coefficent = carTypeDTO.Coefficent
            };
        }
    }
}
