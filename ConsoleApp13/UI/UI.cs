using ConsoleApp13.CityFldr;
using ConsoleApp13.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.UI
{
    internal class MainUI
    {
        private AdminUI _adminUI;
        private UserUI _userUI;

        public MainUI(AdminUI adminUI, UserUI userUI)
        {
            _adminUI = adminUI;
            _userUI = userUI;
            Initilize();
        }

        public void MainMenuShow()
        {
            while (true)
            {
                int op = "1. Admin | 2. User | 0. Exit".TryConvert<int>(true, ConsoleColor.Blue);

                switch (op)
                {
                    case 1:
                        _adminUI.ShowAdminPanel();
                        break;
                    case 2:
                        _userUI.UserPanelShow();
                        break;
                    case 0:
                        return;
                }
            }
        }

        private void Initilize()
        {
            City city1 = new City("Yerevan");
            City city2 = new City("Gyumri");
            City city3 = new City("Aparan");

            List<City> cities = new List<City>() { city1, city2, city3 };
            Repositories.s_CitiesRepo.AddRange(cities);

            List<Car> cars = new List<Car>() { new Car("BMW", "X5", 2015, CarType.Sedan), new Car("Yamaha", "Y300", 2004, CarType.Moto), new Car("Toyota", "Camry", 2019, CarType.Sedan), new Car("GMC", "Canyon", 2018,CarType.Truck) };
            Repositories.s_CarRepo.AddRange(cars);

            Way way1 = new Way(city1, city2, 5000);
            Way way2 = new Way(city1, city3, 8000);

            Way way3 = new Way(city2, city1, 6000);
            Way way4 = new Way(city2, city3, 10000);

            Way way5 = new Way(city3, city1, 7000);
            Way way6 = new Way(city3, city2, 11000);

            List<Way> ways = new List<Way>() { way1, way2, way3, way4, way5, way6 };
            Repositories.s_WaysRepo.AddRange(ways);
        }
    }
}
