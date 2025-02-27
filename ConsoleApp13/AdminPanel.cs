using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp13.CityFldr;
using ConsoleApp13.Repos;

namespace ConsoleApp13
{
    internal class AdminPanel // // s_CitiesRepo, s_CarRepo, s_WaysRepo
    {
        private IRepository<City> _citiesRepo;
        private IRepository<Car> _carRepo;
        private IRepository<Way> _waysRepo;

        public AdminPanel(IRepository<City> citiesRepo, IRepository<Car> carRepo, IRepository<Way> waysRepo)
        {
            _citiesRepo = citiesRepo;
            _carRepo = carRepo;
            _waysRepo = waysRepo;

            Initilize();
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
            _citiesRepo.Delete(city);
        }

        public void Delete(Car car)
        {
           _carRepo.Delete(car);
        }

        public void Update(City oldCity, City newCity)
        {
            _citiesRepo.Update(oldCity, newCity);
        }

        public void Update(Car oldCar, Car newCar)
        {
           _carRepo.Update(oldCar, newCar);
        }

        public City GetCity(Func<City, bool> func)
        {
            return _citiesRepo.Get(func);
        }

        public Car GetCar(Func<Car, bool> func)
        {
            return _carRepo.Get(func);
        }

        public IEnumerable<City> GetAlCities()
        {
            return _citiesRepo.GetAll();
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _carRepo.GetAll();
        }

        private bool ContainsCity(City city)
        {
            List<City> cityes = _citiesRepo.GetAll().ToList();
            if (cityes.Contains(city))
            {
                return true;
            }
            return false;
        }

        public void AddWay(Way cityFromTo)
        {
            if (ContainsCity(cityFromTo.CityFrom) && ContainsCity(cityFromTo.CityTo))
            {
                _waysRepo.Add(cityFromTo);
                return;
            }

            throw new Exception("Cant add way. Cityes dont find");
        }

        public void DeleteWay(Way cityFromTo)
        {
            _waysRepo.Delete(cityFromTo);
        }

        public Way GetWay(Func<Way, bool> func)
        {
           return _waysRepo.Get(func);
        }

        public IEnumerable<Way> GetAllWays()
        {
            return _waysRepo.GetAll();
        }

        public void UpdateWay(Way oldCityFromTo, Way newCityFromTo)
        {
            _waysRepo.Update(oldCityFromTo, newCityFromTo);
        }

        private void Initilize()
        {
            City city1 = new City("Yerevan");
            City city2 = new City("Gyumri");
            City city3 = new City("Aparan");

            List<City> cities = new List<City>() { city1, city2, city3 };
            AddRange(cities);

            List<Car> cars = new List<Car>() { new Car("BMW", "X5", 2015, CarType.Sedan), new Car("Yamaha", "Y300", 2004, CarType.Moto), new Car("Toyota", "Camry", 2019, CarType.Sedan), new Car("GMC", "Canyon", 2018, CarType.Truck) };
            AddRange(cars);

            Way way1 = new Way(city1, city2, 5000);
            Way way2 = new Way(city1, city3, 8000);

            Way way3 = new Way(city2, city1, 6000);
            Way way4 = new Way(city2, city3, 10000);

            Way way5 = new Way(city3, city1, 7000);
            Way way6 = new Way(city3, city2, 11000);

            List<Way> ways = new List<Way>() { way1, way2, way3, way4, way5, way6 };
            AddRange(ways);
        }
    }
}
