using ConsoleApp13.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.UI
{
    partial class AdminUI
    {
        private async Task ShowCarsPanel()
        {
            while (true)
            {
                int option = "1. Add Car | 2. Delete Car | 3. Get | 4. GetAll | 5. Update | 0. Back".TryConvertWithMessage<int>(true, ConsoleColor.Blue);
                switch (option)
                {
                    case 1:
                        await AddCar();
                        break;
                    case 2:
                        await DeleteCar();
                        break;
                    case 3:
                        await GetCar();
                        break;
                    case 4:
                        await GetAllCars();
                        break;
                    case 5:
                        await UpdateCar();
                        break;
                    case 0:
                        return;
                }
            }
        }

        private async Task AddCar()
        {
            CarType carType = null;

            string carMark = "Enter Mark: ".TryConvertNullOrWhiteSpaceCheck(false);
            string carModel = "Enter Model: ".TryConvertNullOrWhiteSpaceCheck(false); ;
            int carYear = "Enter Year: ".TryConvert<int>(false);

            int carTypeId = 0;
            while (true)
            {
                carTypeId = "Enter Car Type Id: ".TryConvertWithMessage<int>(true, ConsoleColor.Blue);

                try
                {
                    carType = await _adminService.GetCarTypeAsync(carTypeId);
                    break;
                }
                catch (Exception ex)
                {
                    Helper.ErrorMessage(ex.Message);
                }
            }

            try
            {
                Car car = new Car(carMark, carModel, carYear, carType) { CarTypeId =carTypeId};
                await _adminService.AddAsync(car);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }
        }

        private async Task DeleteCar()
        {
            int carId = "Enter car ID: ".TryConvert<int>(false);
            Car car = null;

            try
            {
                car = await _adminService.GetCarAsync(carId);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
                return;
            }

            await _adminService.DeleteAsync(car);
        }

        private async Task GetCar()
        {
            Car car = null;
            int id = "Enter car ID: ".TryConvert<int>(false);

            try
            {
                car = await _adminService.GetCarAsync(id);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
                return;
            }

            Console.WriteLine(car.DisplayInfo());
        }

        private async Task GetAllCars()
        {
            try
            {
                foreach (var car in await _adminService.GetAllCarsAsync())
                {
                    Console.WriteLine(car.DisplayInfo());
                }
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }
        }

        private async Task UpdateCar()
        {
            while (true)
            {
                int id = "Enter car ID: ".TryConvert<int>(false);
                Car car = null;

                try
                {
                    car = await _adminService.GetCarAsync(id);
                }
                catch (Exception ex)
                {
                    Helper.ErrorMessage(ex.Message);
                    return;
                }
                Console.WriteLine("idddd = "+car.Id);
                Console.WriteLine("What you want to change?");
                int option = "1. Mark | 2. Model | 3. Year | 4. Type | 0. Back".TryConvertWithMessage<int>(true, ConsoleColor.Blue);

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
                        CarType carType = null;
                        int carTypeId = 0;
                        while (true)
                        {
                            carTypeId = "Enter Car Type Id: ".TryConvertWithMessage<int>(true, ConsoleColor.Blue);

                            try
                            {
                                carType = await _adminService.GetCarTypeAsync(carTypeId);
                                car.Type = carType;
                                break;
                            }
                            catch (Exception ex)
                            {
                                Helper.ErrorMessage(ex.Message);
                            }
                        }
                        break;
                    case 0:
                        return;
                }

                try
                {
                    await _adminService.UpdateAsync(car);
                    return;
                }
                catch (Exception ex)
                {
                    Helper.ErrorMessage(ex.Message);
                }

            }
        }
    }
}
