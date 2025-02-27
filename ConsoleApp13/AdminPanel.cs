using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp13.CityFldr;
using ConsoleApp13.Repos;

namespace ConsoleApp13
{
    internal class AdminPanel
    {
        public void Add(City city)
        {
            Repositories.s_CitiesRepo.Add(city);
        }

        public void Add(Car car)
        {
            Repositories.s_CarRepo.Add(car);
        }

        public void AddRange(IEnumerable<City> cities)
        {
            Repositories.s_CitiesRepo.AddRange(cities);
        }

        public void AddRange(IEnumerable<Car> cars)
        {
            Repositories.s_CarRepo.AddRange(cars);
        }

        public void AddRange(IEnumerable<Way> ways)
        {
            Repositories.s_WaysRepo.AddRange(ways);
        }

        public void Delete(City city)
        {
            Repositories.s_CitiesRepo.Delete(city);
        }

        public void Delete(Car car)
        {
            Repositories.s_CarRepo.Delete(car);
        }

        public void Update(City oldCity, City newCity)
        {
            Repositories.s_CitiesRepo.Update(oldCity, newCity);
        }

        public void Update(Car oldCar, Car newCar)
        {
            Repositories.s_CarRepo.Update(oldCar, newCar);
        }

        public City GetCity(Func<City, bool> func)
        {
            return Repositories.s_CitiesRepo.Get(func);
        }

        public Car GetCar(Func<Car, bool> func)
        {
            return Repositories.s_CarRepo.Get(func);
        }

        public IEnumerable<City> GetAlCities()
        {
            return Repositories.s_CitiesRepo.GetAll();
        }

        public IEnumerable<Car> GetAllCars()
        {
            return Repositories.s_CarRepo.GetAll();
        }

        private bool ContainsCity(City city)
        {
            List<City> cityes = Repositories.s_CitiesRepo.GetAll().ToList();
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
                Repositories.s_WaysRepo.Add(cityFromTo);
                return;
            }

            throw new Exception("Cant add way. Cityes dont find");
        }

        public void DeleteWay(Way cityFromTo)
        {
            Repositories.s_WaysRepo.Delete(cityFromTo);
        }

        public Way GetWay(Func<Way, bool> func)
        {
           return Repositories.s_WaysRepo.Get(func);
        }

        public IEnumerable<Way> GetAllWays()
        {
            return Repositories.s_WaysRepo.GetAll();
        }

        public void UpdateWay(Way oldCityFromTo, Way newCityFromTo)
        {
            Repositories.s_WaysRepo.Update(oldCityFromTo, newCityFromTo);
        }
    }
}
