using ConsoleApp13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.UI
{
    partial class AdminUI
    {
        private void ShowCarsPanel()
        {
            while (true)
            {
                int option = "1. Add Car | 2. Delete Car | 3. Get | 4. GetAll | 5. Update | 0. Back".TryConvert<int>(true, ConsoleColor.Blue);
                switch (option)
                {
                    case 1:
                        AddCar();
                        break;
                    case 2:
                        DeleteCar();
                        break;
                    case 3:
                        GetCar();
                        break;
                    case 4:
                        GetAllCars();
                        break;
                    case 5:
                        UpdateCar();
                        break;
                    case 0:
                        return;
                }
            }
        }

        private void AddCar()
        {
            string carMark = "Enter Mark: ".TryConvertNullOrWhiteSpaceCheck(false);
            string carModel = "Enter Model: ".TryConvertNullOrWhiteSpaceCheck(false); ;
            int carYear = "Enter Year: ".TryConvert<int>(false);

            int carType = 0;
            while (true)
            {
                carType = "Enter Car Type (1. Sedan | 2. Jeep | 3. Moto | 4. Truck)".TryConvert<int>(true, ConsoleColor.Blue);
                carType--;

                if(carType >= 0 && carType < 4)
                {
                    break;
                }
            }
            CarType type = (CarType)carType;

            try
            {
                Car car = new Car(carMark, carModel, carYear, type);
                _adminPanel.Add(car);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }
        }

        private void DeleteCar()
        {
            int carId = "Enter car ID: ".TryConvert<int>(false);
            Car car = null;

            try
            {
                car = _adminPanel.GetCar(c => c.Id == carId);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
                return;
            }

            _adminPanel.Delete(car);
        }

        private void GetCar()
        {
            Car car = null;
            int id = "Enter car ID: ".TryConvert<int>(false);

            try
            {
                car = _adminPanel.GetCar(c=>c.Id == id);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
                return;
            }

            Console.WriteLine(car.DisplayInfo());
        }

        private void GetAllCars()
        {
            foreach (var car in _adminPanel.GetAllCars())
            {
                Console.WriteLine(car.DisplayInfo());
            }
        }

        private void UpdateCar()
        {
            while (true)
            {
                int id = "Enter car ID: ".TryConvert<int>(false);
                Car car = null;

                try
                {
                    car = _adminPanel.GetCar(c => c.Id == id);
                }
                catch (Exception ex)
                {
                    Helper.ErrorMessage(ex.Message);
                    return;
                }

                Console.WriteLine("What you want to change?");
                int option = "1. Mark | 2. Model | 3. Year | 4. Type | 0. Back".TryConvert<int>(true, ConsoleColor.Blue);

                switch (option)
                {
                    case 1:
                        car.Mark = "Enter new Mark: ".TryConvertNullOrWhiteSpaceCheck(false);
                        break;

                    case 2:
                        car.Model = "Enter new Model: ".TryConvertNullOrWhiteSpaceCheck(false);
                        break;

                    case 3:
                        try
                        {
                            car.Year = "Enter new Year: ".TryConvert<int>(false);
                        }
                        catch (Exception ex)
                        {
                            Helper.ErrorMessage(ex.Message);
                        }
                        break;
                    case 4:
                        try
                        {
                            int op = 0;

                            Console.WriteLine("(1. Sedan | 2. Jeep | 3. Moto | 4. Truck)");
                            while (true)
                            {
                                op = "Enter Type option: ".TryConvert<int>(true);
                                op--;
                                if (op >= 0 && op < 4)
                                {
                                    break;
                                }
                            }
                            car.Type = (CarType)op;
                            break;
                        }
                        catch (Exception ex)
                        {
                            Helper.ErrorMessage(ex.Message);
                        }
                        break;
                    case 0:
                        return;
                }

                try
                {
                    _adminPanel.Update(car);
                }
                catch (Exception ex)
                {
                    Helper.ErrorMessage(ex.Message);
                }

            }
        }
    }
}
