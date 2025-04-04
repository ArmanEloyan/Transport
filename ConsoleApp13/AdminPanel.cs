using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp13.Models;
using ConsoleApp13.Repos;

namespace ConsoleApp13
{
    internal class AdminPanel // // s_CitiesRepo, s_CarRepo, s_WaysRepo
    {
        private IRepository<City> _citiesRepo;
        private IRepository<Car> _carRepo;
        private IRepository<Way> _waysRepo;
        private IRepository<Order> _orderRepo;

        public AdminPanel(IRepository<City> citiesRepo, IRepository<Car> carRepo, IRepository<Way> waysRepo, IRepository<Order> orderRepo)
        {
            _citiesRepo = citiesRepo;
            _carRepo = carRepo;
            _waysRepo = waysRepo;
            _orderRepo = orderRepo;
        }

        public void Add(City city)
        {
            _citiesRepo.Add(city);
        }

        public void Add(Car car)
        {
           _carRepo.Add(car);
        }

        public void AddRange(IEnumerable<City> cities)
        {
            _citiesRepo.AddRange(cities);
        }

        public void AddRange(IEnumerable<Car> cars)
        {
           _carRepo.AddRange(cars);
        }

        public void AddRange(IEnumerable<Way> ways)
        {
            _waysRepo.AddRange(ways);
        }

        public void Delete(City city)
        {
            foreach (var wayFrom in city.WaysFrom)
            {
                _waysRepo.Delete(wayFrom);
            }

            foreach (var wayTo in city.WaysTo)
            {
                _waysRepo.Delete(wayTo);
            }

            _citiesRepo.Delete(city);
        }

        public void Delete(Car car)
        {
           _carRepo.Delete(car);
        }

        public void Update(City newCity)
        {
            _citiesRepo.Update(newCity);
        }

        public void Update(Car newCar)
        {
           _carRepo.Update(newCar);
        }

        public City GetCity(Func<City, bool> predicate)
        {
            return _citiesRepo.Get(predicate);
        }

        public Car GetCar(Func<Car, bool> predicate)
        {
            return _carRepo.Get(predicate);
        }

        public IEnumerable<City> GetAllCities()
        {
            return _citiesRepo.GetAll();
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _carRepo.GetAll();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepo.GetAll();
        }

        private bool ContainsCity(City city)
        {
            IEnumerable<City> cityes = _citiesRepo.GetAll();
            if (cityes.Any(n => n.Id == city.Id))
            {
                return true;
            }
            return false;
        }

        public void AddWay(Way way)
        {
            if (ContainsCity(way.CityFrom) && ContainsCity(way.CityTo))
            {
                _waysRepo.Add(way);
                return;
            }

            throw new Exception("Cant add way. Cities does not find");
        }

        public void DeleteWay(Way cityFromTo)
        {
            _waysRepo.Delete(cityFromTo);
        }

        public Way GetWay(Func<Way, bool> predicate)
        {
           return _waysRepo.Get(predicate);
        }

        public IEnumerable<Way> GetAllWays()
        {
            return _waysRepo.GetAll();
        }

        public void Update(Way newCityFromTo)
        {
            _waysRepo.Update(newCityFromTo);
        }
    }
}
