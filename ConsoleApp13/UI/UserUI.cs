using ConsoleApp13.Entities;
using ConsoleApp13.Services;
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
        private UserService _userService;
        private TransportCompanyOrderSystem _transportCompanyOrderSystem;

        public UserUI(UserService userPanel, TransportCompanyOrderSystem transportCompanyOrderSystem)
        {
            _userService = userPanel;
            _transportCompanyOrderSystem = transportCompanyOrderSystem;
        }

        public async Task UserPanelShow()
        {
            while (true)
            {
                int option = "1. Get Ways | 2.Get Cars | 3. Start 0. Back".TryConvertWithMessage<int>(true, ConsoleColor.Blue);

                switch (option)
                {
                    case 1:
                        await GetWays();
                        break;
                    case 2:
                       await GetCars();
                        break;
                    case 3:
                       await Start();
                        break;
                    case 0:
                        return;
                }
            }
        }

        private async Task Start()
        {
            City cityFrom = null;
            City cityTo = null;
            Car car = null;
            Way way = null;

            while (true)
            {
                way = await GetWay();

                if (way == null)
                    continue;

                break;
            }

            TransportType transportType = GetTransportTypeUI();
            car = await GetCarUI();
            car.IsOperable = IsOperableUI();

            DateToReceve dateToReceve = GetReceveDateUI();
            string email = "Enter Email: ".TryConvertNullOrWhiteSpaceCheck(false);

    
            Order order =_transportCompanyOrderSystem.CreateOrder(way, car, email, transportType, dateToReceve);

            Console.WriteLine($"Transport Cost: {order.Price}");

            int payOption = "1. Pay | 0. Back".TryConvertWithMessage<int>(true, ConsoleColor.Blue);

            if (payOption == 1)
            {
                try
                {
                    _transportCompanyOrderSystem.CompleteOrder(order);
                }
                catch (Exception ex)
                {
                    Helper.ErrorMessage(ex.Message);
                }
            }
            else
            {
                return;
            }

        }

        private async Task<Way> GetWay()
        {
            while (true)
            {
                int id = "Enter Way Id: ".TryConvert<int>(false);
                try
                {
                    return await _userService.GetWay(id);
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
                int type = "Enter Transport Type: 1. Open 2. Enclosed".TryConvertWithMessage<int>(true, ConsoleColor.Blue);
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
                int type = "Enter Date to Receve: 1. Week 2. Month 3. 2 Months".TryConvertWithMessage<int>(true, ConsoleColor.Blue);
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

        private async Task<Car> GetCarUI()
        {
            while (true)
            {
                int carId = "Enter Car Id: ".TryConvert<int>(false);

                try
                {
                    return await _userService.GetCar(carId);
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

        private async Task GetCars()
        {
            try
            {
                foreach (var car in await _userService.GetAllCars())
                {
                    Console.WriteLine(car.DisplayInfo());
                }
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }
        }

        private async Task GetWays()
        {
            try
            {
                foreach (var way in await _userService.GetAllWays())
                {
                    Console.WriteLine(way.DisplayInfo());
                }
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }
        }
    }
}
