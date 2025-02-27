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
        public City GetCity(Func<City, bool> func)
        {
            return Repositories.s_CitiesRepo.Get(func);
        }

        public IEnumerable<City> GetAllCities()
        {
            return Repositories.s_CitiesRepo.GetAll();
        }

        public Car GetCar(Func<Car, bool> func)
        {
            return Repositories.s_CarRepo.Get(func);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return Repositories.s_CarRepo.GetAll();
        }

        public Way GetWay(Func<Way, bool> func)
        {
            return Repositories.s_WaysRepo.Get(func);
        }

        public bool CheckHasWay(City cityFrom, City cityTo, out Way way)
        {
            way = Repositories.s_WaysRepo.Get(c => c.CityFrom == cityFrom && c.CityTo == cityTo);

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
