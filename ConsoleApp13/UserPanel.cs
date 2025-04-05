using ConsoleApp13.Models;
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
        private readonly IRepository<Order> _orderRepo;

        public UserPanel(IRepository<City> citiesRepo, IRepository<Car> carRepo, IRepository<Way> waysRepo, IRepository<Order> ordeRepo)
        {
            _citiesRepo = citiesRepo;
            _carRepo = carRepo;
            _waysRepo = waysRepo;
            _orderRepo = ordeRepo;
        }

        public City GetCity(Func<City, bool> predicate) => _citiesRepo.Get(predicate);

        public IEnumerable<City> GetAllCities() => _citiesRepo.GetAll();

        public Car GetCar(Func<Car, bool> predicate) => _carRepo.Get(predicate);

        public IEnumerable<Car> GetAllCars() => _carRepo.GetAll();

        public Way GetWay(Func<Way, bool> predicate) => _waysRepo.Get(predicate);

        public IEnumerable<Way> GetAllWays() => _waysRepo.GetAll();

        public void AddOrder(Order order) => _orderRepo.Add(order);

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
