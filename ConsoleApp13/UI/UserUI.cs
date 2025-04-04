using ConsoleApp13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.UI
{
    internal class UserUI
    {
        private UserPanel _userPanel;
        private TransportCompanyOrderSystem _transportCompanyOrderSystem;

        public UserUI(UserPanel userPanel, TransportCompanyOrderSystem transportCompanyOrderSystem)
        {
            _userPanel = userPanel;
            _transportCompanyOrderSystem = transportCompanyOrderSystem;
        }

        public void UserPanelShow()
        {
            while (true)
            {
                int option = "1. Get Cities | 2.Get Cars | 3. Start 0. Back".TryConvert<int>(true, ConsoleColor.Blue);

                switch (option)
                {
                    case 1:
                        GetCities();
                        break;
                    case 2:
                        GetCars();
                        break;
                    case 3:
                        Start();
                        break;
                    case 0:
                        return;
                }
            }
        }

        private void Start()
        {
            City cityFrom = null;
            City cityTo = null;
            Car car = null;
            Way way = null;

            //Order order = new Order();

            while (true)
            {
                cityFrom = GetCityUI();
                cityTo = GetCityUI();

                if (!_userPanel.CheckHasWay(cityFrom, cityTo, out way))
                {
                    Helper.ErrorMessage("Cant find this way");
                    continue;
                }
                break;
            }

            TransportType transportType = GetTransportTypeUI();
            car = GetCarUI();
            car.IsOperable = IsOperableUI();

            DateToReceve dateToReceve = GetReceveDateUI();
            string email = "Enter Email: ".TryConvertNullOrWhiteSpaceCheck(false);

          //  TransportCompanyOrderSystem transportCompany = null;
            Order order =_transportCompanyOrderSystem.CreateOrder(way, car, email, transportType, dateToReceve);

            Console.WriteLine($"Transport Cost: {order.Price}");

            int payOption = "1. Pay | 0. Back".TryConvert<int>(true, ConsoleColor.Blue);

            if (payOption == 1)
            {
                _transportCompanyOrderSystem.CompleteOrder(order);
            }
            else
            {
                return;
            }

        }

        private City GetCityUI()
        {
            while (true)
            {
                int id = "Enter City Id: ".TryConvert<int>(false);
                try
                {
                    return _userPanel.GetCity(c => c.Id == id);
                }
                catch (Exception ex)
                {
                    Helper.ErrorMessage(ex.Message);
                }
            }
        }

        private TransportType GetTransportTypeUI()
        {
            while (true)
            {
                int type = "Enter Transport Type: 1. Open 2. Enclosed".TryConvert<int>(true, ConsoleColor.Blue);
                if (type == 1)
                {
                    return TransportType.Open;
                }
                else if (type == 2)
                {
                    return TransportType.Enclosed;
                }
            }
        }

        private DateToReceve GetReceveDateUI()
        {
            while (true)
            {
                int type = "Enter Date to Receve: 1. Week 2. Month 3. 2 Months".TryConvert<int>(true, ConsoleColor.Blue);
                if (type == 1)
                {
                    return DateToReceve.Week;
                }
                else if (type == 2)
                {
                    return DateToReceve.Month;
                }
                else if (type == 3)
                {
                    return DateToReceve.Months2;
                }
            }
        }

        private Car GetCarUI()
        {
            while (true)
            {
                int carId = "Enter Car Id: ".TryConvert<int>(false);

                try
                {
                    return _userPanel.GetCar(c => c.Id == carId);
                }
                catch (Exception ex)
                {
                    Helper.ErrorMessage(ex.Message);
                }
            }
        }

        private bool IsOperableUI()
        {
            while (true)
            {
                int op = "Is Car Operable? 1.Yes 2. No".TryConvert<int>(true);
                if (op == 1)
                {
                    return true;
                }
                else if (op == 2)
                {
                    return false;
                }
            }
        }

        private void GetCars()
        {
            IEnumerable<Car> cars = _userPanel.GetAllCars();

            foreach (var car in cars)
            {
                car.DisplayInfo();
            }
        }

        private void GetCities()
        {
            IEnumerable<City> cities = _userPanel.GetAllCities();

            foreach (var city in cities)
            {
                city.DisplayInfo();
            }
        }
    }
}
