﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.UI
{
    partial class AdminUI
    {
        private AdminPanel _adminPanel;

        public AdminUI(AdminPanel adminPanel)
        {
            _adminPanel = adminPanel;
        }

        public void ShowAdminPanel()
        {
            while (true)
            {
                int option = "1. Cities | 2. Cars | 3. Ways  | 4. Orders | 0. Back".TryConvert<int>(true, ConsoleColor.Blue);

                switch (option)
                {
                    case 1:
                        ShowCitiesPanel();
                        break;
                    case 2:
                        ShowCarsPanel();
                        break;
                    case 3:
                        ShowWaysPanel();
                        break;
                    case 4:
                        ShowOrders();
                        break;
                    case 0:
                        return;
                }
            }
        }

        private void ShowOrders()
        {
            foreach (var order in _adminPanel.GetAllOrders())
            {
                Console.WriteLine(order.DisplayInfo() + "\n");
            }
        }

        private void ShowCitiesPanel()
        {
            while (true)
            {
                int option = "1. Add City | 2. Delete City | 3. Get | 4. GetAll | 5. Update | 0. Back".TryConvert<int>(true, ConsoleColor.Blue);
                switch (option)
                {
                    case 1:
                        AddCity();
                        break;
                    case 2:
                        DeleteCity();
                        break;
                    case 3:
                        GetCity();
                        break;
                    case 4:
                        GetAllCities();
                        break;
                    case 5:
                        UpdateCity();
                        break;
                    case 0:
                        return;
                }
            }
        }

        private void AddCity()
        {
            string cityName = "Enter City Name: ".TryConvertNullOrWhiteSpaceCheck(false);

            try
            {
                City city = new City(cityName);
                _adminPanel.Add(city);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }
        }

        private void DeleteCity()
        {
            int cityId = "Enter city ID: ".TryConvert<int>(false);
            City city = null;

            try
            {
                city = _adminPanel.GetCity(c => c.Id == cityId);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
                return;
            }

            _adminPanel.Delete(city);
        }

        private void GetCity()
        {
            City city = null;
            int id = "Enter city ID: ".TryConvert<int>(false);

            try
            {
                city = _adminPanel.GetCity(c => c.Id == id);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
                return;
            }

            Console.WriteLine(city.DisplayInfo());
        }

        private void GetAllCities()
        {
            try
            {
                foreach (var city in _adminPanel.GetAllCities())
                {
                    Console.WriteLine(city.DisplayInfo());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void UpdateCity()
        {
            int id = "Enter city ID to Update: ".TryConvert<int>(false);
            City oldCity = null;

            try
            {
                oldCity = _adminPanel.GetCity(c => c.Id == id);
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
                _adminPanel.Update(oldCity);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }

        }

    }
}
