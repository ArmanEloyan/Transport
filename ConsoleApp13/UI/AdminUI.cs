using System;
using ConsoleApp13.Entities;

namespace ConsoleApp13.UI
{
    partial class AdminUI
    {
        private AdminPanel _adminPanel;

        public AdminUI(AdminPanel adminPanel)
        {
            _adminPanel = adminPanel;
        }

        public async Task ShowAdminPanel()
        {
            while (true)
            {
                int option = "1. Cities | 2. Cars | 3. Ways  | 4. Orders | 5. CarTypes | 0. Back".TryConvertWithMessage<int>(true, ConsoleColor.Blue);

                switch (option)
                {
                    case 1:
                       await ShowCitiesPanel();
                        break;
                    case 2:
                        await ShowCarsPanel();
                        break;
                    case 3:
                        await ShowWaysPanel();
                        break;
                    case 4:
                        await ShowOrders();
                        break;
                    case 5:
                        await ShowCarTypePanel();
                        break;
                    case 0:
                        return;
                }
            }
        }

        private async Task ShowOrders()
        {
            foreach (var order in await _adminPanel.GetAllOrdersAsync())
            {
                Console.WriteLine(order.DisplayInfo() + "\n");
            }
        }

        private async Task ShowCitiesPanel()
        {
            while (true)
            {
                int option = "1. Add City | 2. Delete City | 3. Get | 4. GetAll | 5. Update | 0. Back".TryConvertWithMessage<int>(true, ConsoleColor.Blue);
                switch (option)
                {
                    case 1:
                        await AddCity();
                        break;
                    case 2:
                       await DeleteCity();
                        break;
                    case 3:
                        await GetCity();
                        break;
                    case 4:
                        await GetAllCities();
                        break;
                    case 5:
                        await UpdateCity();
                        break;
                    case 0:
                        return;
                }
            }
        }

        private async Task AddCity()
        {
            string cityName = "Enter City Name: ".TryConvertNullOrWhiteSpaceCheck(false);

            try
            {
                City city = new City(cityName);
                await _adminPanel.AddAsync(city);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }
        }

        private async Task DeleteCity()
        {
            int cityId = "Enter city ID: ".TryConvert<int>(false);
            City city = null;

            try
            {
                city = await _adminPanel.GetCityAsync(cityId);
                await _adminPanel.DeleteAsync(city);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
                return;
            }
        }

        private async Task GetCity()
        {
            City city = null;
            int id = "Enter city ID: ".TryConvert<int>(false);

            try
            {
                city = await _adminPanel.GetCityAsync(id);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
                return;
            }

            Console.WriteLine(city.DisplayInfo());
        }

        private async Task GetAllCities()
        {
            try
            {
                foreach (var city in await _adminPanel.GetAllCitiesAsync())
                {
                    Console.WriteLine(city.DisplayInfo());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task UpdateCity()
        {
            int id = "Enter city ID to Update: ".TryConvert<int>(false);
            City oldCity = null;

            try
            {
                oldCity = await _adminPanel.GetCityAsync(id);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
                return;
            }


            string cityNewName = "Enter new name: ".TryConvertNullOrWhiteSpaceCheck(false);

            oldCity.Name = cityNewName;

            try
            {
               await _adminPanel.UpdateAsync(oldCity);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }

        }

    }
}
