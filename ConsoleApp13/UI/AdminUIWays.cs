using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.UI
{
    partial class AdminUI
    {
        private void ShowWaysPanel()
        {
            while (true)
            {
                int option = "1. Add Way | 2. Delete Way | 3. Get | 4. GetAll | 5. Update | 0. Back".TryConvert<int>(true);
                switch (option)
                {
                    case 1:
                        AddWay();
                        break;
                    case 2:
                        DeleteWay();
                        break;
                    case 3:
                        GetWay();
                        break;
                    case 4:
                        GetAllWays();
                        break;
                    case 5:
                        UpdateWay();
                        break;
                    case 0:
                        return;
                }
            }
        }

        private void AddWay()
        {
            City cityFrom = null;
            City cityTo = null;

            try
            {
                int cityFromId = "Enter city from ID: ".TryConvert<int>(false);
                cityFrom = _adminPanel.GetCity(c=> c.Id == cityFromId);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
                return;
            }

            try
            {
                int cityToId = "Enter city to ID: ".TryConvert<int>(false);
                cityTo = _adminPanel.GetCity(c => c.Id == cityToId);
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
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
                return;
            }

            _adminPanel.AddWay(way);
        }

        private void DeleteWay()
        {
            int id = "Enter way ID: ".TryConvert<int>(false);
            Way way = null;

            try
            {
                way = _adminPanel.GetWay(w => w.Id == id);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
                return;
            }

            _adminPanel.DeleteWay(way);
        }

        private void GetWay()
        {
            Way way = null;
            int id = "Enter way ID: ".TryConvert<int>(false);

            try
            {
                way = _adminPanel.GetWay(w => w.Id == id);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
                return;
            }

            way.DisplayInfo();
            
        }

        private void GetAllWays()
        {
            IEnumerable<Way> ways = _adminPanel.GetAllWays();

            foreach (var way in ways)
            {
                way.DisplayInfo();
            }
        }

        private void UpdateWay()
        {
            while (true)
            {
                int id = "Enter way ID: ".TryConvert<int>(false);
                Way oldWayObj = null;

                try
                {
                    oldWayObj = _adminPanel.GetWay(w => w.Id == id);
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
                            oldWayObj.CityFrom = _adminPanel.GetCity(c => c.Id == idCityFrom);
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
                            oldWayObj.CityTo = _adminPanel.GetCity(c => c.Id == idCityTo);
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
                    _adminPanel.Update(oldWayObj);
                }
                catch (Exception ex)
                {
                    Helper.ErrorMessage(ex.Message);
                }

            }
        }

    }
}