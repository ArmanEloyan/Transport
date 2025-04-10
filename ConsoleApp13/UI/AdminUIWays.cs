using ConsoleApp13.Entities;

namespace ConsoleApp13.UI
{
    partial class AdminUI
    {
        private async Task ShowWaysPanel()
        {
            while (true)
            {
                int option = "1. Add Way | 2. Delete Way | 3. Get | 4. GetAll | 5. Update | 0. Back".TryConvert<int>(true);
                switch (option)
                {
                    case 1:
                        await AddWay();
                        break;
                    case 2:
                        await DeleteWay();
                        break;
                    case 3:
                        await GetWay();
                        break;
                    case 4:
                        await GetAllWays();
                        break;
                    case 5:
                        await UpdateWay();
                        break;
                    case 0:
                        return;
                }
            }
        }

        private async Task AddWay()
        {
            City cityFrom = null;
            City cityTo = null;

            try
            {
                int cityFromId = "Enter city from ID: ".TryConvert<int>(false);
                cityFrom = await _adminPanel.GetCityAsync(cityFromId);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
                return;
            }

            try
            {
                int cityToId = "Enter city to ID: ".TryConvert<int>(false);
                cityTo = await _adminPanel.GetCityAsync(cityToId);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
                return;
            }

            double price = "Enter start Price: ".TryConvert<double>(false);
            Way way = null;
            try
            {
                way = new Way(cityFrom, cityTo, price);
                await _adminPanel.AddAsync(way);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
                return;
            }
        }

        private async Task DeleteWay()
        {
            int id = "Enter way ID: ".TryConvert<int>(false);
            Way way = null;

            try
            {
                way = await _adminPanel.GetWayAsync(id);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
                return;
            }

            try
            {
                await _adminPanel.DeleteAsync(way);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }
        }

        private async Task GetWay()
        {
            Way way = null;
            int id = "Enter way ID: ".TryConvert<int>(false);

            try
            {
                way = await _adminPanel.GetWayAsync(id);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
                return;
            }

            Console.WriteLine(way.DisplayInfo());

        }

        private async Task GetAllWays()
        {
         //   try
          //  {
                foreach (var way in await _adminPanel.GetAllWaysAsync())
                {
                    Console.WriteLine("test");
                    Console.WriteLine(way.DisplayInfo());
                }
          // }
          //  catch (Exception ex)
           // {
           //     Helper.ErrorMessage(ex.Message);
           // }
        }

        private async Task UpdateWay()
        {
            while (true)
            {
                int id = "Enter way ID: ".TryConvert<int>(false);
                Way oldWayObj = null;

                try
                {
                    oldWayObj = await _adminPanel.GetWayAsync(id);
                }
                catch (Exception ex)
                {
                    Helper.ErrorMessage(ex.Message);
                    return;
                }

                Console.WriteLine("What you want to change?");
                int option = "1. City From | 2. City To | 3. Price | 0. Back".TryConvert<int>(true);

                switch (option)
                {
                    case 1:
                        int idCityFrom = "Enter new City Id: ".TryConvert<int>(false);
                        try
                        {
                            oldWayObj.CityFrom = await _adminPanel.GetCityAsync(idCityFrom);
                        }
                        catch (Exception ex)
                        {
                            Helper.ErrorMessage(ex.Message);
                        }
                        break;
                    case 2:
                        int idCityTo = "Enter new City Id: ".TryConvert<int>(false);
                        try
                        {
                            oldWayObj.CityTo = await _adminPanel.GetCityAsync(idCityTo);
                        }
                        catch (Exception ex)
                        {
                            Helper.ErrorMessage(ex.Message);
                        }
                        break;
                    case 3:
                        try
                        {
                            oldWayObj.StartPrice = "Enter new Start Price: ".TryConvert<int>(false);
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
                    await _adminPanel.UpdateAsync(oldWayObj);
                }
                catch (Exception ex)
                {
                    Helper.ErrorMessage(ex.Message);
                }

            }
        }

    }
}