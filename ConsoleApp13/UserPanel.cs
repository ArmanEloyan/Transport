using ConsoleApp13.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class UserPanel 
    {
        private readonly IRepository<City> _citiesRepo;
        private readonly IRepository<Car> _carRepo;
        private readonly IRepository<Way> _waysRepo;

        public UserPanel(IRepository<City> citiesRepo, IRepository<Car> carRepo, IRepository<Way> waysRepo)
        {
            _citiesRepo = citiesRepo;
            _carRepo = carRepo;
            _waysRepo = waysRepo;
        }

        public City GetCity(int id)
        {
            return _citiesRepo.Get(id);
        }

        public IEnumerable<City> GetAllCities()
        {
            return _citiesRepo.GetAll();
        }

        public Car GetCar(int id)
        {
            return _carRepo.Get(id);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _carRepo.GetAll();
        }

        public Way GetWay(int id)
        {
            return _waysRepo.Get(id);
        }

        public IEnumerable<Way> GetAllWays()
        {
            return _waysRepo.GetAll();
        }

        public bool CheckHasWay(City cityFrom, City cityTo, out Way way)
        {
            way = _waysRepo.GetAll().FirstOrDefault(c => c.CityFrom.Id == cityFrom.Id && c.CityTo.Id == cityTo.Id);

            if(way == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
