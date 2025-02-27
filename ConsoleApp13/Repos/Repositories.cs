using ConsoleApp13.CityFldr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Repos
{
    internal static class Repositories
    {
        public static IRepository<City> s_CitiesRepo = new Repository<City>();
        public static IRepository<Car> s_CarRepo = new Repository<Car>();
        public static IRepository<Way> s_WaysRepo = new Repository<Way>();
    }
}
