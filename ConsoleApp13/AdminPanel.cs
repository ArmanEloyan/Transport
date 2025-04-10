using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp13.Entities;
using ConsoleApp13.Repos;

namespace ConsoleApp13
{
    internal class AdminPanel // // s_CitiesRepo, s_CarRepo, s_WaysRepo
    {
        private IRepository<City, int> _citiesRepo;
        private IRepository<Car, int> _carRepo;
        private IRepository<Way, int> _waysRepo;
        private IRepository<Order, int> _orderRepo;
        private IRepository<CarType, int> _carTypeRepo;

        public AdminPanel(IRepository<City, int> citiesRepo, IRepository<Car, int> carRepo, IRepository<Way, int> waysRepo, IRepository<Order, int> orderRepo, IRepository<CarType, int> carTypeRepo)
        {
            _citiesRepo = citiesRepo;
            _carRepo = carRepo;
            _waysRepo = waysRepo;
            _orderRepo = orderRepo;
            _carTypeRepo = carTypeRepo;
        }

        public async Task AddAsync(City city)
        {
            if (city == null)
            {
                throw new ArgumentNullException("City cannot be null");
            }

         //   CityDTO
            await _citiesRepo.AddAsync(city);
        }

        public async Task AddAsync(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException("Car cannot be null");
            }

            await _carRepo.AddAsync(car);
        }

        public async Task AddAsync(CarType carType)
        {
            if (carType == null)
            {
                throw new ArgumentNullException("CarType cannot be null");
            }

            await _carTypeRepo.AddAsync(carType);
        }

        public async Task AddAsync(Way way)
        {
            if(way == null)
            {
                throw new ArgumentNullException("Way cannot be null");
            }

            if (way.CityFrom.Id == way.CityTo.Id)
            {
                throw new Exception("CityFrom and CityTo cant be the same");
            }

            await _waysRepo.AddAsync(way);
        }

        public async Task DeleteAsync(City city)
        {
            await _citiesRepo.DeleteAsync(city.Id);
        }

        public async Task DeleteAsync(Car car) => await _carRepo.DeleteAsync(car.Id);

        public async Task DeleteAsync(Way cityFromTo) => await _waysRepo.DeleteAsync(cityFromTo.Id);

        public async Task DeleteAsync(CarType carType) => await _carTypeRepo.DeleteAsync(carType.Id);

        public async Task UpdateAsync(City newCity)
        {
            if (newCity == null)
            {
                throw new ArgumentNullException("City cannot be null");
            }

            await _citiesRepo.UpdateAsync(newCity);
        }

        public async Task UpdateAsync(Way newWay)
        {
            if (newWay == null)
            {
                throw new ArgumentNullException("Way cannot be null");
            }

            await _waysRepo.UpdateAsync(newWay);

        }

        public async Task UpdateAsync(Car newCar)
        {
            if (newCar == null)
            {
                throw new ArgumentNullException("Car cannot be null");
            }

            await _carRepo.UpdateAsync(newCar);
        }

        public async Task UpdateAsync(CarType newCarType)
        {
            if (newCarType == null)
            {
                throw new ArgumentNullException("CarType cannot be null");
            }

            await _carTypeRepo.UpdateAsync(newCarType);
        }

        public async Task<City> GetCityAsync(int id) => await _citiesRepo.GetAsync(id);

        public async Task<Car> GetCarAsync(int id) => await _carRepo.GetAsync(id);

        public async Task<Way> GetWayAsync(int id) => await _waysRepo.GetAsync(id);

        public async Task<CarType> GetCarTypeAsync(int id) => await _carTypeRepo.GetAsync(id);

        public async Task<IEnumerable<City>> GetAllCitiesAsync() => await _citiesRepo.GetAllAsync();

        public async Task<IEnumerable<Car>> GetAllCarsAsync() => await _carRepo.GetAllAsync();

        public async Task<IEnumerable<Order>> GetAllOrdersAsync() => await _orderRepo.GetAllAsync();

        public async Task<IEnumerable<Way>> GetAllWaysAsync() => await _waysRepo.GetAllAsync();

        public async Task<IEnumerable<CarType>> GetAllCarTypesAsync() => await _carTypeRepo.GetAllAsync();
    }
}
