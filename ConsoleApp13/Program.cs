using ConsoleApp13.CityFldr;
using ConsoleApp13.Repos;
using ConsoleApp13.UI;

namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository<City> citiesRepo = new Repository<City>();
            IRepository<Car> carRepo = new Repository<Car>();
            IRepository<Way> waysRepo = new Repository<Way>();

            AdminPanel adminPanel = new AdminPanel(citiesRepo, carRepo,waysRepo);
            UserPanel userPanel = new UserPanel(citiesRepo, carRepo, waysRepo);
            MainUI ui = new MainUI(new AdminUI(adminPanel), new UserUI(userPanel));
            ui.MainMenuShow();
        }
    }
}
