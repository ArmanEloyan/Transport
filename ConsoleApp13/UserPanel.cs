using ConsoleApp13.CityFldr;
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

        public City GetCity(Func<City, bool> func)
        {
            return _citiesRepo.Get(func);
        }

        public IEnumerable<City> GetAllCities()
        {
            return _citiesRepo.GetAll();
        }

        public Car GetCar(Func<Car, bool> func)
        {
            return _carRepo.Get(func);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _carRepo.GetAll();
        }

        public Way GetWay(Func<Way, bool> func)
        {
            return _waysRepo.Get(func);
        }

        public IEnumerable<Way> GetAllWays()
        {
            return _waysRepo.GetAll();
        }

        public bool CheckHasWay(City cityFrom, City cityTo, out Way way)
        {
            way = _waysRepo.Get(c => c.CityFrom == cityFrom && c.CityTo == cityTo);

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
