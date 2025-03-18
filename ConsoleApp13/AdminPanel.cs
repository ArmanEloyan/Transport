using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

         //   Initilize();
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

        public void Update(int id, City newCity)
        {
            _citiesRepo.Update(id, newCity);
        }

        public void Update(int id, Car newCar)
        {
           _carRepo.Update(id, newCar);
        }

        public City GetCity(int id)
        {
            return _citiesRepo.Get(id);
        }

        public Car GetCar(int id)
        {
            return _carRepo.Get(id);
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
            IEnumerable<City> cityes = _citiesRepo.GetAll();
            if (cityes.Any(n => n.Id == city.Id))
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

        public Way GetWay(int id)
        {
           return _waysRepo.Get(id);
        }

        public IEnumerable<Way> GetAllWays()
        {
            return _waysRepo.GetAll();
        }

        public void Update(int id, Way newCityFromTo)
        {
            _waysRepo.Update(id, newCityFromTo);
        }

        //private void Initilize()
        //{
        //    City city1 = new City("Yerevan");
        //    City city2 = new City("Gyumri");
        //    City city3 = new City("Aparan");

        //    List<City> cities = new List<City>() { city1, city2, city3 };
        //    AddRange(cities);

        //    List<Car> cars = new List<Car>() { new Car("BMW", "X5", 2015, CarType.Sedan), new Car("Yamaha", "Y300", 2004, CarType.Moto), new Car("Toyota", "Camry", 2019, CarType.Sedan), new Car("GMC", "Canyon", 2018, CarType.Truck) };
        //    AddRange(cars);

        //    Way way1 = new Way(city1, city2, 5000);
        //    Way way2 = new Way(city1, city3, 8000);

        //    Way way3 = new Way(city2, city1, 6000);
        //    Way way4 = new Way(city2, city3, 10000);

        //    Way way5 = new Way(city3, city1, 7000);
        //    Way way6 = new Way(city3, city2, 11000);

        //    List<Way> ways = new List<Way>() { way1, way2, way3, way4, way5, way6 };
        //    AddRange(ways);
        //}
    }
}
