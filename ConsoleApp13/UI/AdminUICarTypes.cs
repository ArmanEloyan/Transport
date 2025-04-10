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
        public async Task ShowCarTypePanel()
        {
            while (true)
            {
                int option = "1. Add CarType | 2. Delete CarType | 3. Get | 4. GetAll | 5. Update | 0. Back".TryConvertWithMessage<int>(true, ConsoleColor.Blue);
                switch (option)
                {
                    case 1:
                        await AddCarType();
                        break;
                    case 2:
                        await DeleteCarType();
                        break;
                    case 3:
                        await GetCarType();
                        break;
                    case 4:
                        await GetAllCarTypes();
                        break;
                    case 5:
                        await UpdateCarType();
                        break;
                    case 0:
                        return;
                }
            }
        }

        private async Task AddCarType()
        {
            string name = "Enter car type name: ".TryConvertNullOrWhiteSpaceCheck(false);

            double coef = 1.0;
            while (true)
            {
                coef = "Enter car type coefficent: ".TryConvert<double>(false);

                if (coef < 1.0)
                {
                    Helper.ErrorMessage("Coefficient cant be less than 1.0");
                    continue;
                }
                break;
            }

            try
            {
                CarType carType = new CarType(name, coef);
                await _adminPanel.AddAsync(carType);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }

        }

        private async Task DeleteCarType()
        {
            int id = "Enter car type ID: ".TryConvert<int>(false);

            try
            {
                CarType carType = await _adminPanel.GetCarTypeAsync(id);
                await _adminPanel.DeleteAsync(carType);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }
        }

        private async Task UpdateCarType()
        {
            CarType carType = null;

            int id = "Enter car type ID: ".TryConvert<int>(false);
            try
            {
                carType = await _adminPanel.GetCarTypeAsync(id);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
                return;
            }


            string name = "Enter new type name: ".TryConvertNullOrWhiteSpaceCheck(false);
            double coef = 1.0;

            while (true)
            {
                coef = "Enter type new coefficent: ".TryConvert<double>(false);
                if (coef < 1.0)
                {
                    Helper.ErrorMessage("Coefficient cant be less than 1.0");
                    continue;
                }
                break;
            }

            carType.Name = name;
            carType.Coefficent = coef;

            try
            {
                await _adminPanel.UpdateAsync(carType);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }
        }

        private async Task GetAllCarTypes()
        {
            try
            {
                foreach (var carType in await _adminPanel.GetAllCarTypesAsync())
                {
                    Console.WriteLine(carType.DisplayInfo() + "\n");
                }
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }
        }

        private async Task GetCarType()
        {
            int id = "Enter car type ID: ".TryConvert<int>(false);
            try
            {
                CarType carType = await _adminPanel.GetCarTypeAsync(id);
                Console.WriteLine(carType.DisplayInfo() + "\n");
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }
        }
    }
}
