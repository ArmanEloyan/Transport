using ConsoleApp13.Entities;
using ConsoleApp13.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Services
{
    internal class UserService
    {
        private readonly IRepository<City, int> _citiesRepo;
        private readonly IRepository<Car, int> _carRepo;
        private readonly IRepository<Way, int> _waysRepo;
        private readonly IRepository<Order, int> _orderRepo;

        public UserService(IRepository<City, int> citiesRepo, IRepository<Car, int> carRepo, IRepository<Way, int> waysRepo, IRepository<Order, int> ordeRepo)
        {
            _citiesRepo = citiesRepo;
            _carRepo = carRepo;
            _waysRepo = waysRepo;
            _orderRepo = ordeRepo;
        }

        public async Task<City> GetCity(int id) => await _citiesRepo.GetAsync(id);

        public async Task<IEnumerable<City>> GetAllCities() => await _citiesRepo.GetAllAsync();

        public async Task<Car> GetCar(int id) => await _carRepo.GetAsync(id);

        public async Task<IEnumerable<Car>> GetAllCars() => await _carRepo.GetAllAsync();

        public async Task<Way> GetWay(int id) => await _waysRepo.GetAsync(id);

        public async Task<IEnumerable<Way>> GetAllWays() => await _waysRepo.GetAllAsync();

        public async Task AddOrder(Order order) => await _orderRepo.AddAsync(order);

    }
}
