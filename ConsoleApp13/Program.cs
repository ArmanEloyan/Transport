using ConsoleApp13.Models;
using ConsoleApp13.Repos;
using ConsoleApp13.UI;

namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext();


            IRepository<City> citiesRepo = new Repository<City>(dataContext);
            IRepository<Car> carRepo = new Repository<Car>(dataContext);
            IRepository<Way> waysRepo = new Repository<Way>(dataContext);
            IRepository<Order> orderRepo = new Repository<Order>(dataContext);
            TransportCompanyOrderSystem orderSystem = new TransportCompanyOrderSystem(orderRepo);

            AdminPanel adminPanel = new AdminPanel(citiesRepo, carRepo, waysRepo, orderRepo);
            UserPanel userPanel = new UserPanel(citiesRepo, carRepo, waysRepo, orderRepo);
            MainUI ui = new MainUI(new AdminUI(adminPanel), new UserUI(userPanel, orderSystem));
            ui.MainMenuShow();
        }
    }
}
